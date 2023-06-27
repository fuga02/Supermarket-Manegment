using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class TransactionRepository:ITransactionRepository
{
    private readonly MarketContext _marketContext;

    public TransactionRepository(MarketContext marketContext)
    {
        _marketContext = marketContext;
    }

    public IEnumerable<Transaction>? Get(string cashierName)
    {
        return _marketContext.Transactions.ToList();
    }

    public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
                return _marketContext.Transactions.Where(t => t.TimeStamp == date);
        return _marketContext.Transactions.Where(t =>
                t.CashierName.ToLower() ==  cashierName.ToLower()
                &&
                t.TimeStamp == date.Date
            );
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return _marketContext.Transactions!.Where(
                x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        else
            return _marketContext.Transactions!.Where(x =>
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
    }

    public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        var transaction = new Transaction()
        {
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            CashierName = cashierName
        };
        _marketContext.Transactions.Add(transaction);
        _marketContext.SaveChanges();
    }
}