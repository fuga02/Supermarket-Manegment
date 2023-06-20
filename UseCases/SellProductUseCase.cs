using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class SellProductUseCase: ISellProductUseCase
{
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Execute(int productId, int? qytToSell)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null) { return;}
        product.Quantity -= qytToSell;
        _productRepository.UpdateProduct(product);
    }
}