
using FishStore.DL.Repositories.Interfaces;
using FishStore.Models;
using System.Collections.Concurrent;

namespace FishStore.DL.Repositories
{
    public class FishRepository : IFishRepository
    {
        private static readonly ConcurrentDictionary<Guid, Fish> _fishCache = new();

        public Task<IEnumerable<Fish>> GetAllAsync() => Task.FromResult(_fishCache.Values.AsEnumerable());

        public Task<Fish?> GetByIdAsync(Guid id) => Task.FromResult(_fishCache.TryGetValue(id, out var fish) ? fish : null);

        public Task AddAsync(Fish fish)
        {
            _fishCache[fish.Id] = fish;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Fish fish)
        {
            _fishCache[fish.Id] = fish;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _fishCache.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}
