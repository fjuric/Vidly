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
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Index()
        {
            var viewMovieModel = _context.Movies.Include(m => m.Genre).ToList();
            /*var movies = new List<Movie> {
            new Movie { Id = 1, Name = "Shrek" },
            new Movie { Id = 2, Name = "Wall-e" }
            };
            var viewMovieModel = new ListMovieViewModel
            {
                Movies = movies
            };*/
            return View(viewMovieModel);
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
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}