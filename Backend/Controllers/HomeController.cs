using System.Threading.Tasks;
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
            var userProfile = _userService.GetUserProfileAsync(userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var weatherData = await _weatherService.GetWeatherForecastAsync(userProfile.LocationISO);

            if (weatherData == null)
            {
                return NotFound("Weather data not available.");
            }

            return Ok(weatherData);
        }
    }
}
