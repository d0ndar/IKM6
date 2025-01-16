using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IKM6.Data;
using IKM6.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IKM6.Controllers
{
    public class valuesController : Controller
    {
        private readonly IKM6Context _context;

        public valuesController(IKM6Context context)
        {
            _context = context;
        }

        // GET: values
        public async Task<IActionResult> Index()
        {
            var iKM6Context = _context.values.Include(v => v.property);
            return View(await iKM6Context.ToListAsync());
        }

        // GET: values/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var values = await _context.values
                .Include(v => v.property)
                .FirstOrDefaultAsync(m => m.id == id);
            if (values == null)
            {
                return NotFound();
            }

            return View(values);
        }

        // GET: values/Create
        public IActionResult Create()
        {
            ViewData["property_id"] = new SelectList(_context.property, "id", "id");
            return View();
        }

        // POST: values/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,property_id,name")] values values)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("1");
                _context.Add(values);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                Console.WriteLine("2");
            }
            ViewData["property_id"] = new SelectList(_context.property, "id", "id", values.property_id);
            Console.WriteLine("3");
            return View(values);
        }

        // GET: values/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var values = await _context.values.FindAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            ViewData["property_id"] = new SelectList(_context.property, "id", "id", values.property_id);
            return View(values);
        }

        // POST: values/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,property_id,name")] values values)
        {
            if (id != values.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(values);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!valuesExists(values.id))
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
            ViewData["property_id"] = new SelectList(_context.property, "id", "id", values.property_id);
            return View(values);
        }

        // GET: values/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var values = await _context.values
                .Include(v => v.property)
                .FirstOrDefaultAsync(m => m.id == id);
            if (values == null)
            {
                return NotFound();
            }

            return View(values);
        }

        // POST: values/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var values = await _context.values.FindAsync(id);
            if (values != null)
            {
                _context.values.Remove(values);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool valuesExists(int id)
        {
            return _context.values.Any(e => e.id == id);
        }
    }
}
