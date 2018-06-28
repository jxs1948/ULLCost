using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ULLCost.Models;

namespace ULLCost.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ULLCostContext _context;

        public MoviesController(ULLCostContext context)
        {
            _context = context;
        }

        // GET: Movies
      /*  public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Level.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        } */
        public ActionResult Index(string movieTerm, string movieLevel, string movieGenre, string searchString)
        {
            //Term Query
            var TermLst = new List<string>();

            var TermQry = from a in _context.Movie
                          orderby a.Term
                          select a.Term;
            TermLst.AddRange(TermQry.Distinct());
            ViewBag.movieTerm = new SelectList(TermLst);

            //Level Query
            var LevelLst = new List<string>();

            var LevelQry = from b in _context.Movie
                           orderby b.Level
                           select b.Level;
            LevelLst.AddRange(LevelQry.Distinct());
            ViewBag.movieLevel = new SelectList(LevelLst);

            //Status Query
            var StatusLst = new List<string>();

            var StatusQry = from d in _context.Movie
                           orderby d.Status
                           select d.Status;
            StatusLst.AddRange(StatusQry.Distinct());
            ViewBag.movieGenre = new SelectList(StatusLst);

           
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Level.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Status == movieGenre);
            }

            if (!string.IsNullOrEmpty(movieTerm))
            {
                movies = movies.Where(y => y.Term == movieTerm);
            }

            if (!string.IsNullOrEmpty(movieLevel))
            {
                movies = movies.Where(z => z.Level == movieLevel);
            }

            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Term,Level,State,Status,Credits,Fees")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Term,Level,State,Status,Credits,Fees")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
