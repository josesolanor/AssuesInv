using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroDoc.Context;
using RegistroDoc.Entities;

namespace RegistroDoc.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AppDBContext _context;

        public InventoryController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Inventory.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryId,Number,ReferenceCode,DocumentTitle,Series,SecondNumber,ExtremeDates,InstallationUnit,NumberSheets,ProducerName,StateConservation,DocumentObservation,Shelf,Bald,Box")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryId,Number,ReferenceCode,DocumentTitle,Series,SecondNumber,ExtremeDates,InstallationUnit,NumberSheets,ProducerName,StateConservation,DocumentObservation,Shelf,Bald,Box")] Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryId == id);
        }
    }
}
