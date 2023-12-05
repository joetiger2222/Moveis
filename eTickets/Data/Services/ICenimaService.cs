using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICenimaService
    {
        Task<IEnumerable<Cinema>> GetAllCinemas();
        Task<Cinema>CreateCinema(Cinema cinema);
        Task<Cinema> GetCinemaById(int id);
        Task<Cinema> UpdateCinema(int id, Cinema cinema);
        Task<Cinema> DeleteCinema(int id);
    }
}
