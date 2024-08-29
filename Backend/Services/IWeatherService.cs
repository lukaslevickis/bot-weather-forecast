using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherForecastAsync(string locationISO);
    }
}
