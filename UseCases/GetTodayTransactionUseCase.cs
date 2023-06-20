using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class GetTodayTransactionUseCase: IGetTodayTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction> Execute(string cashierName)
    {
        return _transactionRepository.GetByDay(cashierName, DateTime.Now);
    }
}