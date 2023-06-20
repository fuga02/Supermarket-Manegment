using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class RecordTransactionUseCase: IRecordTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IGetProductByIdUseCase _getProduct;
    public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase getProduct)
    {
        _transactionRepository = transactionRepository;
        _getProduct = getProduct;
    }

    public void Execute(string cashierName, int productId, int soldQty)
    {
        var product = _getProduct.Execute(productId);
         _transactionRepository.Save(cashierName,productId, product.Name,product.Price!.Value,product.Quantity!.Value,soldQty);
    }
}