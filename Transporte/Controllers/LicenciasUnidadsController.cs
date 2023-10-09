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
    public class LicenciasUnidadsController : Controller
    {
        private readonly TAI2Context _context;

        public LicenciasUnidadsController(TAI2Context context)
        {
            _context = context;
        }

        // GET: LicenciasUnidads
        public async Task<IActionResult> Index()
        {
            var tAI2Context = _context.LicenciasUnidads.Include(l => l.IdTiposDocumentosNavigation).Include(l => l.IdUnidadNavigation);
            return View(await tAI2Context.ToListAsync());
        }

        // GET: LicenciasUnidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LicenciasUnidads == null)
            {
                return NotFound();
            }

            var licenciasUnidad = await _context.LicenciasUnidads
                .Include(l => l.IdTiposDocumentosNavigation)
                .Include(l => l.IdUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdLicenciaUnidades == id);
            if (licenciasUnidad == null)
            {
                return NotFound();
            }

            return View(licenciasUnidad);
        }

        // GET: LicenciasUnidads/Create
        public IActionResult Create()
        {
            ViewData["IdTiposDocumentos"] = new SelectList(_context.TiposDocumentos, "IdTiposDocumentos", "IdTiposDocumentos");
            ViewData["IdUnidad"] = new SelectList(_context.Unidades, "IdUnidad", "IdUnidad");
            return View();
        }

        // POST: LicenciasUnidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLicenciaUnidades,IdUnidad,IdTiposDocumentos,FechaVencimiento")] LicenciasUnidad licenciasUnidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenciasUnidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTiposDocumentos"] = new SelectList(_context.TiposDocumentos, "IdTiposDocumentos", "IdTiposDocumentos", licenciasUnidad.IdTiposDocumentos);
            ViewData["IdUnidad"] = new SelectList(_context.Unidades, "IdUnidad", "IdUnidad", licenciasUnidad.IdUnidad);
            return View(licenciasUnidad);
        }

        // GET: LicenciasUnidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LicenciasUnidads == null)
            {
                return NotFound();
            }

            var licenciasUnidad = await _context.LicenciasUnidads.FindAsync(id);
            if (licenciasUnidad == null)
            {
                return NotFound();
            }
            ViewData["IdTiposDocumentos"] = new SelectList(_context.TiposDocumentos, "IdTiposDocumentos", "IdTiposDocumentos", licenciasUnidad.IdTiposDocumentos);
            ViewData["IdUnidad"] = new SelectList(_context.Unidades, "IdUnidad", "IdUnidad", licenciasUnidad.IdUnidad);
            return View(licenciasUnidad);
        }

        // POST: LicenciasUnidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLicenciaUnidades,IdUnidad,IdTiposDocumentos,FechaVencimiento")] LicenciasUnidad licenciasUnidad)
        {
            if (id != licenciasUnidad.IdLicenciaUnidades)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenciasUnidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenciasUnidadExists(licenciasUnidad.IdLicenciaUnidades))
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
            ViewData["IdTiposDocumentos"] = new SelectList(_context.TiposDocumentos, "IdTiposDocumentos", "IdTiposDocumentos", licenciasUnidad.IdTiposDocumentos);
            ViewData["IdUnidad"] = new SelectList(_context.Unidades, "IdUnidad", "IdUnidad", licenciasUnidad.IdUnidad);
            return View(licenciasUnidad);
        }

        // GET: LicenciasUnidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LicenciasUnidads == null)
            {
                return NotFound();
            }

            var licenciasUnidad = await _context.LicenciasUnidads
                .Include(l => l.IdTiposDocumentosNavigation)
                .Include(l => l.IdUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdLicenciaUnidades == id);
            if (licenciasUnidad == null)
            {
                return NotFound();
            }

            return View(licenciasUnidad);
        }

        // POST: LicenciasUnidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LicenciasUnidads == null)
            {
                return Problem("Entity set 'TAI2Context.LicenciasUnidads'  is null.");
            }
            var licenciasUnidad = await _context.LicenciasUnidads.FindAsync(id);
            if (licenciasUnidad != null)
            {
                _context.LicenciasUnidads.Remove(licenciasUnidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenciasUnidadExists(int id)
        {
          return (_context.LicenciasUnidads?.Any(e => e.IdLicenciaUnidades == id)).GetValueOrDefault();
        }
    }
}
