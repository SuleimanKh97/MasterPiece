using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MasterP.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ProfilePictureUrl { get; set; }

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; } = 0;

        [Display(Name = "Rating Count")]
        public int RatingCount { get; set; } = 0;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Review> ReceivedReviews { get; set; } = new List<Review>();
        public virtual ICollection<Review> GivenReviews { get; set; } = new List<Review>();
        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Order> Sales { get; set; } = new List<Order>();
    }

    public enum UserType
    {
        Buyer = 0,
        Seller = 1,
        Admin = 2
    }
} 