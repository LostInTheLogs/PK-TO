using CurrencyConverter.Model;

namespace CurrencyConverter;

public interface ICurrencyExchanger
{
    public decimal Exchange(ICurrency from, ICurrency to, decimal amount);
}