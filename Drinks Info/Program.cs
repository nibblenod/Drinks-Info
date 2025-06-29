using Drinks_Info;
using Drinks_Info.Models;


DisplayController displayController = new DisplayController();
using DrinksAPIController drinksApiController = new();


displayController.PrintMessage("Welcome! Press any key to continue to the Drinks Menu...");
Console.ReadLine();
Console.WriteLine();


IEnumerable<string> categories = await drinksApiController.GetCategories();
string category = displayController.selectFrom(categories, "Select a category of drinks...").Replace(" ", "_");

IEnumerable<string> drinks = await drinksApiController.GetDrinksFromCategory(category);
string drink = displayController.selectFrom(drinks, "Select a drink...").Replace(" ", "_");

IEnumerable<DrinkInfo> drinkInfos = await drinksApiController.GetDrinksInfo(drink);


foreach (var drinkInfo in drinkInfos)
{
    displayController.DisplayDrink(drinkInfo);
    
}
Console.WriteLine();


