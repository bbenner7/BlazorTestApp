using WeatherServices.Models;

namespace WeatherServices
{
    public interface IWeatherRepository
    {
        #region Public Methods

        public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int daysToFetch);

        #endregion Public Methods
    }
}