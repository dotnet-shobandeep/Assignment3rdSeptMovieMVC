using MovieCustomerMvcAppWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMvcAppWithAuthentication.ViewModel;

namespace MovieCustomerMvcAppWithAuthentication.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context1;
        public MoviesController()
        {
            _context1 = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context1.Movies.Include(g=>g.Genre).ToList();

            return View(movies);
        }
        public ActionResult Create()
        {
            var genres = _context1.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                GenreType=genres
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model Binding
        //{
        //    _context1.Movies.Add(movie);
        //    _context1.SaveChanges();
        //    return RedirectToAction("MovInd", "Movies");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    GenreType = _context1.Genres.ToList()
                };
                return View("Create", viewModel);
            }
            if (movie.Id == 0)
            {
                _context1.Movies.Add(movie);
            }
            else
            {



            }


            _context1.SaveChanges();



            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context1.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                //Id = movie.Id,
                //Name = movie.Name,
                //GenreId = movie.GenreId,
                GenreType = _context1.Genres.ToList()
            };
            return View("Create", viewModel);
        }
        public ActionResult DeleteM(int id)
        {
            var movieDel = _context1.Movies.Find(id);
            _context1.Movies.Remove(movieDel);
            _context1.SaveChanges();
            return RedirectToAction("MovInd", "Movies");
        }
        public ActionResult MovDetails(int id)
        {
            var singleMovie = _context1.Movies.SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
                return HttpNotFound();
            return View(singleMovie);
        }
       
        protected override void Dispose(bool disposing)
        {
            _context1.Dispose();
        }
    }
}