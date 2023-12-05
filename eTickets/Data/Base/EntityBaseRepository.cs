using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDBContext dBContext;

        public EntityBaseRepository(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await dBContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await dBContext.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
            return result;
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
