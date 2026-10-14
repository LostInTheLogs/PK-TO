namespace CurrencyConverter.Model;

public class Currency:ICurrency
{
    
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Rate { get; set; }
    public decimal Multiplier { get; set; }

    public Currency(string name, string code, decimal rate, decimal multiplier)
    {
        Name = name;
        Code = code;
        Rate = rate;
        Multiplier = multiplier;
    }
    
    public override string ToString()
    {
        return $"{Code} ({Name}) - {Rate} ({Multiplier})";
    }
}