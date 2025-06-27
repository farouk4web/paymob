namespace Paymob.Services.Paymob.Egy.v2
{
    public interface IPaymobEgy2Service
    {
        Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue);
    }
}