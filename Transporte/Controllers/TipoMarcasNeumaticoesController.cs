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
    public class TipoMarcasNeumaticoesController : Controller
    {
        private readonly TAI2Context _context;

        public TipoMarcasNeumaticoesController(TAI2Context context)
        {
            _context = context;
        }

        // GET: TipoMarcasNeumaticoes
        public async Task<IActionResult> Index()
        {
              return _context.TipoMarcasNeumaticos != null ? 
                          View(await _context.TipoMarcasNeumaticos.ToListAsync()) :
                          Problem("Entity set 'TAI2Context.TipoMarcasNeumaticos'  is null.");
        }

        // GET: TipoMarcasNeumaticoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoMarcasNeumaticos == null)
            {
                return NotFound();
            }

            var tipoMarcasNeumatico = await _context.TipoMarcasNeumaticos
                .FirstOrDefaultAsync(m => m.IdTipoMarcaNeumaticos == id);
            if (tipoMarcasNeumatico == null)
            {
                return NotFound();
            }

            return View(tipoMarcasNeumatico);
        }

        // GET: TipoMarcasNeumaticoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMarcasNeumaticoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMarcaNeumaticos,TipoMarcaNeumatico")] TipoMarcasNeumatico tipoMarcasNeumatico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMarcasNeumatico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMarcasNeumatico);
        }

        // GET: TipoMarcasNeumaticoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoMarcasNeumaticos == null)
            {
                return NotFound();
            }

            var tipoMarcasNeumatico = await _context.TipoMarcasNeumaticos.FindAsync(id);
            if (tipoMarcasNeumatico == null)
            {
                return NotFound();
            }
            return View(tipoMarcasNeumatico);
        }

        // POST: TipoMarcasNeumaticoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMarcaNeumaticos,TipoMarcaNeumatico")] TipoMarcasNeumatico tipoMarcasNeumatico)
        {
            if (id != tipoMarcasNeumatico.IdTipoMarcaNeumaticos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMarcasNeumatico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMarcasNeumaticoExists(tipoMarcasNeumatico.IdTipoMarcaNeumaticos))
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
            return View(tipoMarcasNeumatico);
        }

        // GET: TipoMarcasNeumaticoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoMarcasNeumaticos == null)
            {
                return NotFound();
            }

            var tipoMarcasNeumatico = await _context.TipoMarcasNeumaticos
                .FirstOrDefaultAsync(m => m.IdTipoMarcaNeumaticos == id);
            if (tipoMarcasNeumatico == null)
            {
                return NotFound();
            }

            return View(tipoMarcasNeumatico);
        }

        // POST: TipoMarcasNeumaticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoMarcasNeumaticos == null)
            {
                return Problem("Entity set 'TAI2Context.TipoMarcasNeumaticos'  is null.");
            }
            var tipoMarcasNeumatico = await _context.TipoMarcasNeumaticos.FindAsync(id);
            if (tipoMarcasNeumatico != null)
            {
                _context.TipoMarcasNeumaticos.Remove(tipoMarcasNeumatico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMarcasNeumaticoExists(int id)
        {
          return (_context.TipoMarcasNeumaticos?.Any(e => e.IdTipoMarcaNeumaticos == id)).GetValueOrDefault();
        }
    }
}
