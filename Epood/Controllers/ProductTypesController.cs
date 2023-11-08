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
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _productTypeService.List(page, 3);

            return View(result);
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }


        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                return View(productType);
            }
            await _productTypeService.Save(productType);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return View(productType);
            }
            _productTypeService.Save(productType);
            return RedirectToAction(nameof(Index));
        }

        // GET: productType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: productType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypeExists(int id)
        {
            return _productTypeService.ProductTypeExists(id);
        }
    }
}
