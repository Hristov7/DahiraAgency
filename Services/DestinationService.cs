using DahiraAgency.Data;
using DahiraAgency.Data.Interfaces;
using DahiraAgency.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DahiraAgency.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository<Destination> _destinationRepository;

        public DestinationService(IRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<IEnumerable<Destination>> GetAllDestinationsAsync(string searchTerm = null, int page = 1, int pageSize = 10)
        {
            var query = _destinationRepository.Query();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(d => d.Name.Contains(searchTerm) || d.Description.Contains(searchTerm));

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Destination> GetDestinationByIdAsync(int id)
        {
            return await _destinationRepository.GetByIdAsync(id);
        }

        public async Task AddDestinationAsync(Destination destination)
        {
            await _destinationRepository.AddAsync(destination);
        }

        public async Task UpdateDestinationAsync(Destination destination)
        {
            await _destinationRepository.UpdateAsync(destination);
        }

        public async Task DeleteDestinationAsync(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);
            if (destination != null)
            {
                await _destinationRepository.DeleteAsync(destination);
            }
        }

        public async Task<int> GetTotalCountAsync(string searchTerm = null)
        {
            var query = _destinationRepository.Query();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(d => d.Name.Contains(searchTerm) || d.Description.Contains(searchTerm));

            return await query.CountAsync();
        }
    }
}
