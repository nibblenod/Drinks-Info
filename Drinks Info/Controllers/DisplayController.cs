
using Spectre.Console;

namespace Drinks_Info;

public class DisplayController
{
    internal void PrintMessage(string message)
    {
        AnsiConsole.Markup(message);
    }

    internal void DisplayTable(IEnumerable<string> Items)
    {
        Table table = new Table();
        table.ShowRowSeparators();
        table.AddColumn("Drink Categories");

        foreach (string item in Items)
        {
            table.AddRow(item);
        }
        
        AnsiConsole.Write(table);
    }

    internal string selectFrom(IEnumerable<string> Items)
    {
        string category = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a category of drinks...")
                .AddChoices(Items));

        return category;
    }
   
}