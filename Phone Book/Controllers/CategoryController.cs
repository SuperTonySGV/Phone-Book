using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book.Controllers;

internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ContactContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ContactContext();
        db.Remove(category);
        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ContactContext();
        var categories = db.Category
            .Include(x => x.Contacts)
            .ToList();
        return categories;
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new ContactContext();
        db.Update(category);
        db.SaveChanges();
    }
}
