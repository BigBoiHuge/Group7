using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HappyCitizens.Data;
using HappyCitizens.Models;

namespace HappyCitizens.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Property
        public async Task<IActionResult> Index()
        {
            return _context.Property != null ?
                View(await _context.Property.Include(@property => @property.User).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Property' is null");

        }

        // GET: Property/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .Include(@property => @property.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Property/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName");
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MailingAddress,PhysicalAddress,YearBuilt,DeputyAppraiser")] Property @property)
        {
            var user = _context.User.Find(@property.UserId);
            if (user != null)
            {
                @property.User = user;
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", @property.UserId);
            return View(@property);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MailingAddress,PhysicalAddress,YearBuilt,DeputyAppraiser")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            var user = _context.User.Find(@property.UserId);
            if (user == null)
            {
                ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", @property.UserId);
                return View(@property);
            }

            @property.User = user;
            try
            {
                _context.Update(@property);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(@property.Id))
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

        // GET: Property/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .Include(@property => @property.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Property == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Property'  is null.");
            }
            var @property = await _context.Property.FindAsync(id);
            if (@property != null)
            {
                _context.Property.Remove(@property);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
          return (_context.Property?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
