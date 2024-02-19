using ConverterCurrencyAPP.Domain.Entities;

namespace ConverterCurrencyAPP.Application.Interfaces.Services
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrenciesFromFile();

        decimal GetConvertedValue(string to, int amount, List<Currency> currencies);
    }
}
