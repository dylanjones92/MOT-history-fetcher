using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace MotHistoryFetcher
{

    public class MotHistoryService
    {
        private readonly HttpClient _httpClient;

        public MotHistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<MotHistory>?> SearchByRegistrationAsync(string registrationNumber)
        {
            try
            {
                registrationNumber = string.Concat(registrationNumber.Where(c => !Char.IsWhiteSpace(c)));
                var response = await _httpClient.GetAsync($"trade/vehicles/mot-tests?registration={registrationNumber}");
                if (response.IsSuccessStatusCode)
                {
                    var motHistory = await response.Content.ReadFromJsonAsync<List<MotHistory>>();
                    return motHistory ?? new List<MotHistory>();
                }
                else
                {
                    // Other error response
                    var errorResponse = await response.Content.ReadFromJsonAsync<MotHistoryErrorResponse>();
                    if (response.StatusCode == HttpStatusCode.NotFound && ((errorResponse?.ErrorMessage?.StartsWith("No MOT Tests found with vehicle registration")) ?? false))
                    {
                        return new List<MotHistory>();
                    }
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        return null;
                    }
                    throw new HttpRequestException($"HTTP Error {response.StatusCode}: {errorResponse?.ErrorMessage ?? "Unknown error"}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("An unexpected error occurred while processing the request.", ex);
            }
            
        }
    }

}
