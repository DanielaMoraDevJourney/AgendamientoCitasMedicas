using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamientoCitasMedicas.Data;
using AgendamientoCitasMedicas.Models;

namespace AgendamientoCitasMedicas.Controllers
{
    public class ReportesController : Controller
    {
        private readonly AgendamientoCitasMedicasContext _context;

        public ReportesController(AgendamientoCitasMedicasContext context)
        {
            _context = context;
        }

        // GET: Reportes
        public async Task<IActionResult> Index()
        {
            var agendamientoCitasMedicasContext = _context.Reporte.Include(r => r.Tratamiento);
            return View(await agendamientoCitasMedicasContext.ToListAsync());
        }

        // GET: Reportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .Include(r => r.Tratamiento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // GET: Reportes/Create
        public IActionResult Create()
        {
            ViewData["TratamientoId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Description");
            return View();
        }

        // POST: Reportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaGeneracion,Descripcion,DatosEstadisticos,TratamientoId")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TratamientoId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Description", reporte.TratamientoId);
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }
            ViewData["TratamientoId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Description", reporte.TratamientoId);
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaGeneracion,Descripcion,DatosEstadisticos,TratamientoId")] Reporte reporte)
        {
            if (id != reporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteExists(reporte.Id))
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
            ViewData["TratamientoId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Description", reporte.TratamientoId);
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .Include(r => r.Tratamiento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte != null)
            {
                _context.Reporte.Remove(reporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteExists(int id)
        {
            return _context.Reporte.Any(e => e.Id == id);
        }
    }
}
