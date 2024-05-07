using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book;

static internal class UserInterface
{
    static internal void ShowContactsTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone Number");

        foreach (var contact in contacts)
        {
            table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.PhoneNumber);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowContact(Contact contact)
    {
        var panel = new Panel($@"Id: {contact.Id} Name: {contact.Name}");
        panel.Header = new PanelHeader("Contact Information");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();
    }
}
