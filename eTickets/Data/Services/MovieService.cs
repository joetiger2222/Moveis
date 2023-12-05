using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDBContext dBContext;

        public MovieService(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await dBContext.Movies.Include(m=>m.Cinema).ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movieToReturn=await dBContext.Movies.Include(m=>m.Cinema).Include(m=>m.Producer).FirstOrDefaultAsync(m=>m.Id == id);
            if(movieToReturn == null)
            {
                return null;
            }
            return movieToReturn;
        }
    }
}
