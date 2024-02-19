namespace ConverterCurrencyAPP.Application.Queries.Responses
{
    public class GetConvertedCurrencyRateResponse
    {
        public decimal ConvertedResult { get; set; }

        public List<string> Errors {get; set; } 
    }
}
