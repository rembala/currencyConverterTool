using ConverterCurrencyAPP.Application.Interfaces.Services;
using ConverterCurrencyAPP.Application.Queries.Requests;
using ConverterCurrencyAPP.Application.Queries.Responses;
using ConverterCurrencyAPP.Application.Validation.Interfaces;
using MediatR;

namespace ConverterCurrencyAPP.Application.Handlers
{
    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrencyRequest, CurrencyResponse>
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyValidation _currencyValidation;

        public GetCurrenciesQueryHandler(ICurrencyService currencyService, ICurrencyValidation currencyValidation)
        {
            _currencyService = currencyService;
            _currencyValidation = currencyValidation;
        }

        public async Task<CurrencyResponse> Handle(GetCurrencyRequest request, CancellationToken cancellationToken)
        {
            var currencies = _currencyService.GetCurrenciesFromFile();

            var errors = _currencyValidation.GetRateValidationErrors(currencies);

            if (errors.Any())
            {
                var responseWithErrros = new CurrencyResponse { Errors = errors };

                return await Task.FromResult(responseWithErrros);
            }

            var response = new CurrencyResponse { Currencies = currencies };

            return await Task.FromResult(response);
        }
    }
}
