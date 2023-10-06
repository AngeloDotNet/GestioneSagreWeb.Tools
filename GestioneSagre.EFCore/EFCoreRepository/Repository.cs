using GestioneSagre.EFCore.EFCoreRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestioneSagre.EFCore.EFCoreRepository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    public DbContext DbContext { get; }

    public Repository(DbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<TEntity>> GetItemsAsync() => await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();

    public async Task CreateAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);

        await DbContext.SaveChangesAsync();

        DbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);

        await DbContext.SaveChangesAsync();

        DbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);

        await DbContext.SaveChangesAsync();
    }
}