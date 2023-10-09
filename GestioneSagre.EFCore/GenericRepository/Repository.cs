using System.Linq.Expressions;
using GestioneSagre.EFCore.GenericRepository.Interfaces;
using GestioneSagre.EFCore.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GestioneSagre.EFCore.GenericRepository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    public DbContext DbContext { get; }

    public Repository(DbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
        Expression<Func<TEntity, bool>> conditionWhere, Expression<Func<TEntity, dynamic>> orderBy, OrderType orderType = OrderType.Ascending,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (includes != null)
        {
            query = includes(query);
        }

        if (conditionWhere != null)
        {
            query = query.Where(conditionWhere);
        }

        if (orderBy != null)
        {
            switch (orderType)
            {
                case OrderType.Ascending:
                    query = query.OrderBy(orderBy);
                    break;

                case OrderType.Descending:
                    query = query.OrderByDescending(orderBy);
                    break;
            }
        }

        var result = await query.AsNoTracking().ToListAsync(cancellationToken);

        return result;
    }

    public async Task<TEntity> GetItemByIdAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
        Expression<Func<TEntity, bool>> conditionWhere, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (includes != null)
        {
            query = includes(query);
        }

        if (conditionWhere != null)
        {
            query = query.Where(conditionWhere);
        }

        var result = await query.AsNoTracking().FirstOrDefaultAsync(cancellationToken);

        return result;
    }

    public async Task<int> GetItemsCountAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
        Expression<Func<TEntity, bool>> conditionWhere, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (includes != null)
        {
            query = includes(query);
        }

        if (conditionWhere != null)
        {
            query = query.Where(conditionWhere);
        }

        var result = await query.AsNoTracking().CountAsync(cancellationToken);

        return result;
    }

    public async Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            DbContext.Set<TEntity>().Add(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            DbContext.Entry(entity).State = EntityState.Detached;

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            DbContext.Set<TEntity>().Update(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            DbContext.Entry(entity).State = EntityState.Detached;

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            DbContext.Set<TEntity>().Remove(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}