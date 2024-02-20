import { Component, OnInit } from '@angular/core';
import { CurrencyConveterService } from '../../services/CurrencyConverterService';
import { Currency, CurrencyResponse, GetConvertedCurrencyRateResponse } from '../../models/currencyReponse';
import { environment } from '../../environments/environments';

@Component({
  selector: 'app-currency-conveter',
  templateUrl: './currency-conveter.component.html',
  styleUrl: './currency-conveter.component.css'
})
export class CurrencyConveterComponent implements OnInit {
  
  constructor(private httpService: CurrencyConveterService) { }

  currencies: Currency[] = [];

  selectedCurrencyOne: string = "USD";

  selectedCurrencyTwo: string = "JPY";

  chosenAmount: number = 0;
  
  conversionRate: number = 0;

  convertedResult: number = 0;

  errorMessage: string = "";

  validationErrors = [];

  ngOnInit(): void {
    this.getCurrencies()
    this.fetchCurrencyRatesBasedOnFrequeancy();
  }

  convertCurrencyRate(): void {
    this.httpService
      .convertCurrency(
        this.selectedCurrencyOne,
        this.selectedCurrencyTwo,
        this.chosenAmount
      )
      .subscribe((response) => {
        this.handleConvertCurrencyResponse(response);
      });
  }

  displayConvertedRate(): void {
    const firstSelectedCurrencyRate = this.currencies.find(currency => currency.title == this.selectedCurrencyOne) as Currency;
    const secendSelectedCurrencyRate = this.currencies.find(currency => currency.title == this.selectedCurrencyTwo) as Currency;

    this.conversionRate = secendSelectedCurrencyRate.rate / firstSelectedCurrencyRate.rate;
  }

  private handleConvertCurrencyResponse(response: GetConvertedCurrencyRateResponse) {
    if (response.errors !== null && response.errors.length > 0) {
      this.validationErrors = response.errors;
    } else {
      this.convertedResult = response.convertedResult;
    }
  }

  private getCurrencies() : void {
    this.httpService.getCurrencies().subscribe((response) => {
      this.handleCurrencyResponse(response);
    });
  }

  private handleCurrencyResponse(response: CurrencyResponse) {
    if (response.errors !== null && response.errors.length > 0) {
      this.validationErrors = response.errors;
    } else {
      this.currencies = response.currencies;

      this.displayConvertedRate();
    }
  }

  private fetchCurrencyRatesBasedOnFrequeancy() {
    setInterval(() => this.getCurrencies(), environment.frequency);
  }
}
