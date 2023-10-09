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
    public class LocalidadesController : Controller
    {
        private readonly TAI2Context _context;

        public LocalidadesController(TAI2Context context)
        {
            _context = context;
        }

        // GET: Localidades
        public async Task<IActionResult> Index()
        {
            var tAI2Context = _context.Localidades.Include(l => l.IdProvinciaNavigation);
            return View(await tAI2Context.ToListAsync());
        }

        // GET: Localidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidades
                .Include(l => l.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdLocalidad == id);
            if (localidade == null)
            {
                return NotFound();
            }

            return View(localidade);
        }

        // GET: Localidades/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia");
            return View();
        }

        // POST: Localidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocalidad,IdProvincia,Localidad")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", localidade.IdProvincia);
            return View(localidade);
        }

        // GET: Localidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidades.FindAsync(id);
            if (localidade == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", localidade.IdProvincia);
            return View(localidade);
        }

        // POST: Localidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocalidad,IdProvincia,Localidad")] Localidade localidade)
        {
            if (id != localidade.IdLocalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadeExists(localidade.IdLocalidad))
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
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", localidade.IdProvincia);
            return View(localidade);
        }

        // GET: Localidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidades
                .Include(l => l.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdLocalidad == id);
            if (localidade == null)
            {
                return NotFound();
            }

            return View(localidade);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localidades == null)
            {
                return Problem("Entity set 'TAI2Context.Localidades'  is null.");
            }
            var localidade = await _context.Localidades.FindAsync(id);
            if (localidade != null)
            {
                _context.Localidades.Remove(localidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadeExists(int id)
        {
          return (_context.Localidades?.Any(e => e.IdLocalidad == id)).GetValueOrDefault();
        }
    }
}
