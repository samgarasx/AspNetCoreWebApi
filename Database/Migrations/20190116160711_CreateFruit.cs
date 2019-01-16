using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebApi.Database.Migrations
{
    public partial class CreateFruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fruit",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    no = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fruit", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fruit_no",
                table: "fruit",
                column: "no",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fruit");
        }
    }
}
