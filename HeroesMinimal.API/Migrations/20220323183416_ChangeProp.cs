using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesMinimal.API.Migrations
{
    public partial class ChangeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "SuperHeroes");

            migrationBuilder.RenameColumn(
                name: "Nick",
                table: "SuperHeroes",
                newName: "HeroName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "SuperHeroes",
                newName: "AlterEgo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroName",
                table: "SuperHeroes",
                newName: "Nick");

            migrationBuilder.RenameColumn(
                name: "AlterEgo",
                table: "SuperHeroes",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
