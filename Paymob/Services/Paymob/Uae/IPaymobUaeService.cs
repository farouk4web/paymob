namespace Paymob.Services.Paymob.Uae
{
    public interface IPaymobUaeService
    {
        Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue);
    }
}
