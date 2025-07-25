namespace DahiraAgency.Data.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllDestinationsAsync(string searchTerm = null, int page = 1, int pageSize = 10);
        Task<Destination> GetDestinationByIdAsync(int id);
        Task AddDestinationAsync(Destination destination);
        Task UpdateDestinationAsync(Destination destination);
        Task DeleteDestinationAsync(int id);
        Task<int> GetTotalCountAsync(string searchTerm = null);
    }
}
