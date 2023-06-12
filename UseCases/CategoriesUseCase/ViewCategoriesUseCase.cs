using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase;

public class ViewCategoriesUseCase : IViewCategoriesUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> Execute()
    {
        return _categoryRepository.GetCategories();
    }
}