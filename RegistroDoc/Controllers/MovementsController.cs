using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroDoc.Context;
using RegistroDoc.Entities;
using RegistroDoc.Models;

namespace RegistroDoc.Controllers
{
    [Authorize]
    public class MovementsController : Controller
    {
        private readonly AppDBContext _context;

        public MovementsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,RegistraLectura")]
        public async Task<IActionResult> Create(MovementCreateViewModel data)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.ParseExact(data.RegisterDateString.Substring(0, 24),
                                          "ddd MMM dd yyyy HH:mm:ss",
                                          CultureInfo.InvariantCulture);

                Movements movements = new Movements
                {
                    InventoryId = data.InventoryId,
                    MovementObservation = data.MovementObservation,
                    MovementType = data.MovementType,
                    MovementDate = date
                };
                _context.Add(movements);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Inventory");
            }
            TempData["ErrorMsg"] = $"Error, No se pudo realizar la accion";
            return RedirectToAction("Index", "Inventory");
        }

        [Authorize(Roles = "Admin,RegistraLectura")]
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> listMovements = new List<SelectListItem>
            {
                new SelectListItem { Value = "Egreso", Text = "Egreso" },
                new SelectListItem { Value = "Ingreso", Text = "Ingreso" },
            };

            if (id == null)
            {
                return NotFound();
            }

            var movements = await _context.Movements.FindAsync(id);
            if (movements == null)
            {
                return NotFound();
            }
            ViewData["ListMovements"] = new SelectList(listMovements, "Value", "Text");
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", movements.InventoryId);
            return View(movements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,RegistraLectura")]
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
                return RedirectToAction("Index", "Inventory");
            }            
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", movements.InventoryId);
            return RedirectToAction("Index", "Inventory");
        }

        [Authorize(Roles = "Admin,RegistraLectura")]
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,RegistraLectura")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movements = await _context.Movements.FindAsync(id);
            _context.Movements.Remove(movements);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Inventory");
        }

        private bool MovementsExists(int id)
        {
            return _context.Movements.Any(e => e.MovementsId == id);
        }
    }
}
