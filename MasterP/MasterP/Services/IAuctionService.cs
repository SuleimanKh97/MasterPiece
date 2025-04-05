using MasterP.Models;

namespace MasterP.Services
{
    public interface IAuctionService
    {
        Task<bool> PlaceBidAsync(int auctionId, string bidderId, decimal amount);
        Task<bool> EndAuctionAsync(int auctionId);
        Task ProcessExpiredAuctionsAsync();
        Task<Bid> GetHighestBidAsync(int auctionId);
        Task<List<Auction>> GetActiveAuctionsAsync();
        Task<List<Auction>> GetEndingSoonAuctionsAsync(int hours = 24);
    }
} 