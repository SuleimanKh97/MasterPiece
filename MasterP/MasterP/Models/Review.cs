using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterP.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public string ReviewerId { get; set; }

        [Required]
        public string RevieweeId { get; set; }

        // Optional Order reference
        public int? OrderId { get; set; }

        // Optional Product reference
        public int? ProductId { get; set; }

        // Navigation properties
        [ForeignKey("ReviewerId")]
        public virtual ApplicationUser Reviewer { get; set; }

        [ForeignKey("RevieweeId")]
        public virtual ApplicationUser Reviewee { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
} 