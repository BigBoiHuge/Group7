using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HappyCitizens.Data;
using HappyCitizens.Models;
using Microsoft.AspNetCore.Identity;

namespace HappyCitizens.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Items
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var items = from i in _context.Item select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.UserId == searchString);
            }
            
            return _context.Item != null ?
                View(await items.Include(p => p.User).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Item' is null");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        List<SelectListItem> GetUserList()
        {
            var items = new List<SelectListItem>();
            foreach (ApplicationUser user in _userManager.Users)
            {
                var li = new SelectListItem
                {
                    Value = user.Id,
                    Text = user.UserName,
                };
                items.Add(li);
            }
            items.Add(new SelectListItem { Text = "Please Select...", Value = "na", Selected = true });
            return items;
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            
            ViewBag.Users = GetUserList();
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            //ViewBag.Users = new SelectList(_userManager.Users, nameof(ApplicationUser.Id), nameof(ApplicationUser.UserName));
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Room,Description,Category,PurchaseDate,Condition,Price,IsInsured")] Item item)
        {
            var user = await _userManager.FindByIdAsync(item.UserId);
            if (user != null)
            {
                item.User = user;
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = GetUserList();
            return View(item);

        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.Users = GetUserList();
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Room,Description,Category,PurchaseDate,Condition,Price,IsInsured")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            var user = _context.User.Find(item.UserId);
            if (user == null)
            {
                ViewBag.Users = GetUserList();
                return View(item);
            }

            item.User = user;
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(item.Id))
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

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Item'  is null.");
            }
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
