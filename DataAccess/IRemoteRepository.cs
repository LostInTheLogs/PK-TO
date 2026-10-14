namespace CurrencyConverter.DataAccess;

public interface IRemoteRepository
{
    public Task<string> GetData();
}