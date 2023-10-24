using WeatherApp.Models.ApiModels;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace WeatherApp.Services;

internal class WeatherApiService
{
    private readonly HttpClient _httpClient;

    public WeatherApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
    }

    public async Task<WeatherApiResponse> GetWeatherInformation(string city_name)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        return await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"current?access_key={Constants.API_KEY}&query={city_name}");
    }

}
