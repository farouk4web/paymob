using Microsoft.Extensions.Options;
using Paymob.Settings;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Paymob.Services.Paymob.Uae
{
    public class PaymobUaeService : IPaymobUaeService
    {
        private readonly PaymobUaeSettings _settings;
        private readonly HttpClient _httpClient;

        public PaymobUaeService(IOptions<PaymobUaeSettings> options)
        {
            _settings = options.Value;
            _httpClient = new HttpClient();
        }

        public async Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue)
        {
            try
            {
                var requestPayload = new
                {
                    amount = amount * 100,
                    currency = "AED",
                    special_reference = uniqueValue,
                    payment_methods = new int[] { _settings.IntegrationId },
                    items = Array.Empty<object>(),
                    billing_data = new
                    {
                        first_name = uniqueValue,
                        last_name = "dummy",
                        email = "dummy@dummy.com",
                        phone_number = "2001125773493"
                    }
                };

                var request = new HttpRequestMessage(HttpMethod.Post, "v1/intention/");
                request.Headers.Authorization = new AuthenticationHeaderValue("token", _settings.SecretKey);
                request.Content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ResponseOrderCreationUAE>(json);

                return $"https://uae.paymob.com/unifiedcheckout/?publicKey={_settings.PublicKey}&clientSecret={result?.client_secret}";
            }
            catch
            {
                return null;
            }
        }
    }
}
