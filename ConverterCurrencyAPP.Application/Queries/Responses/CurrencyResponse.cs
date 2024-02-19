using ConverterCurrencyAPP.Domain.Entities;

namespace ConverterCurrencyAPP.Application.Queries.Responses
{
    public class CurrencyResponse
    {
        public List<Currency> Currencies { get; set; }

        public List<string> Errors { get; set; }
    }
}
