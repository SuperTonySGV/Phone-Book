using System.Net.Mail;
using System.Net;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Phone_Book.Services
{
    internal class EmailService
    {
        public static void SendEmail()
        {
            var contact = ContactService.GetContactOptionInput();
            var fromAddress = new MailAddress("cougarkid@gmail.com", "Anthony F");
            var toAddress = new MailAddress(contact.Email, contact.Name);
            const string fromPassword = "yfye ddeq pdbj outl";
            const string subject = "Subject2";
            const string body = "Body2";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                Console.WriteLine("Email sent successfully. Press any key to continue.");
                Console.ReadLine();
            }
        }
    }
}