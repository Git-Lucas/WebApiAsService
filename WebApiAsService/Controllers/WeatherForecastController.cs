using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Dynamic;

namespace WebApiAsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly EfSqliteAdapter _context;

        public WeatherForecastController(EfSqliteAdapter context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<WeatherForecast>> GetAll()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }
    }
}