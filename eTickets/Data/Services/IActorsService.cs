using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActors();
        Task<Actor> GetActorById(int id);
        Task<Actor>AddActor(Actor actor);
        Task<Actor>UpdateActor(int id , Actor actor);
        Task<Actor>DeleteActor(int id);
    }
}
