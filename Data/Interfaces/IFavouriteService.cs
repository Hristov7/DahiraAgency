namespace DahiraAgency.Data.Interfaces
{
    public interface IFavouriteService
    {
        Task<IEnumerable<Favourite>> GetUserFavouritesAsync(string userId);
        Task AddFavouriteAsync(string userId, int destinationId);
        Task RemoveFavouriteAsync(string userId, int destinationId);
    }
}
