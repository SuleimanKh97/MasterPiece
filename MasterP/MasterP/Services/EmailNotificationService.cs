using System.Net;
using System.Net.Mail;

namespace MasterP.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpServer = _configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            _smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            _smtpPassword = _configuration["EmailSettings:SmtpPassword"];
            _fromEmail = _configuration["EmailSettings:FromEmail"];
            _fromName = _configuration["EmailSettings:FromName"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail, _fromName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                await client.SendMailAsync(mailMessage);
            }
        }

        public async Task SendBidNotificationAsync(string email, string auctionTitle, decimal bidAmount)
        {
            string subject = $"New Bid on {auctionTitle}";
            string message = $@"
                <h2>New Bid Notification</h2>
                <p>A new bid of ${bidAmount} has been placed on your auction: <strong>{auctionTitle}</strong>.</p>
                <p>Login to view more details.</p>
            ";

            await SendEmailAsync(email, subject, message);
        }

        public async Task SendMessageNotificationAsync(string email, string senderName)
        {
            string subject = $"New Message from {senderName}";
            string message = $@"
                <h2>New Message Notification</h2>
                <p>You have received a new message from <strong>{senderName}</strong>.</p>
                <p>Login to read and reply to your messages.</p>
            ";

            await SendEmailAsync(email, subject, message);
        }

        public async Task SendOrderConfirmationAsync(string email, int orderId, decimal amount)
        {
            string subject = $"Order Confirmation #{orderId}";
            string message = $@"
                <h2>Order Confirmation</h2>
                <p>Thank you for your order. Your order #{orderId} has been confirmed.</p>
                <p>Total Amount: ${amount}</p>
                <p>Login to view your order details.</p>
            ";

            await SendEmailAsync(email, subject, message);
        }

        public async Task SendOrderStatusUpdateAsync(string email, int orderId, string status)
        {
            string subject = $"Order #{orderId} Status Update";
            string message = $@"
                <h2>Order Status Update</h2>
                <p>Your order #{orderId} has been updated to: <strong>{status}</strong>.</p>
                <p>Login to view more details about your order.</p>
            ";

            await SendEmailAsync(email, subject, message);
        }
    }
} 