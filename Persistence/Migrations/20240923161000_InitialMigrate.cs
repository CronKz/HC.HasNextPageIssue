using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialMigrate : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Book",
			schema: "dbo",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false),
				Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Book", x => x.Id);
			});

        // Seed initial data
        var books = new object[20, 2];
        for (var i = 0; i < 20; i++)
        {
            books[i, 0] = i + 1;
            books[i, 1] = $"Book #{i + 1}";
        }

        migrationBuilder.InsertData(
            schema: "dbo",
            table: "Book",
            columns: ["Id", "Title"],
            values: books
        );
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(name: "Book");
	}
}

