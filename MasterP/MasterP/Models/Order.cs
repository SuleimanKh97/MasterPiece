using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterP.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string? PaymentTransactionId { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        public string? TrackingNumber { get; set; }

        public DateTime? ShippedDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        // Foreign Keys
        [Required]
        public string BuyerId { get; set; }

        [Required]
        public string SellerId { get; set; }

        // Navigation properties
        [ForeignKey("BuyerId")]
        public virtual ApplicationUser Buyer { get; set; }

        [ForeignKey("SellerId")]
        public virtual ApplicationUser Seller { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Foreign Keys
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        // Navigation properties
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Refunded
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        Stripe,
        CashOnDelivery
    }
} 