using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
       
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            
            this.movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var userRoles = HttpContext.Session.GetString("UserRoles");

            // Check if the user has the "Writer" role
            if (!string.IsNullOrEmpty(userRoles) && userRoles.Split(',').Contains("Writer"))
            {
                // Render buttons for the "Writer" role
                ViewData["IsWriter"] = true;
            }
            else
            {
                ViewData["IsWriter"] = false;
            }

            var movies = await movieService.GetAllMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie=await movieService.GetMovieById(id);
            return View(movie);
        }
    }
}
