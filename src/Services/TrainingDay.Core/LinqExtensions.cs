namespace TrainingDay.Core;

public static class LinqExtensions
{
    public static IQueryable<T> Page<T>(this IQueryable<T> queryable,int pageIndex,int pageSize)
    {
        return queryable.Skip(pageSize * pageIndex).Take(pageSize);
    }

}

