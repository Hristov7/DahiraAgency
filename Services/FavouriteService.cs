using DahiraAgency.Data;
using DahiraAgency.Data.Interfaces;
using DahiraAgency.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DahiraAgency.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IRepository<Favourite> _favouriteRepository;

        public FavouriteService(IRepository<Favourite> favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        public async Task<IEnumerable<Favourite>> GetUserFavouritesAsync(string userId)
        {
            return await _favouriteRepository
                .Query()
                .Where(f => f.UserId == userId)
                .Include(f => f.Destination)
                .ToListAsync();
        }

        public async Task AddFavouriteAsync(string userId, int destinationId)
        {
            var existing = await _favouriteRepository.FindAsync(f => f.UserId == userId && f.DestinationId == destinationId);
            if (!existing.Any())
            {
                await _favouriteRepository.AddAsync(new Favourite
                {
                    UserId = userId,
                    DestinationId = destinationId
                });
            }
        }

        public async Task RemoveFavouriteAsync(string userId, int destinationId)
        {
            var favourites = await _favouriteRepository.FindAsync(f => f.UserId == userId && f.DestinationId == destinationId);
            foreach (var fav in favourites)
            {
                await _favouriteRepository.DeleteAsync(fav);
            }
        }
    }
}
