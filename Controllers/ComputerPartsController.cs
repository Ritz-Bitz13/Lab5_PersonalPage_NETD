using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_PersonalPage.Data;

namespace Lab5_PersonalPage.Controllers
{
    public class ComputerPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComputerPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComputerParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parts.ToListAsync());
        }

        // GET: ComputerParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.Parts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computerParts == null)
            {
                return NotFound();
            }

            return View(computerParts);
        }

        // GET: ComputerParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComputerParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,computerBrand,computerPart,computerCreatedYear,computerPartPrice")] ComputerParts computerParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computerParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computerParts);
        }

        // GET: ComputerParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.Parts.FindAsync(id);
            if (computerParts == null)
            {
                return NotFound();
            }
            return View(computerParts);
        }

        // POST: ComputerParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,computerBrand,computerPart,computerCreatedYear,computerPartPrice")] ComputerParts computerParts)
        {
            if (id != computerParts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computerParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerPartsExists(computerParts.ID))
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
            return View(computerParts);
        }

        // GET: ComputerParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.Parts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computerParts == null)
            {
                return NotFound();
            }

            return View(computerParts);
        }

        // POST: ComputerParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computerParts = await _context.Parts.FindAsync(id);
            _context.Parts.Remove(computerParts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerPartsExists(int id)
        {
            return _context.Parts.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Search()
        {
            return View();
        }

        // Search Function1: Search by the Brand of the Computer Part
        public async Task<IActionResult> ShowSearchResults(string computerBrand)
        {
            return View("Index", await _context.Parts.Where(b => b.computerBrand.Contains(computerBrand)).ToListAsync());
        }

        public async Task<IActionResult> Search2()
        {
            return View();
        }

        // Search Function2: Search by The Part of a Computer
        public async Task<IActionResult> ShowSearchResults2(string computerPart)
        {
            return View("Index", await _context.Parts.Where(p => p.computerPart.Contains(computerPart)).ToListAsync());
        }
    }
}
