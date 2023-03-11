using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewSite.Migrations
{
    /// <inheritdoc />
    public partial class first34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthVisited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearVisited = table.Column<int>(type: "int", nullable: true),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "ImageUrl", "Location", "Name" },
                values: new object[] { 1, null, "\\Images\\Olive_Garden_Logo.svg.png", null, "Olive Garden" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "MonthVisited", "RestaurantsId", "ReviewText", "ReviewerName", "YearVisited" },
                values: new object[] { 1, null, 1, "Olive Garden is great. I'll porbably eat there for lunch again tomorrow.", "Adison", null });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantsId",
                table: "Reviews",
                column: "RestaurantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
