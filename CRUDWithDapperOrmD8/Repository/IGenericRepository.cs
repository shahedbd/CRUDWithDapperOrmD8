namespace CRUDWithDapperOrmD8.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string tableName);
        Task<T> GetById(string tableName, Int64 id);
        Task Delete(string tableName, Int64 id);
        Task Add(string tableName, T entity);
        Task Update(string tableName, T entity);
    }
}
