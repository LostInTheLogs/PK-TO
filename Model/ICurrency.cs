namespace CurrencyConverter.Model;

public interface ICurrency
{
    string Name { get; set; }
    string Code { get; set; }
    decimal Rate { get; set; }
    decimal Multiplier { get; set; }

}