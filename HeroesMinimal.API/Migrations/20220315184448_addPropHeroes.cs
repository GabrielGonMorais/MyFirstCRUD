using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesMinimal.API.Migrations
{
    public partial class addPropHeroes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "SuperHeroes");
        }
    }
}
