using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    Product GetProductById(int productId);
    void DeleteProductById(int productId);
    IEnumerable<Product> GetProductsByCategoryId(int categoryId);
}