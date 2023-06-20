using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class TransactionInMemoryRepository:ITransactionRepository
{
    private List<Transaction> transactions;

    public TransactionInMemoryRepository()
    {
        transactions = new List<Transaction>();
    }

    public IEnumerable<Transaction> Get(string cashierName)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return transactions;
        else
            return transactions.Where(t => string.Equals(t.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return transactions.Where(t => t.TimeStamp == date.Date);
        else
            return transactions.Where(t => 
                string.Equals(t.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)
                &&
                t.TimeStamp == date.Date
            );
    }

    public void Save(string cashierName,int productId,string productName, double price,int beforeQty, int soldQty)
    {
        int transactionId = 0;
        if (transactions != null && transactions.Count > 0)
        {
            int maxId = transactions.Max(t => t.TransactionId);
            transactionId = maxId + 1;
        }
        else
        {
            transactionId = 1;
        }
        transactions.Add(new Transaction()
        {
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.UtcNow,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            TransactionId = transactionId,
            CashierName = cashierName
        });
    }
}