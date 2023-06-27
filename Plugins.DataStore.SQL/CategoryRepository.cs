using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CategoryRepository: ICategoryRepository
{
    private readonly MarketContext _context;

    public CategoryRepository(MarketContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        var category1 = GetCategoryById(category.CategoryId);
        if (category1 != null)
        {
            category1.Description = category.Description;
            category1.Name = category.Name;
            _context.SaveChanges();
        }
    }

    public Category? GetCategoryById(int categoryId)
    {
       var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
       if (category == null) return null;
       return category;
    }

    public void DeleteCategory(int categoryId)
    {
        var category = GetCategoryById(categoryId);
        if (category != null){ _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}