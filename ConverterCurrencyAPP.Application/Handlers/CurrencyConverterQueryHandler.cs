using ConverterCurrencyAPP.Application.Interfaces.Services;
using ConverterCurrencyAPP.Application.Queries.Requests;
using ConverterCurrencyAPP.Application.Queries.Responses;
using ConverterCurrencyAPP.Application.Validation.Interfaces;
using MediatR;

namespace ConverterCurrencyAPP.Application.Handlers
{
    public class CurrencyConverterQueryHandler : IRequestHandler<GetConvertedCurrencyRateRequest, GetConvertedCurrencyRateResponse>
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyValidation _currencyValidation;

        public CurrencyConverterQueryHandler(ICurrencyService currencyService, ICurrencyValidation currencyValidation)
        {
            _currencyService = currencyService;
            _currencyValidation = currencyValidation;
        }

        public async Task<GetConvertedCurrencyRateResponse> Handle(GetConvertedCurrencyRateRequest request, CancellationToken cancellationToken)
        {
            var errors = _currencyValidation.GetCurrencyValidationErrors(request.CurrencyFrom, request.CurrencyTo);

            if (errors.Any()) {
                var responseWithErrros = new GetConvertedCurrencyRateResponse { Errors = errors };

                return await Task.FromResult(responseWithErrros);
            }

            var currencies = _currencyService.GetCurrenciesFromFile();

            var result = _currencyService.GetConvertedValue(request.CurrencyTo, request.Amount, currencies);

            var response = new GetConvertedCurrencyRateResponse { ConvertedResult = result };

            return await Task.FromResult(response);
        }
    }
}
