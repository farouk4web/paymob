using Microsoft.Extensions.Options;
using Paymob.Models.Paymob.Egy.v1.Step1;
using Paymob.Models.Paymob.Egy.v1.Step2;
using Paymob.Models.Paymob.Egy.v1.Step3;
using Paymob.Settings;
using System.Security.Cryptography;
using System.Text;

namespace Paymob.Services.Paymob.Egy.v1
{
    public class PaymobEgy1Service : IPaymobEgy1Service
    {
        private readonly PaymobEgy1Settings _paymobSettings;
        private readonly HttpClient _httpClient;

        public PaymobEgy1Service(IOptions<PaymobEgy1Settings> paymobSettings)
        {
            _paymobSettings = paymobSettings.Value;
            _httpClient = new HttpClient();
        }

        public async Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue)
        {
            amount *= 100; // Convert to cents
            var paymentKey = await CreatePaymentKeyAsync(amount, uniqueValue);
            if (string.IsNullOrEmpty(paymentKey)) return null;

            return $"https://accept.paymobsolutions.com/api/acceptance/iframes/{_paymobSettings.IframeId}?payment_token={paymentKey}";
        }

        public bool ValidateHMAC(string? dataString, string? expectedHmac)
        {
            if (string.IsNullOrEmpty(_paymobSettings.AccountHMAC) || string.IsNullOrEmpty(dataString) || string.IsNullOrEmpty(expectedHmac))
                return false;

            var computedHmac = GenerateHmacSHA512(_paymobSettings.AccountHMAC, dataString);
            return string.Equals(computedHmac, expectedHmac, StringComparison.OrdinalIgnoreCase);
        }


        #region Private Methods
        private static string GenerateHmacSHA512(string key, string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            using var hmac = new HMACSHA512(keyBytes);
            var hashBytes = hmac.ComputeHash(messageBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        private async Task<string?> GetAuthenticationTokenAsync()
        {
            const string apiUrl = "https://accept.paymob.com/api/auth/tokens";

            var dto = new TokenRequest
            {
                Api_key = _paymobSettings.ApiKey
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(apiUrl, dto);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                    return result?.Token;
                }
            }
            catch
            {
                // Logging can be added here
            }

            return null;
        }

        private async Task<int> RegisterOrderAsync(decimal amount, string? uniqueValue)
        {
            var token = await GetAuthenticationTokenAsync();
            if (string.IsNullOrEmpty(token)) return 0;

            const string apiUrl = "https://accept.paymob.com/api/ecommerce/orders";

            var request = new RegisterOrderRequest
            {
                Auth_token = token,
                Amount_cents = amount,
                Merchant_order_id = uniqueValue,
                Currency = "EGP",
                Delivery_needed = false,
                Items = []
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(apiUrl, request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<RegisterOrderResponse>();
                    return result?.Id ?? 0;
                }
            }
            catch
            {
                // Logging can be added here
            }

            return 0;
        }

        private async Task<string?> CreatePaymentKeyAsync(decimal amount, string? uniqueValue)
        {
            var token = await GetAuthenticationTokenAsync();
            if (string.IsNullOrEmpty(token)) return null;

            var orderId = await RegisterOrderAsync(amount, uniqueValue);
            if (orderId == 0) return null;

            const string apiUrl = "https://accept.paymob.com/api/acceptance/payment_keys";

            var request = new PaymentKeyRequest
            {
                Auth_token = token,
                Order_id = orderId,
                Amount_cents = amount,
                Currency = "EGP",
                Integration_id = _paymobSettings.IntegrationId,
                Expiration = 3600,
                Billing_data = new BillingData
                {
                    First_name = "NA",
                    Last_name = "NA",
                    Email = "NA",
                    Phone_number = "+01234567890",
                    Country = "NA",
                    State = "NA",
                    City = "NA",
                    Street = "NA",
                    Building = "NA",
                    Floor = "NA",
                    Apartment = "NA",
                    Shipping_method = "NA",
                    Postal_code = "1230123"
                }
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(apiUrl, request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PaymentKeyResponse>();
                    return result?.Token;
                }
            }
            catch
            {
                // Logging can be added here
            }

            return null;
        }
        #endregion
    }
}
