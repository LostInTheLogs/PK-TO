using CurrencyConverter.DataAccess;
using CurrencyConverter.DataAccess.Model;
using CurrencyConverter.DataAccess.Parsers;
using CurrencyConverter.Model;

namespace CurrencyConverter;

class Program
{
    static async Task Main(string[] args)
    {
        IRemoteRepository repository = new NBPRemoteRepository();
        IParser parser = new NBPXMLParser();
        ICurrencyCollection collection = new CurrencyCollection();
        
        var data = await repository.GetData();
        parser.Parse(data, collection);
        
        Console.WriteLine("Current rates: ");
        foreach (var currency in collection.GetAll())
        {
            Console.WriteLine(currency.ToString());
        }

        ICurrency from = null;
        while (true)
        {
            Console.Write("Source currency: ");
            string sourceCode = Console.ReadLine().Trim();
            from = collection.Get(sourceCode);
            if (from == null)
            {
                Console.WriteLine($"Currency '{sourceCode}' not found.");
            }
            else
            {
                break;
            }
        }
        
        ICurrency to = null;
        while (true)
        {
            Console.Write("Target currency: ");
            string targetCode = Console.ReadLine().Trim();
            to = collection.Get(targetCode);
            if (to == null)
            {
                Console.WriteLine($"Currency '{targetCode}' not found.");
            }
            else
            {
                break;
            }
        }

        decimal amount;
        while (true)
        {
            Console.Write("Amount: ");
            string str = Console.ReadLine().Trim();
            if (!decimal.TryParse(str, out amount))
            {
                Console.WriteLine($"Wrong amount!");
            }
            else
            {
                break;
            }
        }

        var result = ICurrency.Exchange(from, to, amount);
        Console.WriteLine($"Wynik: {result} {to.Code}");

    }
}