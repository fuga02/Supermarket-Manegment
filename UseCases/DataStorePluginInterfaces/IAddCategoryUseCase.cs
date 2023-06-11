using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IAddCategoryUseCase
{
    void Execute(Category category);
}