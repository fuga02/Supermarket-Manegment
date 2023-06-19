using CoreBusiness;

namespace UseCases.UseCaseInterfaces;

public interface IViewProductsByCategoryId
{
    public IEnumerable<Product> Execute(int categoryId);
}