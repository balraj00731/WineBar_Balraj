﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineBar_Balraj.Data;
using WineBar_Balraj.Models;

namespace WineBar_Balraj.Controllers
{
    [Authorize]
    public class WaitersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaitersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Waiters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waiters.ToListAsync());
        }

        // GET: Waiters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        // GET: Waiters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waiters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Waiter waiter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        // GET: Waiters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiters.FindAsync(id);
            if (waiter == null)
            {
                return NotFound();
            }
            return View(waiter);
        }

        // POST: Waiters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Waiter waiter)
        {
            if (id != waiter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaiterExists(waiter.ID))
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
            return View(waiter);
        }

        // GET: Waiters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        // POST: Waiters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waiter = await _context.Waiters.FindAsync(id);
            _context.Waiters.Remove(waiter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaiterExists(int id)
        {
            return _context.Waiters.Any(e => e.ID == id);
        }
    }
}
