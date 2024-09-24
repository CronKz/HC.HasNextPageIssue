using TestApi.Persistence;
using Microsoft.EntityFrameworkCore;
using TestApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDb"));
    options.EnableSensitiveDataLogging();
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .ModifyPagingOptions(configure =>
    {
        configure.RequirePagingBoundaries = false;
        configure.IncludeTotalCount = true;
        configure.DefaultPageSize = 10;
    })
    .AddPagingArguments()
    .AddDbContextCursorPagingProvider()
    .AddSorting();

var app = builder.Build();

TestDbInit.Initialize(app.Services);

app.MapGraphQL();

app.Run();