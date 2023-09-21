using System.Linq.Expressions;
using GestioneSagre.EFCore.Models.Enums;
using Microsoft.EntityFrameworkCore.Query;

namespace GestioneSagre.EFCore.Models.Options;

public class OrderedItems<T>
{
    public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }
    public Expression<Func<T, bool>> ConditionWhere { get; set; }
    public Expression<Func<T, dynamic>> OrderBy { get; set; }
    public OrderType OrderType { get; set; }
}