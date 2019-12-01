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
    public class MovementsController : Controller
    {
        private readonly AppDBContext _context;

        public MovementsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Movements
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Movements.Include(m => m.Inventory);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Movements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = await _context.Movements
                .Include(m => m.Inventory)
                .FirstOrDefaultAsync(m => m.MovementsId == id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(movements);
        }

        // GET: Movements/Create
        public IActionResult Create()
        {
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId");
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovementsId,MovementType,MovementDate,MovementObservation,InventoryId")] Movements movements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", movements.InventoryId);
            return View(movements);
        }

        // GET: Movements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = await _context.Movements.FindAsync(id);
            if (movements == null)
            {
                return NotFound();
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", movements.InventoryId);
            return View(movements);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovementsId,MovementType,MovementDate,MovementObservation,InventoryId")] Movements movements)
        {
            if (id != movements.MovementsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovementsExists(movements.MovementsId))
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
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", movements.InventoryId);
            return View(movements);
        }

        // GET: Movements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = await _context.Movements
                .Include(m => m.Inventory)
                .FirstOrDefaultAsync(m => m.MovementsId == id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(movements);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movements = await _context.Movements.FindAsync(id);
            _context.Movements.Remove(movements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovementsExists(int id)
        {
            return _context.Movements.Any(e => e.MovementsId == id);
        }
    }
}
