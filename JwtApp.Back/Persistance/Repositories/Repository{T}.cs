using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace JwtApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext jwtContext;
        public Repository(JwtContext jwtContext)
        {
            this.jwtContext = jwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await jwtContext.Set<T>().AddAsync(entity);
            await jwtContext.SaveChangesAsync() ; 
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await jwtContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await jwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await jwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            jwtContext.Set<T>().Remove(entity);
            await jwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            jwtContext.Set<T>().Update(entity);
            await jwtContext.SaveChangesAsync();
        }
    }
}
