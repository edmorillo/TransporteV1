using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transporte.Models;

namespace Transporte.Controllers
{
    public class CondicionIvasController : Controller
    {
        private readonly TAI2Context _context;

        public CondicionIvasController(TAI2Context context)
        {
            _context = context;
        }

        // GET: CondicionIvas
        public async Task<IActionResult> Index()
        {
              return _context.CondicionIvas != null ? 
                          View(await _context.CondicionIvas.ToListAsync()) :
                          Problem("Entity set 'TAI2Context.CondicionIvas'  is null.");
        }

        // GET: CondicionIvas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CondicionIvas == null)
            {
                return NotFound();
            }

            var condicionIva = await _context.CondicionIvas
                .FirstOrDefaultAsync(m => m.IdCondicionIva == id);
            if (condicionIva == null)
            {
                return NotFound();
            }

            return View(condicionIva);
        }

        // GET: CondicionIvas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CondicionIvas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCondicionIva,CondicionIva1")] CondicionIva condicionIva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicionIva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicionIva);
        }

        // GET: CondicionIvas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CondicionIvas == null)
            {
                return NotFound();
            }

            var condicionIva = await _context.CondicionIvas.FindAsync(id);
            if (condicionIva == null)
            {
                return NotFound();
            }
            return View(condicionIva);
        }

        // POST: CondicionIvas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCondicionIva,CondicionIva1")] CondicionIva condicionIva)
        {
            if (id != condicionIva.IdCondicionIva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicionIva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionIvaExists(condicionIva.IdCondicionIva))
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
            return View(condicionIva);
        }

        // GET: CondicionIvas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CondicionIvas == null)
            {
                return NotFound();
            }

            var condicionIva = await _context.CondicionIvas
                .FirstOrDefaultAsync(m => m.IdCondicionIva == id);
            if (condicionIva == null)
            {
                return NotFound();
            }

            return View(condicionIva);
        }

        // POST: CondicionIvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CondicionIvas == null)
            {
                return Problem("Entity set 'TAI2Context.CondicionIvas'  is null.");
            }
            var condicionIva = await _context.CondicionIvas.FindAsync(id);
            if (condicionIva != null)
            {
                _context.CondicionIvas.Remove(condicionIva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionIvaExists(int id)
        {
          return (_context.CondicionIvas?.Any(e => e.IdCondicionIva == id)).GetValueOrDefault();
        }
    }
}
