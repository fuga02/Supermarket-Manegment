using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class AddProductUseCase : IAddProductUseCase
{
    private readonly IProductRepository _repository;

    public AddProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Product product)
    {
        _repository.AddProduct(product);
    }
}