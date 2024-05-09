using Phone_Book.Models;
using Phone_Book.Services;
using Spectre.Console;
using static Phone_Book.Enums;

namespace Phone_Book;

static internal class UserInterface
{
    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MainMenuOptions.ManageContacts,
                    MainMenuOptions.ManageCategories,
                    MainMenuOptions.SendEmail,
                    MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ManageContacts:
                    ContactsMenu();
                    break;
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.SendEmail:
                    EmailService.SendEmail();
                    break;
                case MainMenuOptions.Quit:
                    isAppRunning = false;
                    break;
            }
        }
    }

    static internal void ContactsMenu()
    {
        var isContactsMenuRunning = true;
        while (isContactsMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ContactMenu>()
                .Title("What would you like to do?")
                .AddChoices(
                    ContactMenu.AddContact,
                    ContactMenu.DeleteContact,
                    ContactMenu.UpdateContact,
                    ContactMenu.ViewContact,
                    ContactMenu.ViewAllContacts,
                    ContactMenu.GoBack));

            switch (option)
            {
                case ContactMenu.AddContact:
                    ContactService.InsertContact();
                    break;
                case ContactMenu.DeleteContact:
                    ContactService.DeleteContact();
                    break;
                case ContactMenu.UpdateContact:
                    ContactService.UpdateContact();
                    break;
                case ContactMenu.ViewContact:
                    ContactService.GetContact();
                    break;
                case ContactMenu.ViewAllContacts:
                    ContactService.GetContacts();
                    break;
                case ContactMenu.GoBack:
                    MainMenu();
                    break;
            }
        }
    }
    
    static internal void CategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>()
                .Title("What would you like to do?")
                .AddChoices(
                    CategoryMenu.AddCategory,
                    CategoryMenu.DeleteCategory,
                    CategoryMenu.UpdateCategory,
                    CategoryMenu.ViewCategory,
                    CategoryMenu.ViewAllCategories,
                    CategoryMenu.GoBack));

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case CategoryMenu.GoBack:
                    MainMenu();
                    break;
            }
        }
    }

    static internal void ShowContactsTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone Number");
        table.AddColumn("Category");

        foreach (var contact in contacts)
        {
            table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.PhoneNumber, contact.Category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.Id.ToString(), category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowContact(Contact contact)
    {
        var panel = new Panel($"Id: {contact.Id}\nName: {contact.Name}\nEmail: {contact.Email}\nPhone Number: {contact.PhoneNumber}\nCategory Name: {contact.Category.Name}");
        panel.Header = new PanelHeader("Contact Information");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowCategory(Category category)
    {
        var panel = new Panel($"Id: {category.Id}\nName: {category.Name}\nContact Count: {category.Contacts.Count}");
        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowContactsTable(category.Contacts);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }
}
