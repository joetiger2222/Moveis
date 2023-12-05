using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDBContext dBContext;

        public ProducerController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await dBContext.Producers.ToListAsync();
            return View(producers);
        }
    }
}
