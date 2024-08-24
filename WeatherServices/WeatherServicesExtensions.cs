using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WeatherServices.Services;

namespace WeatherServices
{
    public static class WeatherServicesExtensions
    {
        public static IServiceCollection AddWeatherServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            return services;
        }
    }
}
