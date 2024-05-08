using System.Text.RegularExpressions;

namespace Phone_Book.Validation;

public static class ValidationUtilities
{
    public static bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidPhone(string Phone)
    {
        try
        {
            if (string.IsNullOrEmpty(Phone)) return false;
            var r = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return r.IsMatch(Phone);

        }
        catch (Exception)
        {
            throw;
        }
    }
}
