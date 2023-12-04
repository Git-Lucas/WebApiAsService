using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace WebApiAsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            string json = System.IO.File.ReadAllText("appsettings.json");

            dynamic objAppSettings = JsonConvert.DeserializeObject<ExpandoObject>(json)!;
            return objAppSettings.Identifier;
        }
    }
}