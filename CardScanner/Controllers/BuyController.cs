using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CardScanner.Data;
using CardScanner.Models.ProductViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CardScanner.Controllers
{
    [Authorize]
    public class BuyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buy
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buy.ToListAsync());
        }

        // GET: Buy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy
                .SingleOrDefaultAsync(m => m.ID == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // GET: Buy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MaxPrice")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buy);
        }

        // GET: Buy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy.SingleOrDefaultAsync(m => m.ID == id);
            if (buy == null)
            {
                return NotFound();
            }
            return View(buy);
        }

        // POST: Buy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MaxPrice")] Buy buy)
        {
            if (id != buy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyExists(buy.ID))
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
            return View(buy);
        }

        // GET: Buy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy
                .SingleOrDefaultAsync(m => m.ID == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // POST: Buy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buy = await _context.Buy.SingleOrDefaultAsync(m => m.ID == id);
            _context.Buy.Remove(buy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyExists(int id)
        {
            return _context.Buy.Any(e => e.ID == id);
        }
    }
}
