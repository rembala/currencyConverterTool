using ConverterCurrencyAPP.Application.Queries.Requests;
using ConverterCurrencyAPP.Application.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConverterCurrencyAPP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ISender _sender;

        public CurrencyConverterController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<CurrencyResponse> GetCurrency()
        {
            var currencies = await _sender.Send(new GetCurrencyRequest { });

            return currencies;
        }

        [HttpPost]
        public async Task<GetConvertedCurrencyRateResponse> ConvertCurrency(string currencyFrom, string currencyTo, int amount)
        {
            var convertedResult = await _sender.Send(new GetConvertedCurrencyRateRequest { 
                CurrencyFrom = currencyFrom,
                CurrencyTo = currencyTo,
                Amount = amount
            });

            return convertedResult;
        }
    }
}
