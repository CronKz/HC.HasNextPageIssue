using Microsoft.EntityFrameworkCore;

namespace TestApi.Persistence;

public static class TestDbInit
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var options = serviceProvider.CreateScope()
            .ServiceProvider
            .GetRequiredService<DbContextOptions<TestDbContext>>();

        using var context = new TestDbContext(options);

        if (context.Database == null)
        {
            throw new Exception("Db is null");
        }

        context.Database.EnsureDeleted();
        context.Database.Migrate();
        context.SaveChanges();
    }
}