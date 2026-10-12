using CurrencyConverter.Model;

namespace CurrencyConverter.DataAccess.Parsers;

public interface IParser
{
    public void Parse(string data, ICurrencyCollection collection);
}