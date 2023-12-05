using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CinemaService : ICenimaService
    {
        private readonly AppDBContext dBContext;

        public CinemaService(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Cinema> CreateCinema(Cinema cinema)
        {
            await dBContext.Cinemas.AddAsync(cinema);
            await dBContext.SaveChangesAsync();
            return cinema;
        }

        public async Task<Cinema> DeleteCinema(int id)
        {
            var cinemaToDelete=await dBContext.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
            if(cinemaToDelete is null)
            {
                return null;
            }
            dBContext.Cinemas.Remove(cinemaToDelete);
            await dBContext.SaveChangesAsync();
            return cinemaToDelete;
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas()
        {
            return await dBContext.Cinemas.ToListAsync();
        }

        public async Task<Cinema> GetCinemaById(int id)
        {
            var cinema=await dBContext.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            return cinema;
        }

        public async Task<Cinema> UpdateCinema(int id, Cinema cinema)
        {
            var cinemaToUpdate=await dBContext.Cinemas.FirstOrDefaultAsync(c=> c.Id == id);
            if(cinemaToUpdate is null)
            {
                return null;
            }
            cinemaToUpdate.Name = cinema.Name;
            cinemaToUpdate.Logo=cinema.Logo;
            cinemaToUpdate.Description=cinema.Description;
            await dBContext.SaveChangesAsync();
            return cinemaToUpdate;
        }


    }
}
