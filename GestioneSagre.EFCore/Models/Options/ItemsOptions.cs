using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace GestioneSagre.EFCore.Models.Options;

public class ItemsOptions<T>
{
    public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }
    public Expression<Func<T, bool>> ConditionWhere { get; set; }
}