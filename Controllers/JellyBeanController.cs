using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment6b.JellyBeanDb;
using Assessment6b.Models;

namespace Assessment6b.Controllers
{
    public class JellyBeanController : Controller
    {
        private readonly JellyBeanDbContext _context;

        public JellyBeanController(JellyBeanDbContext context)
        {
            _context = context;
        }

        // GET: JellyBean
        public async Task<IActionResult> Index()
        {
            return View(await _context.JellyBean.ToListAsync());
        }

        // GET: JellyBean/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JellyBean/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Style,Rating")] JellyBean jellyBean)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jellyBean);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jellyBean);
        }

        // GET: JellyBean/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jellyBean = await _context.JellyBean
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jellyBean == null)
            {
                return NotFound();
            }

            return View(jellyBean);
        }

        // POST: JellyBean/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jellyBean = await _context.JellyBean.FindAsync(id);
            _context.JellyBean.Remove(jellyBean);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JellyBeanExists(int id)
        {
            return _context.JellyBean.Any(e => e.Id == id);
        }
    }
}
