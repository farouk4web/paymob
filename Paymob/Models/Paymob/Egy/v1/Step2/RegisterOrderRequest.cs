namespace Paymob.Models.Paymob.Egy.v1.Step2
{
    public class RegisterOrderRequest
    {
        public string? Auth_token { get; set; }

        public bool Delivery_needed { get; set; }

        public string? Merchant_order_id { get; set; }

        public decimal Amount_cents { get; set; }

        public string? Currency { get; set; }

        public List<string> Items { get; set; } = [];
    }
}
