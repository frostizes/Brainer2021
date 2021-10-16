using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brainer.Data;
using Brainer.Models;

namespace Brainer.Controllers
{
    public class BrainTestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrainTestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BrainTests rerferefrfe cdsdc fffz fzefezzefefefz
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrainTest.ToListAsync());
        }

        // GET: BrainTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brainTest = await _context.BrainTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brainTest == null)
            {
                return NotFound();
            }

            return View(brainTest);
        }

        // GET: BrainTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrainTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,NumberOfQuestions")] BrainTest brainTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brainTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brainTest);
        }

        // GET: BrainTests/Edit/5
        //test github fgffdvdfvdfv
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brainTest = await _context.BrainTest.FindAsync(id);
            if (brainTest == null)
            {
                return NotFound();
            }
            return View(brainTest);
        }

        // POST: BrainTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,NumberOfQuestions")] BrainTest brainTest)
        {
            if (id != brainTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brainTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrainTestExists(brainTest.Id))
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
            return View(brainTest);
        }

        // GET: BrainTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brainTest = await _context.BrainTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brainTest == null)
            {
                return NotFound();
            }

            return View(brainTest);
        }

        // POST: BrainTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brainTest = await _context.BrainTest.FindAsync(id);
            _context.BrainTest.Remove(brainTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrainTestExists(int id)
        {
            return _context.BrainTest.Any(e => e.Id == id);
        }
    }
}
