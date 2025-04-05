using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterP.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public ProductCategory Category { get; set; }

        [Required]
        [Display(Name = "Starting Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StartingPrice { get; set; }

        [Display(Name = "Reserve Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ReservePrice { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public AuctionStatus Status { get; set; } = AuctionStatus.Pending;

        // Foreign Keys
        [Required]
        public string SellerId { get; set; }

        public int? WinningBidId { get; set; }

        // Navigation properties
        [ForeignKey("SellerId")]
        public virtual ApplicationUser Seller { get; set; }

        [ForeignKey("WinningBidId")]
        public virtual Bid WinningBid { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public virtual ICollection<AuctionImage> Images { get; set; } = new List<AuctionImage>();

        // For livestock specific attributes
        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Breed")]
        public string? Breed { get; set; }

        [Display(Name = "Weight (kg)")]
        public decimal? Weight { get; set; }

        [Display(Name = "Health Certificate")]
        public string? HealthCertificateUrl { get; set; }
    }

    public class Bid
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime BidTime { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public int AuctionId { get; set; }

        [Required]
        public string BidderId { get; set; }

        // Navigation properties
        [ForeignKey("AuctionId")]
        public virtual Auction Auction { get; set; }

        [ForeignKey("BidderId")]
        public virtual ApplicationUser Bidder { get; set; }
    }

    public class AuctionImage
    {
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        public int AuctionId { get; set; }
        
        [ForeignKey("AuctionId")]
        public virtual Auction Auction { get; set; }
        
        public bool IsMain { get; set; } = false;
    }

    public enum AuctionStatus
    {
        Pending,
        Active,
        Ended,
        Cancelled,
        Sold
    }
} 