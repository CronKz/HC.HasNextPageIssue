using HotChocolate.Data.Sorting;
using TestApi.Persistence;
using TestApi.Domain;

namespace TestApi;

public class Query
{
    [UsePaging]
    [UseSorting]
    public IQueryable<Book> GetBooks(ISortingContext sorting, TestDbContext context)
    {
        sorting.Handled(false);

        sorting.OnAfterSortingApplied<IQueryable<Book>>(
            static (sortingApplied, query) =>
            {
                if (sortingApplied && query is IOrderedQueryable<Book> ordered)
                {
                    return ordered.ThenBy(b => b.Id);
                }

                return query.OrderBy(b => b.Id);
            });

        return context.Book.AsQueryable();
    }
}