using ConverterCurrencyAPP.Application.Queries.Responses;
using MediatR;

namespace ConverterCurrencyAPP.Application.Queries.Requests
{
    public class GetCurrencyRequest : IRequest<CurrencyResponse>
    {
        public Guid CorrelationId { get; set; }
    }
}
