namespace Paymob.Models.Paymob.Egy.v1.Step2
{
    public class PaymobOrderItem
    {
        public string? Name { get; set; }
        public decimal Amount_cents { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}