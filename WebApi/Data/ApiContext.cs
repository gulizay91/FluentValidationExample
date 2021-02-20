using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Data
{
  public class ApiContext : DbContext
  {
    private static readonly string[] Summaries = new[]
    {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public ApiContext(DbContextOptions options) : base(options)
    {
      LoadWeatherForecasts();
    }

    public void LoadWeatherForecasts()
    {
      var rng = new Random();
      List<WeatherForecast> list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Id = index,
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-90, 60),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToList();
      list.ForEach(async r => { await WeatherForecasts.AddAsync(r); });
    }

    public List<WeatherForecast> GetWeatherForecastsAsync() => WeatherForecasts.Local.ToList();
  }
}
