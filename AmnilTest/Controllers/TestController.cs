using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmnilTest;
using AmnilTest.Model;
using AmnilTest.ViewModels;

namespace AmnilTest.Controllers
{
    public class TestController : Controller
    {
        private readonly DatabaseContext _context;

        public TestController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Test
        public ActionResult Index()

    {          
        var databaseContext = _context.Contestants.Include(c => c.District);
            var viewModel = (from con in _context.Contestants join dist in _context.Districts on con.DistrictId equals dist.Id
                                  select new ContestantViewModel { Id=con.Id,FullName=string.Concat(con.Firstname,' ',con.Lastname),DateOfBirth=con.DateOfBirth,District= dist.Name,Gender= con.Gender }).ToList();
        
            return View(viewModel);
        }

        //// GET: Test/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contestant = await _context.Contestants
        //        .Include(c => c.District)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (contestant == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contestant);
        //}

        // GET: Test/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,DateOfBirth,IsActive,DistrictId,Gender,PhotoUrl,Address")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contestant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", contestant.DistrictId);
            return View(contestant);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants.FindAsync(id);
            if (contestant == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", contestant.DistrictId);
            return View(contestant);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,DateOfBirth,IsActive,DistrictId,Gender,PhotoUrl,Address")] Contestant contestant)
        {
            if (id != contestant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contestant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestantExists(contestant.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", contestant.DistrictId);
            return View(contestant);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants
                .Include(c => c.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contestant = await _context.Contestants.FindAsync(id);
            _context.Contestants.Remove(contestant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestantExists(int id)
        {
            return _context.Contestants.Any(e => e.Id == id);
        }
    }
}
