using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book;

internal class ContactContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=MOTHERSHIP-XR7\\SQLEXPRESS;Initial Catalog=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<Contact> Contacts {  get; set; }
}
