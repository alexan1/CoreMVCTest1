using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVCTest1.Data;
using CoreMVCTest1.Models;

namespace CoreMVCTest1.Controllers
{
    public class TestEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestEntity.ToListAsync());
        }

        // GET: TestEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.TestEntity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testEntity == null)
            {
                return NotFound();
            }

            return View(testEntity);
        }

        // GET: TestEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Hard")] TestEntity testEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testEntity);
        }

        // GET: TestEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.TestEntity.FindAsync(id);
            if (testEntity == null)
            {
                return NotFound();
            }
            return View(testEntity);
        }

        // POST: TestEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Hard")] TestEntity testEntity)
        {
            if (id != testEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestEntityExists(testEntity.ID))
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
            return View(testEntity);
        }

        // GET: TestEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.TestEntity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testEntity == null)
            {
                return NotFound();
            }

            return View(testEntity);
        }

        // POST: TestEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testEntity = await _context.TestEntity.FindAsync(id);
            _context.TestEntity.Remove(testEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestEntityExists(int id)
        {
            return _context.TestEntity.Any(e => e.ID == id);
        }
    }
}
