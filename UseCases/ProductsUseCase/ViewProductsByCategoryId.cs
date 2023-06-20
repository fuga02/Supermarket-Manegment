using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class ViewProductsByCategoryId : IViewProductsByCategoryId
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByCategoryId(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> Execute(int categoryId)
    {
        return _productRepository.GetProductsByCategoryId(categoryId);
    }
}