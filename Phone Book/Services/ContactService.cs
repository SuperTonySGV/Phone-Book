using Phone_Book.Controllers;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Services;

internal class ContactService
{
    internal static void InsertContact()
    {
        var name = AnsiConsole.Ask<string>("Contact name:");
        var email = AnsiConsole.Ask<string>("Email:");
        var phoneNumber = AnsiConsole.Ask<string>("Phone number:");
        ContactController.AddContact(name, email, phoneNumber);
    }

    internal static void GetContact()
    {
        var contact = GetContactOptionInput();
        UserInterface.ShowContact(contact);
    }

    internal static void GetContacts()
    {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactsTable(contacts);
    }

    internal static void DeleteContact()
    {
        var contact = GetContactOptionInput();
        ContactController.DeleteContact(contact);
    }
    private static Contact GetContactOptionInput()
    {
        var contacts = ContactController.GetContacts();
        var contactsArray = contacts.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a contact")
            .AddChoices(contactsArray));
        var id = contacts.Single(x => x.Name == option).Id;
        var contact = ContactController.GetContactById(id);

        return contact;
    }
}
