using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuskyHotels.Data;
using RuskyHotels.Models;

namespace RuskyHotels.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomPricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomPricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomPrices.OrderBy(rp => rp.RoomType).ToListAsync());
        }

        // GET: RoomPrices/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrice = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomPrice == null)
            {
                return NotFound();
            }

            return View(roomPrice);
        }

        // GET: RoomPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomType,Price")] RoomPrice roomPrice)
        {
            if (ModelState.IsValid)
            {
                if (_context.RoomPrices.Any(rp => rp.RoomType == roomPrice.RoomType))
                {
                    ModelState.AddModelError("RoomType", "Price for selected room type exists.");
                    return View(roomPrice);
                }

                _context.Add(roomPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomPrice);
        }

        // GET: RoomPrices/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrice = await _context.RoomPrices.FindAsync(id);
            if (roomPrice == null)
            {
                return NotFound();
            }

            return View(roomPrice);
        }

        // POST: RoomPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,RoomType,Price")] RoomPrice roomPrice)
        {
            if (id != roomPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.RoomPrices.Any(rp => rp.RoomType == roomPrice.RoomType && rp.Id != id))
                {
                    ModelState.AddModelError("RoomType", "Price for selected room type exists.");
                    return View(roomPrice);
                }

                try
                {
                    _context.Update(roomPrice);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomPriceExists(roomPrice.Id))
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
            return View(roomPrice);
        }

        // GET: RoomPrices/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrice = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomPrice == null)
            {
                return NotFound();
            }

            return View(roomPrice);
        }

        // POST: RoomPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var roomPrice = await _context.RoomPrices.FindAsync(id);
            _context.RoomPrices.Remove(roomPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomPriceExists(long id)
        {
            return _context.RoomPrices.Any(e => e.Id == id);
        }
    }
}
