using Stripe;

namespace MasterP.Services
{
    public class StripePaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public StripePaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _apiKey;
        }

        public async Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string paymentMethodId, string description)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = Convert.ToInt64(amount * 100), // Stripe uses cents
                    Currency = currency,
                    PaymentMethod = paymentMethodId,
                    Description = description,
                    Confirm = true,
                    ConfirmationMethod = "automatic"
                };

                var service = new PaymentIntentService();
                var paymentIntent = await service.CreateAsync(options);

                if (paymentIntent.Status == "succeeded")
                {
                    return new PaymentResult
                    {
                        Success = true,
                        TransactionId = paymentIntent.Id,
                        ErrorMessage = null
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        Success = false,
                        TransactionId = paymentIntent.Id,
                        ErrorMessage = $"Payment status: {paymentIntent.Status}"
                    };
                }
            }
            catch (StripeException e)
            {
                return new PaymentResult
                {
                    Success = false,
                    TransactionId = null,
                    ErrorMessage = e.Message
                };
            }
        }

        public async Task<PaymentResult> RefundPaymentAsync(string paymentId, decimal amount, string reason)
        {
            try
            {
                var options = new RefundCreateOptions
                {
                    PaymentIntent = paymentId,
                    Amount = Convert.ToInt64(amount * 100), // Stripe uses cents
                    Reason = GetRefundReason(reason)
                };

                var service = new RefundService();
                var refund = await service.CreateAsync(options);

                if (refund.Status == "succeeded")
                {
                    return new PaymentResult
                    {
                        Success = true,
                        TransactionId = refund.Id,
                        ErrorMessage = null
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        Success = false,
                        TransactionId = refund.Id,
                        ErrorMessage = $"Refund status: {refund.Status}"
                    };
                }
            }
            catch (StripeException e)
            {
                return new PaymentResult
                {
                    Success = false,
                    TransactionId = null,
                    ErrorMessage = e.Message
                };
            }
        }

        private RefundReasons GetRefundReason(string reason)
        {
            return reason.ToLower() switch
            {
                "duplicate" => RefundReasons.Duplicate,
                "fraudulent" => RefundReasons.Fraudulent,
                _ => RefundReasons.RequestedByCustomer
            };
        }
    }
} 