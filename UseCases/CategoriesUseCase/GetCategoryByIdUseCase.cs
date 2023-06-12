using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCase;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Category Execute(int categoryId)
    {
        return _categoryRepository.GetCategoryById(categoryId);
    }
}