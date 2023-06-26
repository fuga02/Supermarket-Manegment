using CoreBusiness;
using System;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class TransactionInMemoryRepository:ITransactionRepository
{
    private List<Transaction>? transactions;

    public TransactionInMemoryRepository()
    {
        transactions = new List<Transaction>();
    }

    public IEnumerable<Transaction>? Get(string cashierName)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return transactions;
        if (transactions != null)
            return transactions.Where(
                t => string.Equals(t.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        return null;
    }

    public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            if (transactions != null)
                return transactions.Where(t => t.TimeStamp == date);
        if (transactions != null)
            return transactions.Where(t =>
                string.Equals(t.CashierName, cashierName)
                &&
                t.TimeStamp == date.Date
            );
        return null;
    }

    public void Save(string cashierName,int productId,string productName, double price,int beforeQty, int soldQty)
    {
        int transactionId = 0;
        if (transactions is { Count: > 0 })
        {
            int maxId = transactions.Max(t => t.TransactionId);
            transactionId = maxId + 1;
        }
        else
        {
            transactionId = 1;
        }
        transactions?.Add(new Transaction()
        {
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            TransactionId = transactionId,
            CashierName = cashierName
        });
    }
    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return transactions!.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        else
            return transactions!.Where(x =>
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
    }
}