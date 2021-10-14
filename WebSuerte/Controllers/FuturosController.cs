using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSuerte.Data;
using WebSuerte.Models;

namespace WebSuerte.Controllers
{
    public class FuturosController : Controller
    {
        private readonly AppDbContext _context;

        public FuturosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Futuros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Futuro.ToListAsync());
        }

        // GET: Futuros/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuro = await _context.Futuro
                .FirstOrDefaultAsync(m => m.SUERTE == id);
            if (futuro == null)
            {
                return NotFound();
            }

            return View(futuro);
        }

        // GET: Futuros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Futuros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SUERTE,Nombre,Opcion,Link")] Futuro futuro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futuro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(futuro);
        }

        // GET: Futuros/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuro = await _context.Futuro.FindAsync(id);
            if (futuro == null)
            {
                return NotFound();
            }
            return View(futuro);
        }

        // POST: Futuros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SUERTE,Nombre,Opcion,Link")] Futuro futuro)
        {
            if (id != futuro.SUERTE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futuro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuturoExists(futuro.SUERTE))
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
            return View(futuro);
        }

        // GET: Futuros/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuro = await _context.Futuro
                .FirstOrDefaultAsync(m => m.SUERTE == id);
            if (futuro == null)
            {
                return NotFound();
            }

            return View(futuro);
        }

        // POST: Futuros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var futuro = await _context.Futuro.FindAsync(id);
            _context.Futuro.Remove(futuro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuturoExists(string id)
        {
            return _context.Futuro.Any(e => e.SUERTE == id);
        }
    }
}
