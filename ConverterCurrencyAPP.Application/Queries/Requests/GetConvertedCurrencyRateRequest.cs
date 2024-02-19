using ConverterCurrencyAPP.Application.Queries.Responses;
using MediatR;

namespace ConverterCurrencyAPP.Application.Queries.Requests
{
    public class GetConvertedCurrencyRateRequest : IRequest<GetConvertedCurrencyRateResponse>
    {
        public string CurrencyFrom { get; set; }

        public string CurrencyTo { get; set; }

        public int Amount { get; set; }
    }
}
