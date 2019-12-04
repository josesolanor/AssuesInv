﻿using System;
using System.Collections.Generic;
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
    public class InventoryController : Controller
    {
        private readonly AppDBContext _context;
     
        public InventoryController(AppDBContext context)
        {
            _context = context;
        }       
        [Authorize(Roles = "Admin,RegistraLectura,SoloLectura")]
        public IActionResult Index()
        {
            var model = new InvIndexViewModel();
            return View(model);
        }

        [Authorize(Roles = "Admin,RegistraLectura,SoloLectura")]
        public IActionResult LoadGrid()
        {
            List<InventoryViewModels> inventoryList = new List<InventoryViewModels>();
            List<MovementsViewModels> movementList = new List<MovementsViewModels>();

            var inventories = _context.Inventory
                .Include(x => x.Movements)
                .ToList();            

            foreach (Inventory item in inventories)
            {
                foreach (Movements itemMovement in item.Movements)

                movementList.Add(new MovementsViewModels
                {
                    MovementsId = itemMovement.MovementsId,
                    MovementType = itemMovement.MovementType,
                    MovementObservation = itemMovement.MovementObservation,
                    MovementDate = itemMovement.MovementDate,
                    InventoryId = itemMovement.InventoryId
                });

                inventoryList.Add(new InventoryViewModels
                {
                    InventoryId = item.InventoryId,
                    Number = item.Number,
                    ReferenceCode = item.ReferenceCode,
                    DocumentTitle = item.DocumentTitle,
                    Series = item.Series,
                    Volume = item.Volume,
                    SecondNumber = item.SecondNumber,
                    ExtremeDates = item.ExtremeDates,
                    InstallationUnit = item.InstallationUnit,
                    NumberSheets = item.NumberSheets,
                    ProducerName = item.ProducerName,
                    StateConservation = item.StateConservation,
                    DocumentObservation = item.DocumentObservation,
                    Shelf = item.Shelf,
                    Bald = item.Bald,
                    Box = item.Box,
                    Movements = movementList
                });
            }

            return Json(inventoryList);
        }

        [Authorize(Roles = "Admin,SoloLectura")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Inventory inventory)
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
