using JuliePro_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services.impl
{



    public class ServiceBaseEF<T> : IServiceBaseAsync<T>, IServiceBase<T> where T : class
    {

        protected readonly JulieProDbContext _dbContext;

        public ServiceBaseEF(JulieProDbContext dbContext) => _dbContext = dbContext;

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }


        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IPaginatedList<T>> GetAllPaginatedAsync(int pageIndex, int pageSize) {

            return await this._dbContext.Set<T>().ToPaginatedAsync(pageIndex, pageSize);
        }

        public virtual  IPaginatedList<T> GetAllPaginated(int pageIndex, int pageSize)
        {

            return this._dbContext.Set<T>().ToPaginated(pageIndex, pageSize);
        }

        public virtual IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public virtual T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }
        public virtual async Task EditAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbContext.Update<T>(entity);
            else _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }


        public virtual void Edit(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbContext.Update<T>(entity);
            else _dbContext.Entry(entity).State = EntityState.Modified;


            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await this.GetByIdAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }


        public virtual bool Exists(int id) {

            return this.GetById(id) != null;


        }

        public async virtual Task<bool> ExistsAsync (int id){

            return (await this.GetByIdAsync(id)) != null;
        
        }


    }
}
