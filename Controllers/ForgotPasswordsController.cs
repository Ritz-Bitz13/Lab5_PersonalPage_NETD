using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_PersonalPage.Data;
using Lab5_PersonalPage.Models;

namespace Lab5_PersonalPage.Controllers
{
    public class ForgotPasswordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForgotPasswordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForgotPasswords
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForgotPassword.ToListAsync());
        }

        // GET: ForgotPasswords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forgotPassword = await _context.ForgotPassword
                .FirstOrDefaultAsync(m => m.Email == id);
            if (forgotPassword == null)
            {
                return NotFound();
            }

            return View(forgotPassword);
        }

        // GET: ForgotPasswords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForgotPasswords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email")] ForgotPassword forgotPassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forgotPassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forgotPassword);
        }

        // GET: ForgotPasswords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forgotPassword = await _context.ForgotPassword.FindAsync(id);
            if (forgotPassword == null)
            {
                return NotFound();
            }
            return View(forgotPassword);
        }

        // POST: ForgotPasswords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email")] ForgotPassword forgotPassword)
        {
            if (id != forgotPassword.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forgotPassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForgotPasswordExists(forgotPassword.Email))
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
            return View(forgotPassword);
        }

        // GET: ForgotPasswords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forgotPassword = await _context.ForgotPassword
                .FirstOrDefaultAsync(m => m.Email == id);
            if (forgotPassword == null)
            {
                return NotFound();
            }

            return View(forgotPassword);
        }

        // POST: ForgotPasswords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var forgotPassword = await _context.ForgotPassword.FindAsync(id);
            _context.ForgotPassword.Remove(forgotPassword);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForgotPasswordExists(string id)
        {
            return _context.ForgotPassword.Any(e => e.Email == id);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPasswordModel)
        {
            return View(forgotPasswordModel);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}
