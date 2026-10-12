using System.Xml.Linq;
using CurrencyConverter.Model;

namespace CurrencyConverter.DataAccess.Parsers;

public class NBPXMLParser:IParser
{
    public void Parse(string data, ICurrencyCollection collection)
    {
        try
        {
            XDocument doc = XDocument.Parse(data);
            var descendants = doc.Descendants();
            foreach (var descendant in descendants)
            {
                if (descendant.Name.LocalName != "pozycja") {continue;}
                string name = descendant.Elements("nazwa_waluty").First().Value;
                string code = descendant.Elements("kod_waluty").First().Value;
                string multiplier_str = descendant.Elements("przelicznik").First().Value;
                string rate_str = descendant.Elements("kurs_sredni").First().Value;
                
                var format = new System.Globalization.NumberFormatInfo
                {
                    NumberDecimalSeparator = ","
                };
                decimal rate = decimal.Parse(rate_str, format);
                decimal multiplier = decimal.Parse(multiplier_str, format);
                
                collection.Add(new Currency(name, code, rate, multiplier));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}