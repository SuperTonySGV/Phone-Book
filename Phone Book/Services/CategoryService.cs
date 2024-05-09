using Phone_Book.Controllers;
using Phone_Book.Models;
using Phone_Book.Validation;
using Spectre.Console;

namespace Phone_Book.Services;

internal class CategoryService
{
    internal static void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("What is the category name?");
        CategoryController.AddCategory(category);
    }

    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();
        category.Name = AnsiConsole.Ask<string>("New category name?");
        CategoryController.UpdateCategory(category);
    }

    internal static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(category);
    }

    internal static void GetCategory()
    {
        var category = GetCategoryOptionInput();
        UserInterface.ShowCategory(category);
    }

    internal static void GetCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }

    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a category")
            .AddChoices(categoriesArray));
        var category = categories.Single(x => x.Name == option);

        return category;
    }
}
