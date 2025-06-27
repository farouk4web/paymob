namespace Paymob.Services.Paymob.Egy.v1
{
    public interface IPaymobEgy1Service
    {
        // payment ways
        Task<string?> GetPaymentLinkAsync(decimal amount, string? uniqueValue);

        // validation
        bool ValidateHMAC(string? hmacAsString, string? hmac);
    }
}
