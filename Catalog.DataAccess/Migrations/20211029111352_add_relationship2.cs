using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.DataAccess.Migrations
{
    public partial class add_relationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CatagoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatagoryCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatagoryCategoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Catagories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CatagoryCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryCategoryId",
                table: "Products",
                column: "CatagoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CatagoryCategoryId",
                table: "Products",
                column: "CatagoryCategoryId",
                principalTable: "Catagories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
