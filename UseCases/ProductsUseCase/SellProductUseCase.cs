using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IRecordTransactionUseCase _transactionUseCase;
    public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase transactionUseCase)
    {
        _productRepository = productRepository;
        _transactionUseCase = transactionUseCase;
    }

    public void Execute(string cashierName,int productId, int qytToSell)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null) { return; }
        product.Quantity -= qytToSell;
        _productRepository.UpdateProduct(product);
        _transactionUseCase.Execute(cashierName,productId,qytToSell);
    }
}