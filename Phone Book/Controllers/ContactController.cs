﻿using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Controllers;

internal class ContactController
{
    internal static void AddContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Add(contact);
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
        var contact = db.Contacts
            .Include(x => x.Category)
            .SingleOrDefault(x => x.Id == id);

        return contact;
    }

    internal static List<Contact> GetContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts
            .Include(x => x.Category)
            .ToList();
        return contacts;
    }

    internal static void UpdateContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Update(contact);
        db.SaveChanges();
    }
}
