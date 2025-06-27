namespace Paymob.Services.Payment
{
    public interface IPaymentService
    {
        Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue);
    }
}