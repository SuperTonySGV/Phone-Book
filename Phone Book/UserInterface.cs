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
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddContact,
                    MenuOptions.AddCategory,
                    MenuOptions.DeleteContact,
                    MenuOptions.DeleteCategory,
                    MenuOptions.UpdateContact,
                    MenuOptions.UpdateCategory,
                    MenuOptions.ViewContact,
                    MenuOptions.ViewAllContacts,
                    MenuOptions.ViewAllCategories,
                    MenuOptions.SendEmail,
                    MenuOptions.Quit));

            switch (option)
            {
                case MenuOptions.AddContact:
                    ContactService.InsertContact();
                    break;
                case MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case MenuOptions.DeleteContact:
                    ContactService.DeleteContact();
                    break;
                case MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case MenuOptions.UpdateContact:
                    ContactService.UpdateContact();
                    break;
                case MenuOptions.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case MenuOptions.ViewContact:
                    ContactService.GetContact();
                    break;
                case MenuOptions.ViewAllContacts:
                    ContactService.GetContacts();
                    break;
                case MenuOptions.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case MenuOptions.SendEmail:
                    EmailService.SendEmail();
                    break;
                case MenuOptions.Quit:
                    isAppRunning = false;
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
}
