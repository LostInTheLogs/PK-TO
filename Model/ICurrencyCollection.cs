namespace CurrencyConverter.Model;

public interface ICurrencyCollection
{
    public void Add(ICurrency currency);
    public void Remove(string code);
    public ICurrency? Get(string code);
    public ICurrency[] GetAll();
}