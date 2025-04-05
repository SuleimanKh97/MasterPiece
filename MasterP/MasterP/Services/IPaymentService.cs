namespace MasterP.Services
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string paymentMethodId, string description);
        Task<PaymentResult> RefundPaymentAsync(string paymentId, decimal amount, string reason);
    }

    public class PaymentResult
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
        public string ErrorMessage { get; set; }
    }
} 