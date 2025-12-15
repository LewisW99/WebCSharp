using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameCatalogue.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Genre", "Platform", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "FPS", "PC", 96.0, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Half-Life 2" },
                    { 2, "Adventure", "Nintendo Switch", 97.0, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 3, "Action RPG", "PC", 89.0, new DateTime(2011, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Souls" },
                    { 4, "Sandbox", "Multi-platform", 93.0, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
