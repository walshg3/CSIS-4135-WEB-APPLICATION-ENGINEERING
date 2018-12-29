using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab06.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab06.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Lab06Context _context;

        public MoviesController(Lab06Context context)
        {
            _context = context;
        }

        // GET: Movies
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.Movies = await movies.ToListAsync();

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            var reviewData = from r in _context.Review select r;

            if (id != null)
            {
                reviewData = reviewData.Where(x => x.MovieID == id);
            }
            
            ViewData["Reviews"] = await reviewData.ToListAsync();

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
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating,PosterURL")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        

        public async Task<IActionResult> OMDBCreate(string movieName)
        {
            ViewData["exists"] = "false";
            if (movieName == null || movieName == "") {
                ViewData["MovieObject"] = "";
                return View();
            } else {
                //string apikey = iConfig.GetSection("Api_Key").Value;

                HttpClient client = new HttpClient();
                string url = "http://www.omdbapi.com/?apikey=" + "bace53af" + "&t=" + movieName;
                var response = await client.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject(data).ToString();
                dynamic omdbMovie = JObject.Parse(json);

                ViewData["movie"] = json;

                ViewData["omdbMovie"] = omdbMovie;

                Movie movie = new Movie();
                try
                {
                    movie.Title = omdbMovie["Title"];
                    movie.ReleaseDate = omdbMovie["Released"];
                    movie.Genre = omdbMovie["Genre"].ToString().Split(',')[0];
                    movie.PosterURL = omdbMovie["Poster"];

                    ViewData["Rating"] = omdbMovie["Rated"];
                }
                catch
                {

                }

                return View(movie);
            }
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OMDBCreate([Bind("ID,Title,ReleaseDate,Genre,Price,Rating,PosterURL")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                try {
                    if (!MovieTitleExists(movie.Title))
                    {
                        _context.Add(movie);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    } else
                    {
                        ViewData["exists"] = "true";
                    }
                } catch
                {
                    throw;
                }
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

            var movie = await _context.Movie.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating,PosterURL")] Movie movie)
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
                .FirstOrDefaultAsync(m => m.ID == id);
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
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }

        private bool MovieTitleExists(string title)
        {
            return _context.Movie.Any(e => e.Title == title);
        }


    }
}
