using Microsoft.EntityFrameworkCore;
using MasterP.Data;
using MasterP.Models;

namespace MasterP.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public AuctionService(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<bool> PlaceBidAsync(int auctionId, string bidderId, decimal amount)
        {
            // Get the auction
            var auction = await _context.Auctions
                .Include(a => a.Seller)
                .Include(a => a.Bids)
                .FirstOrDefaultAsync(a => a.Id == auctionId);

            if (auction == null || auction.Status != AuctionStatus.Active)
                return false;

            // Check if the auction has ended
            if (DateTime.Now > auction.EndDate)
            {
                auction.Status = AuctionStatus.Ended;
                await _context.SaveChangesAsync();
                return false;
            }

            // Check if the bidder is not the seller
            if (auction.SellerId == bidderId)
                return false;

            // Get the highest bid
            var highestBid = await GetHighestBidAsync(auctionId);
            
            // Check if the new bid is higher than the current highest bid
            if (highestBid != null && amount <= highestBid.Amount)
                return false;

            // Check if the new bid is higher than the starting price
            if (highestBid == null && amount < auction.StartingPrice)
                return false;

            // Create the new bid
            var bid = new Bid
            {
                AuctionId = auctionId,
                BidderId = bidderId,
                Amount = amount,
                BidTime = DateTime.Now
            };

            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();

            // Notify the seller about the new bid
            await _notificationService.SendBidNotificationAsync(
                auction.Seller.Email,
                auction.Title,
                amount);

            return true;
        }

        public async Task<bool> EndAuctionAsync(int auctionId)
        {
            var auction = await _context.Auctions
                .Include(a => a.Bids)
                .Include(a => a.Seller)
                .FirstOrDefaultAsync(a => a.Id == auctionId);

            if (auction == null)
                return false;

            auction.Status = AuctionStatus.Ended;

            // Get the highest bid
            var highestBid = await GetHighestBidAsync(auctionId);

            // If there's a highest bid and it's greater than the reserve price (if set)
            if (highestBid != null && 
                (!auction.ReservePrice.HasValue || highestBid.Amount >= auction.ReservePrice.Value))
            {
                auction.Status = AuctionStatus.Sold;
                auction.WinningBidId = highestBid.Id;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ProcessExpiredAuctionsAsync()
        {
            var expiredAuctions = await _context.Auctions
                .Where(a => a.Status == AuctionStatus.Active && a.EndDate < DateTime.Now)
                .ToListAsync();

            foreach (var auction in expiredAuctions)
            {
                await EndAuctionAsync(auction.Id);
            }
        }

        public async Task<Bid> GetHighestBidAsync(int auctionId)
        {
            return await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.Amount)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Auction>> GetActiveAuctionsAsync()
        {
            return await _context.Auctions
                .Include(a => a.Seller)
                .Where(a => a.Status == AuctionStatus.Active && a.EndDate > DateTime.Now)
                .OrderBy(a => a.EndDate)
                .ToListAsync();
        }

        public async Task<List<Auction>> GetEndingSoonAuctionsAsync(int hours = 24)
        {
            var endDate = DateTime.Now.AddHours(hours);
            
            return await _context.Auctions
                .Include(a => a.Seller)
                .Where(a => a.Status == AuctionStatus.Active &&
                       a.EndDate > DateTime.Now &&
                       a.EndDate <= endDate)
                .OrderBy(a => a.EndDate)
                .ToListAsync();
        }
    }
} 