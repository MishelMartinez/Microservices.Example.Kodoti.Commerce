using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for default 1", "Producto 1", 707m },
                    { 2, "Description for default 2", "Producto 2", 410m },
                    { 3, "Description for default 3", "Producto 3", 448m },
                    { 4, "Description for default 4", "Producto 4", 387m },
                    { 5, "Description for default 5", "Producto 5", 563m },
                    { 6, "Description for default 6", "Producto 6", 266m },
                    { 7, "Description for default 7", "Producto 7", 484m },
                    { 8, "Description for default 8", "Producto 8", 523m },
                    { 9, "Description for default 9", "Producto 9", 860m },
                    { 10, "Description for default 10", "Producto 10", 436m },
                    { 11, "Description for default 11", "Producto 11", 818m },
                    { 12, "Description for default 12", "Producto 12", 352m },
                    { 13, "Description for default 13", "Producto 13", 996m },
                    { 14, "Description for default 14", "Producto 14", 232m },
                    { 15, "Description for default 15", "Producto 15", 500m },
                    { 16, "Description for default 16", "Producto 16", 196m },
                    { 17, "Description for default 17", "Producto 17", 487m },
                    { 18, "Description for default 18", "Producto 18", 903m },
                    { 19, "Description for default 19", "Producto 19", 496m },
                    { 20, "Description for default 20", "Producto 20", 599m },
                    { 21, "Description for default 21", "Producto 21", 552m },
                    { 22, "Description for default 22", "Producto 22", 480m },
                    { 23, "Description for default 23", "Producto 23", 962m },
                    { 24, "Description for default 24", "Producto 24", 798m },
                    { 25, "Description for default 25", "Producto 25", 775m },
                    { 26, "Description for default 26", "Producto 26", 647m },
                    { 27, "Description for default 27", "Producto 27", 371m },
                    { 28, "Description for default 28", "Producto 28", 679m },
                    { 29, "Description for default 29", "Producto 29", 135m },
                    { 30, "Description for default 30", "Producto 30", 264m },
                    { 31, "Description for default 31", "Producto 31", 417m },
                    { 32, "Description for default 32", "Producto 32", 284m },
                    { 33, "Description for default 33", "Producto 33", 533m },
                    { 34, "Description for default 34", "Producto 34", 605m },
                    { 35, "Description for default 35", "Producto 35", 256m },
                    { 36, "Description for default 36", "Producto 36", 505m },
                    { 37, "Description for default 37", "Producto 37", 985m },
                    { 38, "Description for default 38", "Producto 38", 553m },
                    { 39, "Description for default 39", "Producto 39", 401m },
                    { 40, "Description for default 40", "Producto 40", 104m },
                    { 41, "Description for default 41", "Producto 41", 623m },
                    { 42, "Description for default 42", "Producto 42", 984m },
                    { 43, "Description for default 43", "Producto 43", 347m },
                    { 44, "Description for default 44", "Producto 44", 521m },
                    { 45, "Description for default 45", "Producto 45", 425m },
                    { 46, "Description for default 46", "Producto 46", 659m },
                    { 47, "Description for default 47", "Producto 47", 290m },
                    { 48, "Description for default 48", "Producto 48", 956m },
                    { 49, "Description for default 49", "Producto 49", 305m },
                    { 50, "Description for default 50", "Producto 50", 558m },
                    { 51, "Description for default 51", "Producto 51", 631m },
                    { 52, "Description for default 52", "Producto 52", 970m },
                    { 53, "Description for default 53", "Producto 53", 919m },
                    { 54, "Description for default 54", "Producto 54", 301m },
                    { 55, "Description for default 55", "Producto 55", 999m },
                    { 56, "Description for default 56", "Producto 56", 290m },
                    { 57, "Description for default 57", "Producto 57", 420m },
                    { 58, "Description for default 58", "Producto 58", 911m },
                    { 59, "Description for default 59", "Producto 59", 442m },
                    { 60, "Description for default 60", "Producto 60", 357m },
                    { 61, "Description for default 61", "Producto 61", 467m },
                    { 62, "Description for default 62", "Producto 62", 511m },
                    { 63, "Description for default 63", "Producto 63", 616m },
                    { 64, "Description for default 64", "Producto 64", 553m },
                    { 65, "Description for default 65", "Producto 65", 982m },
                    { 66, "Description for default 66", "Producto 66", 607m },
                    { 67, "Description for default 67", "Producto 67", 946m },
                    { 68, "Description for default 68", "Producto 68", 329m },
                    { 69, "Description for default 69", "Producto 69", 281m },
                    { 70, "Description for default 70", "Producto 70", 156m },
                    { 71, "Description for default 71", "Producto 71", 759m },
                    { 72, "Description for default 72", "Producto 72", 244m },
                    { 73, "Description for default 73", "Producto 73", 621m },
                    { 74, "Description for default 74", "Producto 74", 901m },
                    { 75, "Description for default 75", "Producto 75", 513m },
                    { 76, "Description for default 76", "Producto 76", 296m },
                    { 77, "Description for default 77", "Producto 77", 597m },
                    { 78, "Description for default 78", "Producto 78", 968m },
                    { 79, "Description for default 79", "Producto 79", 624m },
                    { 80, "Description for default 80", "Producto 80", 423m },
                    { 81, "Description for default 81", "Producto 81", 281m },
                    { 82, "Description for default 82", "Producto 82", 513m },
                    { 83, "Description for default 83", "Producto 83", 145m },
                    { 84, "Description for default 84", "Producto 84", 979m },
                    { 85, "Description for default 85", "Producto 85", 485m },
                    { 86, "Description for default 86", "Producto 86", 304m },
                    { 87, "Description for default 87", "Producto 87", 659m },
                    { 88, "Description for default 88", "Producto 88", 283m },
                    { 89, "Description for default 89", "Producto 89", 360m },
                    { 90, "Description for default 90", "Producto 90", 513m },
                    { 91, "Description for default 91", "Producto 91", 270m },
                    { 92, "Description for default 92", "Producto 92", 952m },
                    { 93, "Description for default 93", "Producto 93", 866m },
                    { 94, "Description for default 94", "Producto 94", 192m },
                    { 95, "Description for default 95", "Producto 95", 492m },
                    { 96, "Description for default 96", "Producto 96", 925m },
                    { 97, "Description for default 97", "Producto 97", 662m },
                    { 98, "Description for default 98", "Producto 98", 419m },
                    { 99, "Description for default 99", "Producto 99", 687m },
                    { 100, "Description for default 100", "Producto 100", 445m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 8 },
                    { 3, 3, 9 },
                    { 4, 4, 5 },
                    { 5, 5, 6 },
                    { 6, 6, 15 },
                    { 7, 7, 1 },
                    { 8, 8, 17 },
                    { 9, 9, 0 },
                    { 10, 10, 0 },
                    { 11, 11, 13 },
                    { 12, 12, 17 },
                    { 13, 13, 5 },
                    { 14, 14, 9 },
                    { 15, 15, 17 },
                    { 16, 16, 18 },
                    { 17, 17, 0 },
                    { 18, 18, 19 },
                    { 19, 19, 12 },
                    { 20, 20, 17 },
                    { 21, 21, 11 },
                    { 22, 22, 18 },
                    { 23, 23, 12 },
                    { 24, 24, 3 },
                    { 25, 25, 15 },
                    { 26, 26, 12 },
                    { 27, 27, 0 },
                    { 28, 28, 19 },
                    { 29, 29, 19 },
                    { 30, 30, 12 },
                    { 31, 31, 16 },
                    { 32, 32, 12 },
                    { 33, 33, 6 },
                    { 34, 34, 10 },
                    { 35, 35, 3 },
                    { 36, 36, 1 },
                    { 37, 37, 15 },
                    { 38, 38, 5 },
                    { 39, 39, 8 },
                    { 40, 40, 9 },
                    { 41, 41, 19 },
                    { 42, 42, 1 },
                    { 43, 43, 6 },
                    { 44, 44, 13 },
                    { 45, 45, 13 },
                    { 46, 46, 9 },
                    { 47, 47, 2 },
                    { 48, 48, 0 },
                    { 49, 49, 14 },
                    { 50, 50, 15 },
                    { 51, 51, 17 },
                    { 52, 52, 1 },
                    { 53, 53, 15 },
                    { 54, 54, 18 },
                    { 55, 55, 4 },
                    { 56, 56, 3 },
                    { 57, 57, 6 },
                    { 58, 58, 17 },
                    { 59, 59, 6 },
                    { 60, 60, 17 },
                    { 61, 61, 3 },
                    { 62, 62, 14 },
                    { 63, 63, 1 },
                    { 64, 64, 19 },
                    { 65, 65, 5 },
                    { 66, 66, 15 },
                    { 67, 67, 7 },
                    { 68, 68, 1 },
                    { 69, 69, 1 },
                    { 70, 70, 10 },
                    { 71, 71, 5 },
                    { 72, 72, 10 },
                    { 73, 73, 10 },
                    { 74, 74, 17 },
                    { 75, 75, 0 },
                    { 76, 76, 19 },
                    { 77, 77, 11 },
                    { 78, 78, 12 },
                    { 79, 79, 6 },
                    { 80, 80, 16 },
                    { 81, 81, 6 },
                    { 82, 82, 2 },
                    { 83, 83, 10 },
                    { 84, 84, 12 },
                    { 85, 85, 19 },
                    { 86, 86, 9 },
                    { 87, 87, 0 },
                    { 88, 88, 19 },
                    { 89, 89, 3 },
                    { 90, 90, 16 },
                    { 91, 91, 15 },
                    { 92, 92, 14 },
                    { 93, 93, 5 },
                    { 94, 94, 13 },
                    { 95, 95, 12 },
                    { 96, 96, 7 },
                    { 97, 97, 12 },
                    { 98, 98, 9 },
                    { 99, 99, 18 },
                    { 100, 100, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
