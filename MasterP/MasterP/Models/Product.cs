using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterP.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public ProductCategory Category { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Unit")]
        public string Unit { get; set; } = "Unit";

        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; } = false;

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public string SellerId { get; set; }

        // Navigation properties
        [ForeignKey("SellerId")]
        public virtual ApplicationUser Seller { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        // For livestock specific attributes
        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Breed")]
        public string? Breed { get; set; }

        [Display(Name = "Weight (kg)")]
        public decimal? Weight { get; set; }

        [Display(Name = "Health Certificate")]
        public string? HealthCertificateUrl { get; set; }

        [Display(Name = "Production Capacity")]
        public string? ProductionCapacity { get; set; }
    }

    public enum ProductCategory
    {
        Livestock,
        DairyProducts,
        Crops,
        Fruits,
        Vegetables,
        Seeds,
        Fodder,
        FarmEquipment,
        Other
    }

    public class ProductImage
    {
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        public bool IsMain { get; set; } = false;
    }
} 