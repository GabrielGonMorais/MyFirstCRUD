using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesMinimal.API.Migrations
{
    public partial class AddNewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Comic_ComicID",
                table: "SuperHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comic",
                table: "Comic");

            migrationBuilder.RenameTable(
                name: "Comic",
                newName: "Comics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comics",
                table: "Comics",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Comics_ComicID",
                table: "SuperHeroes",
                column: "ComicID",
                principalTable: "Comics",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Comics_ComicID",
                table: "SuperHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comics",
                table: "Comics");

            migrationBuilder.RenameTable(
                name: "Comics",
                newName: "Comic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comic",
                table: "Comic",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Comic_ComicID",
                table: "SuperHeroes",
                column: "ComicID",
                principalTable: "Comic",
                principalColumn: "ID");
        }
    }
}
