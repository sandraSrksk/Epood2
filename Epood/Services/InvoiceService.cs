using Epood.Data;
using Epood.Models;
using Microsoft.EntityFrameworkCore;

namespace Epood.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Invoice>> List(int page, int pageSize)
        {
            var result = await _context.Invoices.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Invoice> GetById(int id)
        {
            var result = await _context.Invoices.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Invoice Invoice)
        {
            if (Invoice.Id == 0)
            {
                _context.Add(Invoice);
            }
            else
            {
                _context.Update(Invoice);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Invoice = await _context.Invoices.FindAsync(id);
            if (Invoice != null)
            {
                _context.Invoices.Remove(Invoice);
            }

            await _context.SaveChangesAsync();
        }

        public bool InvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
