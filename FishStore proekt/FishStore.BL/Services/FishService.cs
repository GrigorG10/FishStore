
using FishStore.BL.Services.Interfaces;
using FishStore.DL.Repositories.Interfaces;
using FishStore.Models;

namespace FishStore.BL.Services
{
    public class FishService : IFishService
    {
        private readonly IFishRepository _fishRepository;

        public FishService(IFishRepository fishRepository)
        {
            _fishRepository = fishRepository;
        }

        public Task<IEnumerable<Fish>> GetAllAsync() => _fishRepository.GetAllAsync();

        public Task<Fish?> GetByIdAsync(Guid id) => _fishRepository.GetByIdAsync(id);

        public Task AddAsync(Fish fish) => _fishRepository.AddAsync(fish);

        public Task UpdateAsync(Fish fish) => _fishRepository.UpdateAsync(fish);

        public Task DeleteAsync(Guid id) => _fishRepository.DeleteAsync(id);
    }
}
