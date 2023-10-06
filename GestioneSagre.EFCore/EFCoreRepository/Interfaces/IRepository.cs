namespace GestioneSagre.EFCore.EFCoreRepository.Interfaces;

public interface IRepository<TEntity> where TEntity : class, new()
{
    Task<List<TEntity>> GetItemsAsync();

    Task CreateAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}