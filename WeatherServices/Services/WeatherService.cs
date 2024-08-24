using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Services;

public class WeatherService : IWeatherService {
    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int numberOfForecasts)
    {
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast(startDate.AddDays(index), Temperature.FromDegreesCelsius(Random.Shared.Next(-20, 55)),
                summaries[Random.Shared.Next(summaries.Length)]));
        return new List<WeatherForecast>(forecasts);
    }
}