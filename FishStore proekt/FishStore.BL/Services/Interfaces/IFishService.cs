
using FishStore.Models;

namespace FishStore.BL.Services.Interfaces
{
    public interface IFishService
    {
        Task<IEnumerable<Fish>> GetAllAsync();
        Task<Fish?> GetByIdAsync(Guid id);
        Task AddAsync(Fish fish);
        Task UpdateAsync(Fish fish);
        Task DeleteAsync(Guid id);
    }
}
