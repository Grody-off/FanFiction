using Microsoft.EntityFrameworkCore.Migrations;

namespace FanFiction.Migrations
{
    public partial class Favoritesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Favorites_FavoritesId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_FavoritesId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "Compositions");

            migrationBuilder.AddColumn<string>(
                name: "СompositionId",
                table: "Favorites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_СompositionId",
                table: "Favorites",
                column: "СompositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Compositions_СompositionId",
                table: "Favorites",
                column: "СompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Compositions_СompositionId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_СompositionId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "СompositionId",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "Compositions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_FavoritesId",
                table: "Compositions",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Favorites_FavoritesId",
                table: "Compositions",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
