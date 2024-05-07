using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Controllers;

internal class ContactController
{
    internal static void AddContact()
    {
        var name = AnsiConsole.Ask<string>("Contact name:");
        var email = AnsiConsole.Ask<string>("Email:");
        var phoneNumber = AnsiConsole.Ask<string>("Phone number:");
        using var db = new ContactContext();
        db.Add(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
        db.SaveChanges();
    }

    internal static void DeleteContact()
    {
        throw new NotImplementedException();
    }

    internal static void GetContactById()
    {
        throw new NotImplementedException();
    }

    internal static void GetContacts()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateContact()
    {
        throw new NotImplementedException();
    }
}
