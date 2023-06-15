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

    public void AddProduct(Product product)
    {
        var check = products.Any(c => c.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
        if (check)
            return;

        if (products is { Count: > 0 })
        {

            var maxId = products.Max(c => c.ProductId);
            product.ProductId = maxId + 1;
        }
        else
        {
            product.ProductId = 1;
        }

        products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = GetProductById(product.ProductId);
        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity; 
        }
    }

    public Product GetProductById(int productId)
    {
        return products.FirstOrDefault(p => p.ProductId == productId)!;
    }

    public void DeleteProductById(int productId)
    {
        var product = GetProductById(productId);
        if (product != null)
        {
            products.Remove(product);
        }
    }
}