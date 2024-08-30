using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.Models;

namespace WeatherServices
{
    public interface IWeatherRepository
    {
        public ICollection<WeatherForecast> GetCurrentForecasts(DateOnly startDate, int daysToFetch);
    }
}
