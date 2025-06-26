using System.Text.Json.Serialization;
namespace Drinks_Info.Models;

public record Drink([property:JsonPropertyName("strDrink")] string name);