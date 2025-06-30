using System.Text.Json;
using Drinks_Info.Models;
namespace Drinks_Info;

public class DrinksAPIController : IDisposable
{
    private static readonly HttpClient _client;
    static DrinksAPIController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://www.thecocktaildb.com");
    }

    internal async Task<IEnumerable<string>> GetCategories()
    {
        await using Stream stream = await _client.GetStreamAsync("api/json/v1/1/list.php?c=list");
        var categoriesResponse = await JsonSerializer.DeserializeAsync<Response<Category>>(stream);

        return categoriesResponse.responses == null ? new List<string>() : categoriesResponse.responses.Select(arg => arg.category);
    }

    internal async Task<IEnumerable<string>> GetDrinksFromCategory(string category)
    {
        await using Stream stream =
            await _client.GetStreamAsync($"api/json/v1/1/filter.php?c={category}");
        var drinksResponse = await JsonSerializer.DeserializeAsync<Response<Drink>>(stream);

        return drinksResponse.responses == null ? new List<string>() : drinksResponse.responses.Select(arg => arg.name);
    }

    internal async Task<IEnumerable<DrinkInfo>> GetDrinksInfo(string drinkName)
    {
        await using Stream stream = await _client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drinkName}");
        var drinksResponse = await JsonSerializer.DeserializeAsync<Response<DrinkInfo>>(stream);
          

        return drinksResponse.responses == null ? new List<DrinkInfo>() : drinksResponse.responses;
    }
    
    public void Dispose()
    {
        _client.Dispose();
    }
}