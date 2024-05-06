﻿using Phone_Book;
using Spectre.Console;


var isAppRunning = true;
while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("What would you like to do?")
        .AddChoices(
            MenuOptions.AddContact,
            MenuOptions.DeleteContact,
            MenuOptions.UpdateContact,
            MenuOptions.ViewContact,
            MenuOptions.ViewAllContacts,
            MenuOptions.Quit));

    switch(option)
    {
        case MenuOptions.AddContact:
            RecordController.AddContact();
            break;
        case MenuOptions.DeleteContact:
            RecordController.DeleteContact();
            break;
        case MenuOptions.UpdateContact:
            RecordController.UpdateContact();
            break;
        case MenuOptions.ViewContact:
            RecordController.GetContactById();
            break;
        case MenuOptions.ViewAllContacts:
            RecordController.GetContacts();
            break;
        case MenuOptions.Quit:
            isAppRunning = false;
            break;
    }
}

enum MenuOptions
{
    AddContact,
    DeleteContact,
    UpdateContact,
    ViewContact,
    ViewAllContacts,
    Quit
}