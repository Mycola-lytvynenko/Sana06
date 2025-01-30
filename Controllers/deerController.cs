using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sana06.Models;

namespace Sana06.Controllers
{
    public class deerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public deerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: deer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deers.ToListAsync());
        }

        // GET: deer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deer = await _context.Deers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deer == null)
            {
                return NotFound();
            }

            return View(deer);
        }

        // GET: deer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: deer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Years,favorite_threat")] deer deer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deer);
        }

        // GET: deer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deer = await _context.Deers.FindAsync(id);
            if (deer == null)
            {
                return NotFound();
            }
            return View(deer);
        }

        // POST: deer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Years,favorite_threat")] deer deer)
        {
            if (id != deer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!deerExists(deer.Id))
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
            return View(deer);
        }

        // GET: deer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deer = await _context.Deers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deer == null)
            {
                return NotFound();
            }

            return View(deer);
        }

        // POST: deer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deer = await _context.Deers.FindAsync(id);
            if (deer != null)
            {
                _context.Deers.Remove(deer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool deerExists(int id)
        {
            return _context.Deers.Any(e => e.Id == id);
        }
    }
}
