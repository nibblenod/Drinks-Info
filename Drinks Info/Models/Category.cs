using System.Text.Json.Serialization;

namespace Drinks_Info.Models;

public record class Category(
    [property: JsonPropertyName("strCategory")]
    string category);

public record class CategoryResponse(
    [property: JsonPropertyName("drinks")] List<Category> Categories
);
