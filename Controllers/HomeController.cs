using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDbContext _context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            _context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        // add a movie (get)
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Add a movie (post)
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return View("Confirmation");
        }

        // confirmation page!
        public IActionResult Confirmation()
        {
            return View();
        }

        // Show all movies
        [HttpGet]
        public IActionResult MoviesList()
        {
            return View(_context.Movies);
        }

        [HttpGet]
        public IActionResult Update(int movieid)
        {
            // show only that database
            Movie movie = _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie, int movieid)
        {
            // save filter changes to the selected record in the context DB
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Category= movie.Category;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Title = movie.Title;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Director = movie.Director;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Year = movie.Year;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Rating = movie.Rating;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Edited = movie.Edited;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().LentTo = movie.LentTo;
            _context.Movies.Where(m => m.MovieId == movieid).FirstOrDefault().Notes = movie.Notes;

            _context.SaveChanges();

            return View("Confirmation");
        }

        // delete record
        [HttpPost]
        public IActionResult Delete(int movieid)
        {
            Movie movie = _context.Movies.Where(e => e.MovieId == movieid).FirstOrDefault();
            _context.Remove(movie);

            _context.SaveChanges();

            return RedirectToAction("Confirmation");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
