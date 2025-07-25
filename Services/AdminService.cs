using DahiraAgency.Data;
using DahiraAgency.Data.Interfaces;
using DahiraAgency.Data.Repositories;

namespace DahiraAgency.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Destination> _destinationRepository;

        public AdminService(IRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<IEnumerable<Destination>> GetAllDestinationsForAdminAsync()
        {
            return await _destinationRepository.GetAllAsync();
        }

        public async Task CreateDestinationAsync(Destination destination)
        {
            await _destinationRepository.AddAsync(destination);
        }

        public async Task EditDestinationAsync(Destination updatedDestination)
        {
            var existingDestination = await _destinationRepository.GetByIdAsync(updatedDestination.Id);
            if (existingDestination != null)
            {
                existingDestination.Name = updatedDestination.Name;
                existingDestination.Description = updatedDestination.Description;
                existingDestination.CategoryId = updatedDestination.CategoryId;

                await _destinationRepository.UpdateAsync(existingDestination);
            }
        }

        public async Task DeleteDestinationAsync(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            if (destination != null)
            {
                await _destinationRepository.DeleteAsync(destination);
            }
        }
    }
}
