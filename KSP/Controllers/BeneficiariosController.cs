using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KSP.Models;

namespace KSP.Controllers
{
    public class BeneficiariosController : Controller
    {
        private readonly KSPEvalContext _context;

        public BeneficiariosController(KSPEvalContext context)
        {
            _context = context;
        }

        // GET: Beneficiarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Beneficiarios.ToListAsync());
        }

        // GET: Beneficiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // GET: Beneficiarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBeneficiario,IdEmpleado,StrNombreCompleto,IdParentesco,DtFechaNacimiento,IdSexo")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiario);
        }

        // GET: Beneficiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        // POST: Beneficiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBeneficiario,IdEmpleado,StrNombreCompleto,IdParentesco,DtFechaNacimiento,IdSexo")] Beneficiario beneficiario)
        {
            if (id != beneficiario.IdBeneficiario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiarioExists(beneficiario.IdBeneficiario))
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
            return View(beneficiario);
        }

        // GET: Beneficiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // POST: Beneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Beneficiarios == null)
            {
                return Problem("Entity set 'KSPEvalContext.Beneficiarios'  is null.");
            }
            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario != null)
            {
                _context.Beneficiarios.Remove(beneficiario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiarioExists(int id)
        {
          return _context.Beneficiarios.Any(e => e.IdBeneficiario == id);
        }
    }
}
