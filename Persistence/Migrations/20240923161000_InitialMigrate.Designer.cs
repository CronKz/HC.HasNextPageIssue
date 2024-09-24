using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Persistence.Migrations;

[DbContext(typeof(TestDbContext))]
[Migration("20240923161000_InitialMigrate")]
partial class InitialMigrate
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.8")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity("TestApi.Domain.Book", b =>
        {
            b.Property<int>("Id")
                .HasColumnType("int");

            b.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            b.HasKey("Id")
                .HasName("PK_Book");

            b.ToTable("Book", "dbo");
        });
    }
}