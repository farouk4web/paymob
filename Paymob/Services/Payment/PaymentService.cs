using Microsoft.Extensions.Options;
using Paymob.Enums;
using Paymob.Services.Paymob.Egy.v1;
using Paymob.Services.Paymob.Egy.v2;
using Paymob.Services.Paymob.Uae;
using Paymob.Settings;

namespace Paymob.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymobEgy1Service _paymobEgy1Service;
        private readonly IPaymobEgy2Service _paymobEgy2Service;
        private readonly IPaymobUaeService _paymobUaeService;
        private readonly PaymentSettings _paymentSettings;

        public PaymentService(IPaymobEgy1Service paymobEgy1Service, IPaymobEgy2Service paymobEgy2Service, IPaymobUaeService paymobUaeService, IOptions<PaymentSettings> paymentSettings)
        {
            _paymobEgy1Service = paymobEgy1Service;
            _paymobEgy2Service = paymobEgy2Service;
            _paymobUaeService = paymobUaeService;
            _paymentSettings = paymentSettings.Value;
        }
        // sync  => line by line  -> ldldld
        // async =>  -> async & await 
        // 
        public async Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue)
        {
            if (!_paymentSettings.AcceptOnlinePayments)
                throw new NotSupportedException("Online payments are not enabled in the settings.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

            switch (_paymentSettings.PaymentProvider)
            {
                case PaymentProvider.PaymobEgy1:
                    return await _paymobEgy1Service.GetPaymentLinkAsync(amount, uniqueValue) ?? "";

                case PaymentProvider.PaymobEgy2:
                    return await _paymobEgy2Service.GetPaymentLinkAsync(amount, uniqueValue) ?? "";

                case PaymentProvider.PaymobUae:
                    return await _paymobUaeService.GetPaymentLinkAsync(amount, uniqueValue) ?? "";

                default:
                    throw new NotSupportedException("Payment provider is not set.");
            }
        }
    }
}
