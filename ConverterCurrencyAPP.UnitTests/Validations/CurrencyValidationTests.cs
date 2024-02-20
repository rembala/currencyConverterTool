using ConverterCurrencyAPP.Application.Interfaces.Services;
using ConverterCurrencyAPP.Application.Validation;
using ConverterCurrencyAPP.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace ConverterCurrencyAPP.UnitTests.Validations
{
    public class CurrencyValidationTests
    {
        Mock<ICurrencyService> _currencyServiceMock = new Mock<ICurrencyService>(MockBehavior.Strict);

        [Test]
        public void GetCurrencyValidationErrors_CurrencyFromDoesntExist_ReturnsErrors()
        {
            var currencies = new List<Currency> { 
                new Currency { Rate = 1.2M, Title = "USD"},
                new Currency { Rate = 4.3M, Title = "JPY"},
                new Currency { Rate = 0.212M, Title = "BRL"}
            };

            var currencyFrom = "EUR";
            var currencyTo = "BRL";

            var decisionValidation = _currencyServiceMock
                .Setup(m => m.GetCurrenciesFromFile())
                .Returns(currencies);

            var currencyValidation = new CurrencyValidation(_currencyServiceMock.Object);

            var result = currencyValidation.GetCurrencyValidationErrors(currencyFrom, currencyTo);

            Assert.Contains($"{currencyFrom} currency does not exist", result);
        }

        [Test]
        public void GetCurrencyValidationErrors_CurrencyToDoesntExist_ReturnsErrors()
        {
            var currencies = new List<Currency> {
                new Currency { Rate = 1.2M, Title = "USD"},
                new Currency { Rate = 4.3M, Title = "JPY"},
                new Currency { Rate = 0.212M, Title = "BRL"}
            };

            var currencyFrom = "USD";
            var currencyTo = "EUR";

            var decisionValidation = _currencyServiceMock
                .Setup(m => m.GetCurrenciesFromFile())
                .Returns(currencies);

            var currencyValidation = new CurrencyValidation(_currencyServiceMock.Object);

            var result = currencyValidation.GetCurrencyValidationErrors(currencyFrom, currencyTo);

            Assert.Contains($"{currencyTo} currency does not exist", result);
        }

        [Test]
        public void GetRateValidationErrors_SomeRatesHaveZero_ReturnsErrors()
        {
            var currencies = new List<Currency> {
                new Currency { Rate = 1.2M, Title = "USD"},
                new Currency { Rate = 0, Title = "JPY"},
                new Currency { Rate = 0.212M, Title = "BRL"}
            };

            var decisionValidation = _currencyServiceMock
                .Setup(m => m.GetCurrenciesFromFile())
                .Returns(currencies);

            var currencyWithZero = "JPY";

            var currencyValidation = new CurrencyValidation(_currencyServiceMock.Object);

            var result = currencyValidation.GetRateValidationErrors(currencies);

            Assert.Contains(currencyWithZero, result);
        }
    }
}
