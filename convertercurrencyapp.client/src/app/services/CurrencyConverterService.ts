import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CurrencyResponse, GetConvertedCurrencyRateResponse } from "../models/currencyReponse";

@Injectable()
export class CurrencyConveterService {
  constructor(private http: HttpClient) {}

  getCurrencies() {
    return this.http.get<CurrencyResponse>('/currencyconverter');
  }

  convertCurrency(currencyOne: string, currencyTwo: string, amount: number) {
    return this.http.post<GetConvertedCurrencyRateResponse>(`/currencyconverter?currencyFrom=${currencyOne}&currencyTo=${currencyTwo}&amount=${amount}`, null);
  }
}
