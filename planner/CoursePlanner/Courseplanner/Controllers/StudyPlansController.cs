using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Courseplanner.Models;

namespace Courseplanner.Controllers
{
    public class StudyPlansController : Controller
    {
        private readonly SchoolContext _context;

        public StudyPlansController(SchoolContext context)
        {
            _context = context;
        }

        // GET: StudyPlans
        public async Task<IActionResult> Index(string searchString)
        {

            var studyPlans = from p in _context.StudyPlans
                          select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                studyPlans = studyPlans.Where(p => p.Papers.Contains(searchString));
            }

            return View( await studyPlans.ToListAsync());
        }

        // GET: StudyPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlans = await _context.StudyPlans
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.PlanId == id);
            if (studyPlans == null)
            {
                return NotFound();
            }

            return View(studyPlans);
        }

        // GET: StudyPlans/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Fname");
            return View();
        }

        // POST: StudyPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanId,StudentId,Papers")] StudyPlans studyPlans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyPlans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Fname", studyPlans.StudentId);
            return View(studyPlans);
        }

        // GET: StudyPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlans = await _context.StudyPlans.SingleOrDefaultAsync(m => m.PlanId == id);
            if (studyPlans == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Fname", studyPlans.StudentId);
            return View(studyPlans);
        }

        // POST: StudyPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanId,StudentId,Papers")] StudyPlans studyPlans)
        {
            if (id != studyPlans.PlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyPlans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyPlansExists(studyPlans.PlanId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Fname", studyPlans.StudentId);
            return View(studyPlans);
        }

        // GET: StudyPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlans = await _context.StudyPlans
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.PlanId == id);
            if (studyPlans == null)
            {
                return NotFound();
            }

            return View(studyPlans);
        }

        // POST: StudyPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyPlans = await _context.StudyPlans.SingleOrDefaultAsync(m => m.PlanId == id);
            _context.StudyPlans.Remove(studyPlans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyPlansExists(int id)
        {
            return _context.StudyPlans.Any(e => e.PlanId == id);
        }
    }
}
