using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReviewSite.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "hamburgerz", "foodlover247" },
                    { 2, "potato7", "foodcritic101" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
