using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherServices.Data;
using WeatherServices.Services;

namespace WeatherServices
{
    public static class WeatherServicesExtensions
    {
        #region Public Methods

        public static IServiceCollection AddWeatherServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContextPool<WeatherForecastDbContext>(options =>
                {
                    options
                        .UseNpgsql(configuration.GetConnectionString("WeatherForecasts"))
                        .UseSnakeCaseNamingConvention();
                })
                .AddScoped<IWeatherRepository, WeatherDatabase>()
                .AddScoped<IWeatherService, WeatherService>();
        }

        #endregion Public Methods
    }
}