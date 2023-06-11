using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases;
public class AddCategoryUseCase : IAddCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    public AddCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Category category)
    {
        _repository.AddCategory(category);
    }
}