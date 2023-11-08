using Epood.Data;
using Epood.Models;

namespace Epood.Services
{
    public interface IProductTypeService
    {
        Task<PagedResult<ProductType>> List(int page, int pageSize);
        Task<ProductType> GetById(int id);
        Task Save(ProductType productType);
        Task Delete(int id);
        bool ProductTypeExists(int id);
    }
}
