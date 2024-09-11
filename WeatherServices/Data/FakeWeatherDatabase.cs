using Microsoft.Extensions.Logging;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Data;

public class FakeWeatherDatabase : IWeatherRepository
{
    #region Private Fields

    private readonly ILogger<FakeWeatherDatabase> _logger;

    #endregion Private Fields

    #region Public Constructors

    public FakeWeatherDatabase(ILogger<FakeWeatherDatabase> logger)
    {
        _logger = logger;
    }

    #endregion Public Constructors

    #region Public Methods

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int daysToFetch)
    {
        var forecasts = Enumerable.Range(1, daysToFetch).Select(index =>
        {
            var temperature = Temperature.FromDegreesCelsius(Random.Shared.Next(-20, 55));
            var summary = WeatherSummary.Create(temperature);
            return new WeatherForecast(startDate.AddDays(index), temperature, summary);
        });
        return new List<WeatherForecast>(forecasts);
    }

    #endregion Public Methods
}