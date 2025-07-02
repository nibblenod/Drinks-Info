using Drinks_Info;
using Drinks_Info.Models;


DisplayController displayController = new DisplayController();
using DrinksAPIController drinksApiController = new();

displayController.PrintMessage("Welcome! Press any key to continue to the Drinks Menu...");
Console.ReadLine();
Console.WriteLine();

while (true)
{
    Console.Clear();
    IEnumerable<string> categories = await drinksApiController.GetCategories();
    var categoryList = categories.ToList();
    categoryList.Insert(0, "<Exit>");
    
    string category = displayController.selectFrom(categoryList, "Select a category of drinks...");

    if (category == "<Exit>")
    {
        break;
    }

    while (true)
    {
        Console.Clear();
        IEnumerable<string> drinks = await drinksApiController.GetDrinksFromCategory(category);
        var drinksList = drinks.ToList();
        drinksList.Insert(0, "<Back>");
        string drink = displayController.selectFrom(drinksList, "Select a drink...");

        if (drink == "<Back>")
        {
            break;
        }
        IEnumerable<DrinkInfo> drinkInfos = await drinksApiController.GetDrinksInfo(drink);

        foreach (var drinkInfo in drinkInfos)
        {
            displayController.DisplayDrink(drinkInfo);
        }

        Console.WriteLine("Enter any key to go back...");
        Console.ReadKey();

    }
}



