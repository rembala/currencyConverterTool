
using ConverterCurrencyAPP.Domain.Entities;

namespace ConverterCurrencyAPP.Application.Validation.Interfaces
{
    public interface ICurrencyValidation
    {
        List<string> GetCurrencyValidationErrors(string currencyFrom, string currencyTo);

        List<string> GetRateValidationErrors(List<Currency> currencies);
    }
}
