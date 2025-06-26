using Spectre.Console;
namespace Drinks_Info;

public class DisplayController
{
    internal void PrintMessage(string message)
    {
        AnsiConsole.Markup(message);
    }
    internal string selectFrom(IEnumerable<string> Items, string title)
    {
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(Items));

        return selection;
    }
   
}