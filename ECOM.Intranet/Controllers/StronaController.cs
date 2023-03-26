﻿
using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Intranet.Controllers
{
    public class StronaController : Controller
    {
        private readonly FirmaContext _context;

        public StronaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Strona
        public async Task<IActionResult> Index()
        {
              return View(await _context.Strona.ToListAsync());
        }

        // GET: Strona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Strona == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // GET: Strona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Strona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStrony,LinkTytul,Tytul,Tresc,Pozycja")] Strona strona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strona);
        }

        // GET: Strona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Strona == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona.FindAsync(id);
            if (strona == null)
            {
                return NotFound();
            }
            return View(strona);
        }

        // POST: Strona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStrony,LinkTytul,Tytul,Tresc,Pozycja")] Strona strona)
        {
            if (id != strona.IdStrony)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaExists(strona.IdStrony))
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
            return View(strona);
        }

        // GET: Strona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Strona == null)
            {
                return NotFound();
            }

            var strona = await _context.Strona
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Strona == null)
            {
                return Problem("Entity set 'ECOMContext.Strona'  is null.");
            }
            var strona = await _context.Strona.FindAsync(id);
            if (strona != null)
            {
                _context.Strona.Remove(strona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaExists(int id)
        {
          return _context.Strona.Any(e => e.IdStrony == id);
        }
    }
}
