using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_bibliotecaMvc.Data;
using csharp_bibliotecaMvc.Models;

namespace csharp_bibliotecaMvc.Controllers
{
    public class LibroesController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
              return _context.Libri != null ? 
                          View(await _context.Libri.ToListAsync()) :
                          Problem("Entity set 'BibliotecaContext.Libri'  is null.");
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            //var libro = await _context.Libri
            //    .FirstOrDefaultAsync(m => m.LibroID == id);
            //if (libro == null)
            //{
            //    return NotFound();
            //}
            var LibroList = await _context.Libri
                .Include(p => p.Prestiti)
                    .ToListAsync();
            foreach (Libro l in LibroList)
            {
                if (l.LibroID == id)
                    return View(l);
            }
            return NotFound();
            
            //return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            Libro myLibro = new Libro();
            myLibro.Autori = new List<Autore>();
            myLibro.Autori.Add(new csharp_bibliotecaMvc.Models.Autore { Nome = "Dante", Cognome = "Alighieri", DataNascita = DateTime.Parse("26/04/1340") });
            myLibro.Autori.Add(new csharp_bibliotecaMvc.Models.Autore { Nome = "Giorgio", Cognome = "Bocca", DataNascita = DateTime.Parse("26/04/1933") });

            return View(myLibro);
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("LibroID,Titolo,Scaffale,Stato")] Libro libro)
        //public async Task<IActionResult> Create([Bind("Titolo,Scaffale,Stato")] Libro libro)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(libro);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(libro);
        //}
        public async Task<IActionResult> Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibroID,Titolo,Scaffale,Stato")] Libro libro)
        {
            if (id != libro.LibroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.LibroID))
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
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri
                .FirstOrDefaultAsync(m => m.LibroID == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libri == null)
            {
                return Problem("Entity set 'BibliotecaContext.Libri'  is null.");
            }
            var libro = await _context.Libri.FindAsync(id);
            if (libro != null)
            {
                _context.Libri.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libri?.Any(e => e.LibroID == id)).GetValueOrDefault();
        }

        public IActionResult AddAutore(int id)
        {
            ViewBag.Id = Convert.ToString(id);
            return View("AddAutore");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAutore([Bind("IdLibro,Nome")] AutoreLibro autoreLibro)
        {
            if (ModelState.IsValid)
            {
                Autore nuovo = new Autore()
                {
                    Nome = autoreLibro.Nome,
                };

                _context.Autori.Add(nuovo);

                var Libro = _context.Libri.FirstOrDefault(m => m.LibroID == autoreLibro.IdLibro);
                if (Libro.Autori == null) 
                { 
                    Libro.Autori = new List<Autore>(); 
                }

                Libro.Autori.Add(nuovo);


                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
