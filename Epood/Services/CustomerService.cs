using Epood.Data;
using Epood.Models;
using Microsoft.EntityFrameworkCore;

namespace Epood.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Customer>> List(int page, int pageSize)
        {
            var result = await _context.Customers.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Customer Customer)
        {
            if (Customer.Id == 0)
            {
                _context.Add(Customer);
            }
            else
            {
                _context.Update(Customer);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Customer = await _context.Customers.FindAsync(id);
            if (Customer != null)
            {
                _context.Customers.Remove(Customer);
            }

            await _context.SaveChangesAsync();
        }

        public bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}