using Epood.Data;
using Epood.Models;
using Microsoft.EntityFrameworkCore;

namespace Epood.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductType>> List(int page, int pageSize)
        {
            var result = await _context.ProductTypes.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<ProductType> GetById(int id)
        {
            var result = await _context.ProductTypes.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(ProductType productType)
        {
            if (productType.Id == 0)
            {
                _context.Add(productType);
            }
            else
            {
                _context.Update(productType);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ProductType = await _context.ProductTypes.FindAsync(id);
            if (ProductType != null)
            {
                _context.ProductTypes.Remove(ProductType);
            }

            await _context.SaveChangesAsync();
        }

        public bool ProductTypeExists(int id)
        {
            return (_context.ProductTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}