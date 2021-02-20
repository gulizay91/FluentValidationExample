using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ApiContext apiContext;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ApiContext apiContext, ILogger<WeatherForecastController> logger)
    {
      this.apiContext = apiContext;
      _logger = logger;
    }

    [HttpGet]
    [Route("GetWeatherForecastList")]
    public IActionResult GetWeatherForecastList()
    {
      List<WeatherForecast> categories = apiContext.GetWeatherForecastsAsync();
      return Ok(categories);
    }

    [HttpPost]
    [Route("SaveWeatherAsync")]
    public async Task<IActionResult> SaveWeatherAsync([FromBody] WeatherForecast model)
    {
      await apiContext.AddAsync(model);
      return new JsonResult(new { ResponseMessage = "success" });
    }

  }
}