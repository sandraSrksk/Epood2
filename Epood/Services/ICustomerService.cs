using Epood.Data;
using Epood.Models;

namespace Epood.Services
{
    public interface ICustomerService
    {
        Task<PagedResult<Customer>> List(int page, int pageSize);
        Task<Customer> GetById(int id);
        Task Save(Customer Customer);
        Task Delete(int id);
        bool CustomerExists(int id);
    }
}
