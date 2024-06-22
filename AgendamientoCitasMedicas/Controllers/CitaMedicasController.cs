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
    public class CitaMedicasController : Controller
    {
        private readonly AgendamientoCitasMedicasContext _context;

        public CitaMedicasController(AgendamientoCitasMedicasContext context)
        {
            _context = context;
        }

        // GET: CitaMedicas
        public async Task<IActionResult> Index()
        {
            var agendamientoCitasMedicasContext = _context.CitaMedica.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await agendamientoCitasMedicasContext.ToListAsync());
        }

        // GET: CitaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // GET: CitaMedicas/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "Id", "Name");
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "Id", "Name");
            return View();
        }

        // POST: CitaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reason,Availability,Schedule,PacienteId,MedicoId")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "Id", "Name", citaMedica.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "Id", "Name", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // GET: CitaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "Id", "Name", citaMedica.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "Id", "Name", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // POST: CitaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reason,Availability,Schedule,PacienteId,MedicoId")] CitaMedica citaMedica)
        {
            if (id != citaMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaMedicaExists(citaMedica.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "Id", "Name", citaMedica.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "Id", "Name", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // GET: CitaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // POST: CitaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica != null)
            {
                _context.CitaMedica.Remove(citaMedica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaMedicaExists(int id)
        {
            return _context.CitaMedica.Any(e => e.Id == id);
        }
    }
}
