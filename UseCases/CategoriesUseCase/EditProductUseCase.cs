using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCase;

public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository _repository;

    public EditProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Product product)
    {
        _repository.UpdateProduct(product);
    }
}