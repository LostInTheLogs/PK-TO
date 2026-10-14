using System.Net;
using System.Text;

namespace CurrencyConverter.DataAccess.Model;

public class NBPRemoteRepository : IRemoteRepository
{
    private static NBPRemoteRepository instance = new NBPRemoteRepository();
    HttpClient client = new HttpClient();

    private NBPRemoteRepository()
    {
    }

    public static NBPRemoteRepository GetInstance()
    {
        return instance;
    }
    
    public async Task<string> GetData()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        try
        {
            byte[] dataBytes = await client.GetByteArrayAsync("https://static.nbp.pl/dane/kursy/xml/LastA.xml");

            Encoding enc = Encoding.GetEncoding("ISO-8859-2");
            return enc.GetString(dataBytes);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: ");
            Console.WriteLine(e);
            throw;
        }
    }
}