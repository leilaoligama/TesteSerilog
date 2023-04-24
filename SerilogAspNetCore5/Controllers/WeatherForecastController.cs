using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogAspNetCore5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogInformation("WeatherForecastController - iniciando a instância do ILogger");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("endpoint GET -> WeatherForecast.Get()");

            var rng = new Random();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    //if (i == 3)
                    //{
                    //    throw new Exception("Ocorreu um erro: i é igual a 3.");
                    //}
                    //else
                    //{
                        _logger.LogInformation($"Número de iterações {i}");
                    //}
                }
                _logger.LogInformation("entrou no TRY");
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();

            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro...");
            }
        }
    }
}
