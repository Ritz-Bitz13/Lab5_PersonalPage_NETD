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
    public class SellerInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellerInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SellerInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seller.ToListAsync());
        }

        // GET: SellerInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerInformation = await _context.Seller
                .FirstOrDefaultAsync(m => m.SellerID == id);
            if (sellerInformation == null)
            {
                return NotFound();
            }

            return View(sellerInformation);
        }

        // GET: SellerInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellerInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SellerID,First_Name,Last_Name,City_Location,Year_Joined,Selling_Computer_Part,Part_Condition")] SellerInformation sellerInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellerInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellerInformation);
        }

        // GET: SellerInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerInformation = await _context.Seller.FindAsync(id);
            if (sellerInformation == null)
            {
                return NotFound();
            }
            return View(sellerInformation);
        }

        // POST: SellerInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SellerID,First_Name,Last_Name,City_Location,Year_Joined,Selling_Computer_Part,Part_Condition")] SellerInformation sellerInformation)
        {
            if (id != sellerInformation.SellerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellerInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerInformationExists(sellerInformation.SellerID))
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
            return View(sellerInformation);
        }

        // GET: SellerInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerInformation = await _context.Seller
                .FirstOrDefaultAsync(m => m.SellerID == id);
            if (sellerInformation == null)
            {
                return NotFound();
            }

            return View(sellerInformation);
        }

        // POST: SellerInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerInformation = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(sellerInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerInformationExists(int id)
        {
            return _context.Seller.Any(e => e.SellerID == id);
        }
    }
}
