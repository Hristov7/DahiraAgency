namespace DahiraAgency.Data.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Destination>> GetAllDestinationsForAdminAsync();
        Task CreateDestinationAsync(Destination destination);
        Task EditDestinationAsync(Destination destination);
        Task DeleteDestinationAsync(int id);
    }
}
