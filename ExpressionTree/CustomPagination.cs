using System.Linq.Expressions;

namespace ExpressionTree
{
    public static class CustomPagination
    {
        public static IQueryable<TEntity> ToPage<TEntity, TProperty>(
            this IQueryable<TEntity> queryable,
            Expression<Func<TEntity, TProperty>> propertyForPagination,
            TProperty lastValue,
            bool IsDescending = true,
            int take = 10
        )
            where TProperty : IComparable<TProperty>
        {
            var method = typeof(IComparable<TProperty>).GetMethod("CompareTo")!;
            var left = Expression.Call(propertyForPagination.Body, method, Expression.Constant(lastValue));
            var right = Expression.Constant(0);

            if (IsDescending)
                return queryable
                    .Where(
                        Expression.Lambda<Func<TEntity, bool>>(
                            Expression.LessThan(left, right), 
                            propertyForPagination.Parameters
                        )
                    )
                    .OrderByDescending(propertyForPagination)
                    .Take(take);
            return queryable
                .Where(
                    Expression.Lambda<Func<TEntity, bool>>(
                        Expression.GreaterThan(left, right),
                        propertyForPagination.Parameters
                    )
                )
                .OrderBy(propertyForPagination)
                .Take(take);
        }
    }
}
