using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class EditCategoryUseCase : IEditCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    public EditCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Category category)
    {
        _repository.UpdateCategory(category);
    }
}