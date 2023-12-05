using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
       
        private readonly IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
               
            this.actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var userRoles = HttpContext.Session.GetString("UserRoles");
            if (!string.IsNullOrEmpty(userRoles) && userRoles.Split(',').Contains("Writer"))
            {
                // Render buttons for the "Writer" role
                ViewData["IsWriter"] = true;
            }
            else
            {
                ViewData["IsWriter"] = false;
            }
            var data = await actorsService.GetAllActors();
            return View(data);
        }

        public IActionResult CreateActor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateActor([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            
            await actorsService.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var details=await actorsService.GetActorById(id);
            if (details is null)
            {
                return View("Empty");
            }
            return View(details);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var details = await actorsService.GetActorById(id);
            if (details is null)
            {
                return View("Empty");
            }
            return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {

            await actorsService.UpdateActor(id,actor);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var details = await actorsService.GetActorById(id);
            if (details is null)
            {
                return View("Empty");
            }
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteFromDB(int id)
        {
            await actorsService.DeleteActor(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
