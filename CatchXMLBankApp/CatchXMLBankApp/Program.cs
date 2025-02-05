using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Введите код валюты (например, USD, EUR):");
        string currencyCode = Console.ReadLine().ToUpper();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        // Запрос котировок валют
        string url = "https://www.cbr.ru/scripts/XML_daily.asp?date_req=" + DateTime.Today.ToString();
        using HttpClient client = new HttpClient();

        try
        {
            // Получение XML
            var response = await client.GetStringAsync(url);
            XDocument doc = XDocument.Parse(response.ToString());
            var currency = doc.Descendants("Valute").FirstOrDefault(v => v.Element("CharCode")?.Value == currencyCode);

            if (currency != null)
            {
                // Формирование ответа
                string name = currency.Element("Name")?.Value;
                string value = currency.Element("Value")?.Value;
                Console.WriteLine($"На момент {DateTime.Now} котировка {name} ({currencyCode}): {value} рублей.");
            }
            else
            {
                Console.WriteLine("Валюта не найдена.");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Ошибка при запросе данных: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка: {e.Message}");
        }
    }
}