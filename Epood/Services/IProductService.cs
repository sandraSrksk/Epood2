using Epood.Data;
using Epood.Models;

namespace Epood.Services
{
    public interface IProductService
    {
        Task<PagedResult<Product>> List(int page, int pageSize);
        Task<Product> GetById(int id);
        Task Save(Product Product);
        Task Delete(int id);
        bool ProductExists(int id);
    }
}
