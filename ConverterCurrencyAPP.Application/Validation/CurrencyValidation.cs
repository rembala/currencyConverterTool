using ConverterCurrencyAPP.Application.Interfaces.Services;
using ConverterCurrencyAPP.Application.Validation.Interfaces;
using ConverterCurrencyAPP.Domain.Entities;

namespace ConverterCurrencyAPP.Application.Validation
{
    public class CurrencyValidation : ICurrencyValidation
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyValidation(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public List<string> GetCurrencyValidationErrors(string currencyFrom, string currencyTo)
        {
            var currencies = _currencyService.GetCurrenciesFromFile();

            var currencyFromExists = currencies.Any(currency => currency.Title.Equals(currencyFrom));

            var currencyToExists = currencies.Any(currency => currency.Title.Equals(currencyTo));

            var errors = new List<string>();

            if (!currencyFromExists)
            {
                errors.Add($"{currencyFrom} does not exist");
            }

            if (!currencyToExists)
            {
                errors.Add($"{currencyTo} does not exist");
            }

            return errors;
        }

        public List<string> GetRateValidationErrors(List<Currency> currencies)
        {
            var currencyWithNoRates = currencies
                .Where(currency => currency.Rate == 0)
                .Select(cur => cur.Title)
                .ToList();

            return currencyWithNoRates;
        }
    }
}
