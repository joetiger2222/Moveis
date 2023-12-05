using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICenimaService cenimaService;

        public CinemasController(ICenimaService cenimaService)
        {
            this.cenimaService = cenimaService;
        }
        public async Task<IActionResult> Index()
        {
            var userRoles = HttpContext.Session.GetString("UserRoles");

            
            if (!string.IsNullOrEmpty(userRoles) && userRoles.Split(',').Contains("Writer"))
            {
               
                ViewData["IsWriter"] = true;
            }
            else
            {
                ViewData["IsWriter"] = false;
            }
            var cinemas = await cenimaService.GetAllCinemas();
            return View(cinemas);
        }




        public IActionResult Create(int id)
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {

            await cenimaService.CreateCinema(cinema);
            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await cenimaService.GetCinemaById(id);
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {

            await cenimaService.UpdateCinema(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var details = await cenimaService.GetCinemaById(id);
            if (details is null)
            {
                return View("Empty");
            }
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFromDB(int id)
        {
            await cenimaService.DeleteCinema(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
