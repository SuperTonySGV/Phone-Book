using Phone_Book;
using Phone_Book.Controllers;
using Phone_Book.Services;
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
            ContactService.InsertContact();
            break;
        case MenuOptions.DeleteContact:
            ContactService.DeleteContact();
            break;
        case MenuOptions.UpdateContact:
            ContactService.UpdateContact();
            break;
        case MenuOptions.ViewContact:
            ContactService.GetContact();
            break;
        case MenuOptions.ViewAllContacts:
            ContactService.GetContacts();
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