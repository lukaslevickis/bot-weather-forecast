using System.Threading.Tasks;
using AdaptiveCards;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWeatherService _weatherService;

        public WeatherController(IUserService userService, IWeatherService weatherService)
        {
            _userService = userService;
            _weatherService = weatherService;
        }

        // GET: api/weather
        [HttpGet]
        public async Task<ActionResult> GetWeather()
        {
            var userId = "616e4dd058eb4e3b9ef9fa87";
            var userProfile = await _userService.GetUserProfileAsync(userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var weatherData = await _weatherService.GetWeatherForecastAsync(userProfile.LocationISO);

            if (weatherData == null)
            {
                return NotFound("Weather data not available.");
            }

            var adaptiveCard = CreateWeatherAdaptiveCard(weatherData);

            return Ok(adaptiveCard.ToJson());
        }

        private AdaptiveCard CreateWeatherAdaptiveCard(WeatherData weatherData)
        {
            var card = new AdaptiveCard("1.2");

            card.Body.Add(new AdaptiveTextBlock
            {
                Text = $"{weatherData.LocationName} - {weatherData.Description}",
                Weight = AdaptiveTextWeight.Bolder,
                Size = AdaptiveTextSize.Large
            });

            foreach (var day in weatherData.Days)
            {
                card.Body.Add(new AdaptiveTextBlock
                {
                    Text = $"{day.Date}: {day.TempMin}°C - {day.TempMax}°C",
                    Size = AdaptiveTextSize.Medium
                });
            }

            return card;
        }
    }
}
