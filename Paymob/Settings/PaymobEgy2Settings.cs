namespace Paymob.Settings
{
    public class PaymobEgy2Settings
    {
        public string? PublicKey { get; set; }
        public string? SecretKey { get; set; }
        public int CardIntegrationId { get; set; }
        public int WalletIntegrationId { get; set; }
        public string? AccountHMAC { get; set; }
    }
}