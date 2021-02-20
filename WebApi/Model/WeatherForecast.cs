using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi
{
  public class WeatherForecast
  {
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
  }

  public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
  {
    public WeatherForecastValidator()
    {
      RuleFor(c => c.Date).NotEmpty().WithMessage("Lütfen tarih bilgisini boş geçmeyiniz.");
      RuleFor(c => c.TemperatureC).NotEmpty().WithMessage("Lütfen sıcaklık bilgisini boş geçmeyiniz.");
      RuleFor(c => c.TemperatureC).NotEmpty().InclusiveBetween(-90,60).WithMessage("Lütfen sıcaklık bilgisini [-90, 60] aralığında bir değer giriniz.");
    }
  }
}