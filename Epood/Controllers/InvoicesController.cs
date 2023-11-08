using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epood.Data;
using Epood.Models;
using Epood.Services;

namespace Epood.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: Invoices
        [Route("Invoices/")]

        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _invoiceService.List(page, 3);

            return View(result);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoiceService.GetById(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        //[Route("Invoices/Create")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceNo,InvoiceDate,DueDate,TotalPayable,IsPaid")] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View(invoice);
            }
            await _invoiceService.Save(invoice);
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoiceService.GetById(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceNo,InvoiceDate,DueDate,RentalPayable,OverduePayable,DamagesPayable,TotalPayable,IsPaid")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(invoice);
            }
            await _invoiceService.Save(invoice);
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoiceService.GetById(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _invoiceService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _invoiceService.InvoiceExists(id);
        }
    }
}