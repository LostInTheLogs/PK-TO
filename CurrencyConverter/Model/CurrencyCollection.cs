namespace CurrencyConverter.Model;

public class CurrencyCollection : ICurrencyCollection
{
    private Dictionary<string, ICurrency> _currencies;

    public CurrencyCollection()
    {
        _currencies = new Dictionary<string, ICurrency>();
        _currencies.Add("PLN", new Currency("Polski złoty", "PLN", 1, 1));
    }

    public void Add(ICurrency currency)
    {
        if (!_currencies.TryAdd(currency.Code, currency))
        {
            _currencies[currency.Code] = currency;
        }
    }

    public void Remove(String code)
    {
        _currencies.Remove(code);
    }

    public ICurrency? Get(string currency)
    {
        if (!_currencies.TryGetValue(currency, out var currencyResult))
        {
            return null;
        }
        return currencyResult;
    }

    public ICurrency[] GetAll()
    {
        return _currencies.Values.ToArray();
    }
}