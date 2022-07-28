using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen2_ASP.Models;
using Examen2_ASP.Models.Db;

namespace Examen2_ASP.Controllers
{
    public class ExercicesController : Controller
    {
        private readonly TrackerSportContext _context;

        public ExercicesController(TrackerSportContext context)
        {
            _context = context;
        }

        // GET: Exercices
        public async Task<IActionResult> Index()
        {
              return _context.Exercices != null ? 
                          View(await _context.Exercices.ToListAsync()) :
                          Problem("Entity set 'TrackerSportContext.Exercices'  is null.");
        }

        // GET: Exercices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices
                .FirstOrDefaultAsync(m => m.ExerciceId == id);
            if (exercice == null)
            {
                return NotFound();
            }

            return View(exercice);
        }

        // GET: Exercices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciceId,Title,Icon,Category")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercice);
        }

        // GET: Exercices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices.FindAsync(id);
            if (exercice == null)
            {
                return NotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciceId,Title,Icon,Category")] Exercice exercice)
        {
            if (id != exercice.ExerciceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciceExists(exercice.ExerciceId))
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
            return View(exercice);
        }

        // GET: Exercices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercices == null)
            {
                return NotFound();
            }

            var exercice = await _context.Exercices
                .FirstOrDefaultAsync(m => m.ExerciceId == id);
            if (exercice == null)
            {
                return NotFound();
            }

            return View(exercice);
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercices == null)
            {
                return Problem("Entity set 'TrackerSportContext.Exercices'  is null.");
            }
            var exercice = await _context.Exercices.FindAsync(id);
            if (exercice != null)
            {
                _context.Exercices.Remove(exercice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciceExists(int id)
        {
          return (_context.Exercices?.Any(e => e.ExerciceId == id)).GetValueOrDefault();
        }
    }
}
