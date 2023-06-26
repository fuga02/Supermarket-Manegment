using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction>? Get(string cashierName);
    IEnumerable<Transaction> GetByDay( string cashierName,DateTime date);
    IEnumerable<Transaction> Search( string cashierName,DateTime startDate, DateTime endDate);
    void Save(string cashierName ,int productId, string productName, double price, int beforeQty,int soldQty);
}