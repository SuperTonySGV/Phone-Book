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

    internal static List<Category> GetCategories()
    {
        using var db = new ContactContext();
        var categories = db.Category.ToList();
        return categories;
    }

    internal static int GetCategoryById(int id)
    {
        using var db = new ContactContext();
        var category = db.Category.SingleOrDefault(x => x.Id == id);

        return category.Id;
    }
}
