using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ActionName("New")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult SaveNew(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            movie.DateAdded = DateTime.Now;
            movie.StockAvailable = movie.Stock;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult SaveEdit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.Stock = movie.Stock;

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}