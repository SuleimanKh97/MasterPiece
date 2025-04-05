namespace MasterP.Services
{
    public interface INotificationService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendBidNotificationAsync(string email, string auctionTitle, decimal bidAmount);
        Task SendMessageNotificationAsync(string email, string senderName);
        Task SendOrderConfirmationAsync(string email, int orderId, decimal amount);
        Task SendOrderStatusUpdateAsync(string email, int orderId, string status);
    }
} 