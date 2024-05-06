using Phone_Book.Controllers;
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
            ContactController.AddContact();
            break;
        case MenuOptions.DeleteContact:
            ContactController.DeleteContact();
            break;
        case MenuOptions.UpdateContact:
            ContactController.UpdateContact();
            break;
        case MenuOptions.ViewContact:
            ContactController.GetContactById();
            break;
        case MenuOptions.ViewAllContacts:
            ContactController.GetContacts();
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