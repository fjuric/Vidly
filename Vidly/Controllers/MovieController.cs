using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
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
            var movies = new List<Movie> {
            new Movie { Id = 1, Name = "Shrek" },
            new Movie { Id = 2, Name = "Wall-e" }
            };
            var viewMovieModel = new ListMovieViewModel
            {
                Movies = movies
            };
            return View(viewMovieModel);
        }
        [Route("Movie/Released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}