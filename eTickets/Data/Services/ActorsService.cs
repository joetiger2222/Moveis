using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDBContext dBContext;

        public ActorsService(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Actor> AddActor(Actor actor)
        {
            await dBContext.Actors.AddAsync(actor);
            await dBContext.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> DeleteActor(int id)
        {
            var actorToDelete=await dBContext.Actors.FirstOrDefaultAsync(a=>a.Id==id);
            dBContext.Actors.Remove(actorToDelete);
            await dBContext.SaveChangesAsync();
            return actorToDelete;
        }

        public async Task<Actor> GetActorById(int id)
        {
            var actor=await dBContext.Actors.FirstOrDefaultAsync(a=>a.Id==id);
            if(actor is null)
            {
                return null;
            }
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var actors =await dBContext.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor> UpdateActor(int id, Actor actor)
        {
            var actorToUpdate=await dBContext.Actors.FirstOrDefaultAsync(a=>a.Id==id);
            
            actorToUpdate.ProfilePictureURL=actor.ProfilePictureURL;
            actorToUpdate.FullName=actor.FullName;
            actorToUpdate.Bio=actor.Bio;
            await dBContext.SaveChangesAsync();
            return actorToUpdate;

        }
    }
}
