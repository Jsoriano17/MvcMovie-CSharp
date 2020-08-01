using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class AnimailsController : Controller
    {
        private readonly MvcMovieContext _context;

        public AnimailsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Animails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animails.ToListAsync());
        }

        // GET: Animails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animails = await _context.Animails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animails == null)
            {
                return NotFound();
            }

            return View(animails);
        }

        // GET: Animails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Age,Name,animalType,Gender")] Animails animails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animails);
        }

        // GET: Animails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animails = await _context.Animails.FindAsync(id);
            if (animails == null)
            {
                return NotFound();
            }
            return View(animails);
        }

        // POST: Animails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Age,Name,animalType,Gender")] Animails animails)
        {
            if (id != animails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimailsExists(animails.Id))
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
            return View(animails);
        }

        // GET: Animails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animails = await _context.Animails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animails == null)
            {
                return NotFound();
            }

            return View(animails);
        }

        // POST: Animails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animails = await _context.Animails.FindAsync(id);
            _context.Animails.Remove(animails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimailsExists(int id)
        {
            return _context.Animails.Any(e => e.Id == id);
        }
    }
}
