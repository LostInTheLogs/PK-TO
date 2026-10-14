using CurrencyConverter.DataAccess;
using CurrencyConverter.DataAccess.Model;
using CurrencyConverter.DataAccess.Parsers;
using CurrencyConverter.Model;

namespace CurrencyConverter;

class Program
{

    static ICurrency readCurrency(string prompt, ICurrencyCollection collection)
    {
        ICurrency? currency = null;
        
        while (true)
        {
            Console.Write(prompt);
            string targetCode = Console.ReadLine().Trim();
            currency = collection.Get(targetCode);
            if (currency == null)
            {
                Console.WriteLine($"Currency '{targetCode}' not found.");
            }
            else
            {
                break;
            }
        }

        return currency;
    }
    
    static async Task Main(string[] args)
    {
        IRemoteRepository repository = NBPRemoteRepository.GetInstance();
        IParser parser = new NBPXMLParser();
        ICurrencyCollection collection = new CurrencyCollection();
        ICurrencyExchanger exchanger = new CurrencyExchanger();
        
        var data = await repository.GetData();
        parser.Parse(data, collection);
        
        Console.WriteLine("Current rates: ");
        foreach (var currency in collection.GetAll())
        {
            Console.WriteLine(currency.ToString());
        }

        ICurrency from = readCurrency("Source currency: ",  collection);
        ICurrency to = readCurrency("Target currency: ",  collection);

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

        var result = exchanger.Exchange(from, to, amount);
        Console.WriteLine($"Final amount: {result} {to.Code}");

    }
}