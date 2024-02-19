
using ConverterCurrencyApp.Infrastructure.Services;
using ConverterCurrencyAPP.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConverterCurrencyApp.Infrastructure.Common
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();

            return services;
        }
    }
}
