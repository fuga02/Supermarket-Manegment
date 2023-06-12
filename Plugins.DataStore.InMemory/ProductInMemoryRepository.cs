using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class ProductInMemoryRepository:IProductRepository
{
    private List<Product> products;

    public ProductInMemoryRepository()
    {
        products = new List<Product>()
        {
            new Product(){ProductId = 1, CategoryId = 1, Name = "Ice tea", Quantity = 100, Price = 1.99},
            new Product(){ProductId = 2, CategoryId = 1, Name = "Canada  Dry", Quantity = 200, Price = 1.99},
            new Product(){ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50},
            new Product(){ProductId = 4, CategoryId = 2, Name = "White Bread ", Quantity = 300, Price = 1.50}
        };
    }
    public IEnumerable<Product> GetProducts()
    {
        return products;
    }
}