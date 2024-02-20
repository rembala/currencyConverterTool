using ConverterCurrencyApp.Infrastructure.Services;
using ConverterCurrencyAPP.Domain.Entities;
using NUnit.Framework;

namespace ConverterCurrencyAPP.UnitTests.Services
{
    public class CurrencyServiceUnitTests
    {
        [Test]
        public void GetCurrenciesFromFile_CurrenciesTitlesAreNotEmptyInFile_ShouldReturnFileCorrectly() {
            var currencyService = new CurrencyService();

            var currencies = currencyService.GetCurrenciesFromFile();

            Assert.True(currencies.Select(currency => currency.Title).Count() > 0);
        }

        [Test]
        public void GetCurrenciesFromFile_CurrencyRatesAreNotEmptyInFile_ShouldReturnFileCorrectly()
        {
            var currencyService = new CurrencyService();

            var currencies = currencyService.GetCurrenciesFromFile();

            Assert.True(currencies.Select(currency => currency.Rate).Count() > 0);
        }

        [Test]
        public void GetConvertedCurrencyRate_MultiplyCurrencyTo_ShouldReturnMultipliedValue()
        {
            var currencyService = new CurrencyService();

            var currencies = new List<Currency> {
                new Currency { Rate = 1.2M, Title = "USD"},
                new Currency { Rate = 4.3M, Title = "JPY"},
                new Currency { Rate = 0.212M, Title = "BRL"}
            };

            var currencyTo = "USD";

            var amount = 12; 

            var result = currencyService.GetConvertedCurrencyRate(currencyTo, amount, currencies);

            Assert.That(result, Is.EqualTo(14.4));
        }

        [Test]
        public void GetConvertedCurrencyRate_CurrencyDoesNotExist_ThrowsException()
        {
            var currencyService = new CurrencyService();

            var currencies = new List<Currency> {
                new Currency { Rate = 1.2M, Title = "USD"},
                new Currency { Rate = 4.3M, Title = "JPY"},
                new Currency { Rate = 0.212M, Title = "BRL"}
            };

            var currencyTo = "USD2";

            var amount = 12;

            Assert.Throws<ArgumentException>(() => currencyService.GetConvertedCurrencyRate(currencyTo, amount, currencies));
        }
    }
}
