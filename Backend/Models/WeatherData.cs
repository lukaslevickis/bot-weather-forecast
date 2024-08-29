using System.Collections.Generic;

namespace Backend.Models
{
    public class WeatherData
    {
        public string LocationISO { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public IList<WeatherDay> Days { get; set; }
    }
}
