
using FishStore.Models;
using System.Net.Http.Json;

namespace FishStore.BL.External
{
    public class ExternalFishApiService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<List<FishExternalModel>> GetExternalFishSuppliersAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/users";
            var response = await _httpClient.GetFromJsonAsync<List<FishExternalModel>>(url);
            return response ?? new List<FishExternalModel>();
        }
    }
}
