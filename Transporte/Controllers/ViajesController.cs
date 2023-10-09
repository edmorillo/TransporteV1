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
    public class ViajesController : Controller
    {
        private readonly TAI2Context _context;

        public ViajesController(TAI2Context context)
        {
            _context = context;
        }

        // GET: Viajes
        public async Task<IActionResult> Index()
        {
            var tAI2Context = _context.Viajes.Include(v => v.IdChoferNavigation).Include(v => v.IdClienteNavigation).Include(v => v.IdLocalidadNavigation);
            return View(await tAI2Context.ToListAsync());
        }

        // GET: Viajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdChoferNavigation)
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdLocalidadNavigation)
                .FirstOrDefaultAsync(m => m.IdViajes == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // GET: Viajes/Create
        public IActionResult Create()
        {
            ViewData["IdChofer"] = new SelectList(_context.Choferes, "IdChofer", "IdChofer");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdLocalidad"] = new SelectList(_context.Localidades, "IdLocalidad", "IdLocalidad");
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdViajes,Viajes,Origen,Destino,Tarifa,FormaDeCobro,Escobrado,Detalle,Remito,Ncontenedor,EsFacturado,Entidad,Nfactura,IdChofer,IdLocalidad,IdCliente")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChofer"] = new SelectList(_context.Choferes, "IdChofer", "IdChofer", viaje.IdChofer);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdLocalidad"] = new SelectList(_context.Localidades, "IdLocalidad", "IdLocalidad", viaje.IdLocalidad);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["IdChofer"] = new SelectList(_context.Choferes, "IdChofer", "IdChofer", viaje.IdChofer);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdLocalidad"] = new SelectList(_context.Localidades, "IdLocalidad", "IdLocalidad", viaje.IdLocalidad);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdViajes,Viajes,Origen,Destino,Tarifa,FormaDeCobro,Escobrado,Detalle,Remito,Ncontenedor,EsFacturado,Entidad,Nfactura,IdChofer,IdLocalidad,IdCliente")] Viaje viaje)
        {
            if (id != viaje.IdViajes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.IdViajes))
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
            ViewData["IdChofer"] = new SelectList(_context.Choferes, "IdChofer", "IdChofer", viaje.IdChofer);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdLocalidad"] = new SelectList(_context.Localidades, "IdLocalidad", "IdLocalidad", viaje.IdLocalidad);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdChoferNavigation)
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdLocalidadNavigation)
                .FirstOrDefaultAsync(m => m.IdViajes == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viajes == null)
            {
                return Problem("Entity set 'TAI2Context.Viajes'  is null.");
            }
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje != null)
            {
                _context.Viajes.Remove(viaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajeExists(int id)
        {
          return (_context.Viajes?.Any(e => e.IdViajes == id)).GetValueOrDefault();
        }
    }
}
