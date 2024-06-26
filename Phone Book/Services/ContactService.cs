﻿using Azure;
using Phone_Book.Controllers;
using Phone_Book.Models;
using Phone_Book.Validation;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace Phone_Book.Services;

internal class ContactService
{
    internal static void InsertContact()
    {
        var contact = new Contact();
        contact.Name = AnsiConsole.Ask<string>("Contact name:");
        contact.Email = AnsiConsole.Ask<string>("Email:");
        contact.PhoneNumber = AnsiConsole.Ask<string>("Phone number:");
        contact.CategoryId = CategoryService.GetCategoryOptionInput().Id;
        ContactController.AddContact(contact);
    }

    internal static void UpdateContact()
    {
        var contact = GetContactOptionInput();
        contact.Name = AnsiConsole.Confirm("Update name?") ? AnsiConsole.Ask<string>("What is your new name?") : contact.Name;
        string email = AnsiConsole.Confirm("Update email?") ? AnsiConsole.Ask<string>("What is your new email?") : contact.Email;
        while (!ValidationUtilities.IsValidEmail(email))
        {
            AnsiConsole.Write(new Markup("[bold red]Your email address is invalid. Format should be someemail@email.com[/]\n"));
            email = AnsiConsole.Ask<string>("What is your new email?");
        }
        contact.Email = email;
        string phoneNumber = AnsiConsole.Confirm("Update phone number?") ? AnsiConsole.Ask<string>("What is your new phone number?") : contact.PhoneNumber;
        while (!ValidationUtilities.IsValidPhone(phoneNumber))
        {
            AnsiConsole.Write(new Markup("[bold red]Your phone number is invalid. Format should be ###-###-#### or ##########[/]\n"));
            phoneNumber = AnsiConsole.Ask<string>("What is your new phone number?");
        }
        contact.PhoneNumber = phoneNumber;
        contact.Category = AnsiConsole.Confirm("Update category?") ? CategoryService.GetCategoryOptionInput() : contact.Category;
        ContactController.UpdateContact(contact);
    }

    internal static void GetContact()
    {
        var contact = GetContactOptionInput();
        UserInterface.ShowContact(contact);
    }

    internal static void SendEmail()
    {
        var contact = GetContactOptionInput();
        EmailService.SendEmail();
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
    public static Contact GetContactOptionInput()
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
