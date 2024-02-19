using ConverterCurrencyAPP.Application.Validation;
using ConverterCurrencyAPP.Application.Validation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConverterCurrencyAPP.Application.Common
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<ICurrencyValidation, CurrencyValidation>();

            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));
        }
    }
}
