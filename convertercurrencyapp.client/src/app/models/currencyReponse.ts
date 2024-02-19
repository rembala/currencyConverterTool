export interface CurrencyResponse{  
    currencies: Currency[]
    errors: [];
}

export interface Currency {
    title: string
    rate: number
}

export interface GetConvertedCurrencyRateResponse {
    convertedResult: number
    errors: [];
}