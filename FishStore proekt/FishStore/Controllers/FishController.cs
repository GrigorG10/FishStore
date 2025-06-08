
using Microsoft.AspNetCore.Mvc;
using FishStore.BL.Services.Interfaces;
using FishStore.Models;

namespace FishStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishController : ControllerBase
    {
        private readonly IFishService _fishService;

        public FishController(IFishService fishService)
        {
            _fishService = fishService;
        }

        [HttpGet]
        public async Task<IEnumerable<Fish>> GetAllAsync() => await _fishService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Fish?> GetByIdAsync(Guid id) => await _fishService.GetByIdAsync(id);

        [HttpPost]
        public async Task AddAsync(Fish fish) => await _fishService.AddAsync(fish);

        [HttpPut]
        public async Task UpdateAsync(Fish fish) => await _fishService.UpdateAsync(fish);

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id) => await _fishService.DeleteAsync(id);
    }
}
