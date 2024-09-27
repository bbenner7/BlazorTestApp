using WeatherServices.Models;

namespace WeatherServices.Data;

public class WeatherDatabase(WeatherForecastDbContext weatherForecastDbContext) : IWeatherRepository, IDisposable
{
    #region Private Fields

    private bool _disposed = false;

    #endregion Private Fields

    #region Public Methods

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int daysToFetch)
    {
        return weatherForecastDbContext.WeatherForecasts
            .Where(entity => entity.Date >= startDate)
            .Select(e => e.ToWeatherForecast())
            .Take(daysToFetch)
            .ToList();
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                weatherForecastDbContext.Dispose();
            }
        }
        _disposed = true;
    }

    #endregion Protected Methods
}