using Paymob.Enums;

namespace Paymob.Settings
{
    public class PaymentSettings
    {
        public PaymentProvider PaymentProvider { get; set; }
        public bool AcceptOnlinePayments { get; set; }
    }
}
