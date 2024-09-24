using Microsoft.EntityFrameworkCore;
using TestApi.Domain;

namespace TestApi.Persistence;

public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public virtual DbSet<Book> Book { get; set; }
}
