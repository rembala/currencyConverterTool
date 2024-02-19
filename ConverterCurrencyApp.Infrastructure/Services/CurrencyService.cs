using ConverterCurrencyAPP.Application.Interfaces.Services;
using ConverterCurrencyAPP.Domain.Entities;
using System.Xml;

namespace ConverterCurrencyApp.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        public List<Currency> GetCurrenciesFromFile()
        {
            var filePath = this.GetType().Assembly
                .GetManifestResourceStream("ConverterCurrencyApp.Infrastructure.Common.Files.currencies.xml");

            var reader = new XmlTextReader(filePath);

            var ratesByCurrency = new List<Currency>{ };

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader["currency"] != null && reader["rate"] != null)
                        {
                            ratesByCurrency.Add(new Currency { Rate = decimal.Parse(reader["rate"]), Title = reader["currency"]});
                        }
                        break;
                }
            }

            return ratesByCurrency;
        }

        public decimal GetConvertedValue(string currencyTo, int amount, List<Currency> currencies)
        {
            var currencyToConvert = currencies.First(currency => currencyTo.Equals(currency.Title));

            var convertedResult = currencyToConvert.Rate * amount;

            return convertedResult;
        }
    }
}
