namespace ReviewSite.Repositories.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task Delete(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Update(TEntity entity);
    }
}
