using Microsoft.EntityFrameworkCore;
using ReviewSite.Context;
using ReviewSite.Repositories.interfaces;

namespace ReviewSite.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RestaurantContext context;

        public Repository(RestaurantContext dbcontext)
        {
            context = dbcontext;
        }
        protected DbContext Context { get { return context; } }



        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
