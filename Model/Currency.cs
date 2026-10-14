namespace CurrencyConverter.Model;

public class Currency(string name, string code, decimal rate, decimal multiplier)
    : ICurrency
{
    public string Name { get; set; } = name;
    public string Code { get; set; } = code;
    public decimal Rate { get; set; } = rate;
    public decimal Multiplier { get; set; } = multiplier;

    public override string ToString()
    {
        return $"{Code} ({Name}) - {Rate} ({Multiplier})";
    }
}