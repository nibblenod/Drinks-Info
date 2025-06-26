using Drinks_Info;

DisplayController displayController = new DisplayController();
using CategoryController categoryController = new();
displayController.PrintMessage("Welcome! Press any key to continue to the Drinks Menu...");
Console.ReadLine();
Console.WriteLine();
IEnumerable<string> categories = await categoryController.GetCategories();

string category = displayController.selectFrom(categories).Replace(" ", "_");


