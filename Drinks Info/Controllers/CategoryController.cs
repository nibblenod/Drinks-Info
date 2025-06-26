using System.Net.Http.Headers;
using System.Text.Json;
using Drinks_Info.Models;
namespace Drinks_Info;

public class CategoryController : IDisposable
{
    private static readonly HttpClient _client;

    static CategoryController()
    {
        _client = new HttpClient();
        
    }

    internal async Task<IEnumerable<string>> GetCategories()
    {
        await using Stream stream = await _client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        var repositories = await JsonSerializer.DeserializeAsync<CategoryResponse>(stream);

        return repositories.Categories == null ? new List<string>() : repositories.Categories.Select(arg => arg.category);
    }

    
    

    public void Dispose()
    {
        _client.Dispose();
    }
}