using System.Text.Json.Serialization;

namespace Drinks_Info.Models;


[JsonConverter(typeof(IngredientConverter))]
public record DrinkInfo
{
    public string IdDrink { get; set; }
    public string StrDrink { get; set; }
    public string StrCategory { get; set; }
    public string StrAlcoholic { get; set; }
    public string StrGlass { get; set; }

    public string StrInstructions { get; set; }
    public List<Ingredient> Ingredients { get; set; }

};

