namespace CurrencyConverter.Model;

public interface ICurrency
{
    string Name { get; set; }
    string Code { get; set; }
    decimal Rate { get; set; }
    decimal Multiplier { get; set; }

    static decimal Exchange(ICurrency from, ICurrency to, decimal amount)
    {
        var m1 = from.Rate / from.Multiplier;
        var m2 = to.Rate / to.Multiplier;
        return m1/m2 * amount;
    }
}