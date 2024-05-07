using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Controllers;

internal class ContactController
{
    internal static void AddContact(string name, string email, string phoneNumber)
    {
        using var db = new ContactContext();
        db.Add(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
        db.SaveChanges();
    }

    internal static void DeleteContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Remove(contact);
        db.SaveChanges();
    }

    internal static Contact GetContactById(int id)
    {
        using var db = new ContactContext();
        var contact = db.Contacts.SingleOrDefault(x => x.Id == id);

        return contact;
    }

    internal static List<Contact> GetContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts.ToList();
        return contacts;
    }

    internal static void UpdateContact()
    {
        throw new NotImplementedException();
    }
}
