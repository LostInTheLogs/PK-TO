using CurrencyConverter.Model;

namespace CurrencyConverter;

public class CurrencyExchanger: ICurrencyExchanger
{
    public decimal Exchange(ICurrency from, ICurrency to, decimal amount)
    {
        var m1 = from.Rate / from.Multiplier;
        var m2 = to.Rate / to.Multiplier;
        return m1/m2 * amount;
    }
}