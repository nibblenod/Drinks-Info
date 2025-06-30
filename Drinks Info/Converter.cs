using System.Text.Json;
using System.Text.Json.Serialization;
using Drinks_Info.Models;

namespace Drinks_Info;

public class IngredientConverter : JsonConverter<DrinkInfo>
{
    public override DrinkInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonElement jsonObject = JsonDocument.ParseValue(ref reader).RootElement;

        DrinkInfo drinkInfo = new DrinkInfo();

        drinkInfo.IdDrink = jsonObject.GetProperty("idDrink").ToString();
        drinkInfo.StrDrink = jsonObject.GetProperty("strDrink").ToString();
        drinkInfo.StrCategory = jsonObject.GetProperty("strCategory").ToString();
        drinkInfo.StrGlass = jsonObject.GetProperty("strGlass").ToString();
        drinkInfo.StrAlcoholic = jsonObject.GetProperty("strAlcoholic").ToString();
        drinkInfo.StrInstructions = jsonObject.GetProperty("strInstructions").ToString();

        drinkInfo.Ingredients = new List<Ingredient>();
        for (int i = 1; i <= 15; i++)
        {
            string name;
            string measure;
            if (jsonObject.GetProperty($"strIngredient{i}").ToString() != "")
            {
                name = jsonObject.GetProperty($"strIngredient{i}").ToString();
                measure = jsonObject.GetProperty($"strMeasure{i}").ToString() != ""
                    ? jsonObject.GetProperty($"strMeasure{i}").ToString() : "_";
                
                drinkInfo.Ingredients.Add(new Ingredient()
                {   
                    Name = name,
                    Measure = measure,
                });
            }
        }

        return drinkInfo;
    }

    public override void Write(Utf8JsonWriter writer, DrinkInfo value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}