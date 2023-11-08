using Epood.Data;
using Epood.Models;
using Microsoft.EntityFrameworkCore;

namespace Epood.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Product>> List(int page, int pageSize)
        {
            var result = await _context.Products.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Product Product)
        {
            if (Product.Id == 0)
            {
                _context.Add(Product);
            }
            else
            {
                _context.Update(Product);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
            }

            await _context.SaveChangesAsync();
        }

        public bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}