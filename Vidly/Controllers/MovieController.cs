using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        /*public ActionResult Random()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Filip"},
                new Customer {Id = 2, Name = "Kata"}
            };
            var viewModel = new ListMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);
        }*/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var viewMovieModel = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (viewMovieModel == null)
                return HttpNotFound();
            return View(viewMovieModel);
        }
        [Route("Movie/Released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var movie = new Movie();
            var viewModel = new MovieFormViewModel
            {
                Genre = genre,
                Movie = movie
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = new Movie(),
                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}