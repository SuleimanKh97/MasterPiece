using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterP.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;

        public DateTime? ReadAt { get; set; }

        // Foreign Keys
        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        // Navigation properties
        [ForeignKey("SenderId")]
        public virtual ApplicationUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual ApplicationUser Receiver { get; set; }

        // Optional Product reference
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        // Optional Auction reference
        public int? AuctionId { get; set; }

        [ForeignKey("AuctionId")]
        public virtual Auction Auction { get; set; }
    }

    public class Conversation
    {
        public int Id { get; set; }

        [Required]
        public DateTime LastMessageAt { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public string User1Id { get; set; }

        [Required]
        public string User2Id { get; set; }

        // Navigation properties
        [ForeignKey("User1Id")]
        public virtual ApplicationUser User1 { get; set; }

        [ForeignKey("User2Id")]
        public virtual ApplicationUser User2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
} 