using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherData> GetWeatherForecastAsync(string locationISO)
        {
            // Mocking a weather API response
            var mockWeatherData = new WeatherData
            {
                LocationISO = locationISO,
                LocationName = "Mock City",
                Description = "Sunny",
                Days = new List<WeatherDay>
                {
                    new WeatherDay { Date = "2024-01-01", TempMin = 10, TempMax = 20 }
                }
            };
            return await Task.FromResult(mockWeatherData);
        }
    }
}
