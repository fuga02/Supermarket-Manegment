using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class GetTransactionsUseCase: IGetTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
    {
        return _transactionRepository.Search(cashierName, startDate, endDate);
    }
}