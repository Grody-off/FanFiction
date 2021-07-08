using Microsoft.EntityFrameworkCore.Migrations;

namespace FanFiction.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CompositionId",
                table: "Favorites",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_CompositionId",
                table: "Favorites",
                column: "CompositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Compositions_CompositionId",
                table: "Favorites",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Compositions_CompositionId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_CompositionId",
                table: "Favorites");

            migrationBuilder.AlterColumn<string>(
                name: "CompositionId",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
