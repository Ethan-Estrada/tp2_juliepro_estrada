namespace JuliePro.Services
{
    public interface IServiceBase<T> where T : class
    {
        T Create(T entity);
        void Delete(int id);
        IReadOnlyList<T> GetAll();
        IPaginatedList<T> GetAllPaginated(int pageIndex, int pageSize);
        T GetById(int id);
        void Edit(T entity);
        bool Exists(int id);
    }
}
