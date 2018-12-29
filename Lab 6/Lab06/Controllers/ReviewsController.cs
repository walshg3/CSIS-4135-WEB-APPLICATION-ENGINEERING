using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab06.Models;

namespace Lab06.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly Lab06Context _context;

        public ReviewsController(Lab06Context context)
        {
            _context = context;
        }


        // GET: Reviews
        public async Task<IActionResult> Index(string sortby, string direction)
        {
            if (sortby == null && direction == null)
            {
                return View(await _context.Review.ToListAsync());
            }
            
            var reviews = await _context.Review.OrderBy(r => r.Reviewer).ToListAsync();
            if (sortby == "reviewer" && direction == "desc")
            { //descending sort by reviewer
                reviews = await _context.Review.OrderByDescending(r => r.Reviewer).ToListAsync();
            } else if (sortby == "movie" && direction == "asc")
            { //ascending sort by movie title
                reviews = await _context.Review.OrderBy(r => r.MovieTitle).ToListAsync();
            } else if (sortby == "movie" && direction == "desc")
            { //descending sort by movie title
                reviews = await _context.Review.OrderByDescending(r => r.MovieTitle).ToListAsync();
            } else
            { //ascending sort by reviewer
                reviews = await _context.Review.OrderBy(r => r.Reviewer).ToListAsync();
            }
            
            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }
        
        // GET: Reviews/Create/1
        public IActionResult Create(int? id, string movieTitle)
        {
            if (id == null) { id = 0; }
            ViewData["thisMovieID"] = id;
            ViewData["thisMovieTitle"] = movieTitle;
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Reviewer,UserReview,MovieID,MovieTitle")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details{"/" + review.MovieID}", "Movies");
            }
            ViewData["thisMovieID"] = review.MovieID;
            ViewData["thisMovieTitle"] = review.MovieTitle;
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Reviewer,UserReview,MovieID,MovieTitle")] Review review)
        {
            if (id != review.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction($"Details{"/" + review.MovieID}", "Movies");
            }
            ViewData["thisMovieID"] = review.MovieID;
            ViewData["thisMovieTitle"] = review.MovieTitle;
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.FindAsync(id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction($"Details{"/" + review.MovieID}", "Movies");
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ID == id);
        }
    }
}
