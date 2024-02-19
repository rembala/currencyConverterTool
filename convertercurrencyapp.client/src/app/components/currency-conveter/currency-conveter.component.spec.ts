import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyConveterComponent } from './currency-conveter.component';

describe('CurrencyConveterComponent', () => {
  let component: CurrencyConveterComponent;
  let fixture: ComponentFixture<CurrencyConveterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CurrencyConveterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CurrencyConveterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
