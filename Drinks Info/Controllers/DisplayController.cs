using System.Text;
using Spectre.Console;
using Drinks_Info.Models;
namespace Drinks_Info;

public class DisplayController
{
    internal void PrintMessage(string message)
    {
        AnsiConsole.Markup(message);
    }
    internal string selectFrom(IEnumerable<string> items, string title)
    {
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(items));

        return selection;
    }

    internal void DisplayDrink(DrinkInfo drinkInfo)
    {
        var table = new Table();
        table.ShowRowSeparators();

        table.AddColumn($"[steelblue1]{drinkInfo.StrDrink}[/]");
        table.AddColumn($"[palegreen3]Details[/]");
        
        
        

        table.AddRow("ID", drinkInfo.IdDrink);
        table.AddRow("Alcoholic" , drinkInfo.StrAlcoholic);
        table.AddRow("Category" , drinkInfo.StrCategory);
        table.AddRow("Glass", drinkInfo.StrGlass);
        table.AddRow("Instructions" , drinkInfo.StrInstructions);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < drinkInfo.Ingredients.Count; i++)
        {
            sb.Append($"{drinkInfo.Ingredients[i].Name} : {drinkInfo.Ingredients[i].Measure}");

            if (i != drinkInfo.Ingredients.Count - 1)
            {
                sb.Append(", ");
            }
            
        }
        
        table.AddRow("Ingredients", sb.ToString());

        AnsiConsole.Write(table);

    }
   
}