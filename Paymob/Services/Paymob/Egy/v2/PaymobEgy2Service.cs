using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Paymob.Models.Paymob.Egy.v2;
using Paymob.Settings;

namespace Paymob.Services.Paymob.Egy.v2
{
    public class PaymobEgy2Service : IPaymobEgy2Service
    {
        private readonly PaymobEgy2Settings _settings;
        public PaymobEgy2Service(IOptions<PaymobEgy2Settings> paymobSettings)
        {
            _settings = paymobSettings.Value;
        }

        public async Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue)
        {
            amount *= 100;
            string? clientSecret = await CreateTheIntentionRequest(amount, uniqueValue);
            string? url = $"https://accept.paymob.com/unifiedcheckout/?publicKey={_settings.PublicKey}&clientSecret={clientSecret}";

            return url;
        }

        private async Task<string?> CreateTheIntentionRequest(decimal amount, string? uniqueValue)
        {
            try
            {
                using HttpClient _client = new();
                string? apiUrl = "https://accept.paymob.com/v1/intention/";

                _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"token {_settings.SecretKey}");
                //_client.DefaultRequestHeaders.Add(HeaderNames.ContentType, "application/json");

                var body = new
                {
                    amount,
                    currency = "EGP",
                    special_reference = uniqueValue,
                    payment_methods = new int[] { _settings.CardIntegrationId, _settings.WalletIntegrationId },
                    items = Array.Empty<object>(),
                    billing_data = new
                    {
                        first_name = "dumy",
                        last_name = "dumy",
                        email = "dumy@dumy.com",
                        phone_number = "2001125773493"
                    }
                };

                //var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                var response = await _client.PostAsJsonAsync(apiUrl, body);

                if (response.IsSuccessStatusCode)
                {
                    var responseModel = await response.Content.ReadFromJsonAsync<ResponseOrderCreation>();

                    return responseModel?.client_secret;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "Faild_To_Connect";
        }
    }
}