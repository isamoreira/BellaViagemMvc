using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViagemBella.Models;

namespace ViagemBella.Controllers
{
    public class PacotesController : Controller
    {
        private readonly BancoDeDadosContext _context;

        public PacotesController(BancoDeDadosContext context)
        {
            _context = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacotes.ToListAsync());
        }

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacotes
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // GET: Pacotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacote,Destino,Diarias,valor")] Pacote pacote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacote);
        }

        // GET: Pacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacotes.FindAsync(id);
            if (pacote == null)
            {
                return NotFound();
            }
            return View(pacote);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacote,Destino,Diarias,valor")] Pacote pacote)
        {
            if (id != pacote.IdPacote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteExists(pacote.IdPacote))
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
            return View(pacote);
        }

        // GET: Pacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacotes
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacote = await _context.Pacotes.FindAsync(id);
            _context.Pacotes.Remove(pacote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteExists(int id)
        {
            return _context.Pacotes.Any(e => e.IdPacote == id);
        }
    }
}
