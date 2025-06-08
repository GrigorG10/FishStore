
using FishStore.Models;

namespace FishStore.DL.Repositories.Interfaces
{
    public interface IFishRepository
    {
        Task<IEnumerable<Fish>> GetAllAsync();
        Task<Fish?> GetByIdAsync(Guid id);
        Task AddAsync(Fish fish);
        Task UpdateAsync(Fish fish);
        Task DeleteAsync(Guid id);
    }
}
