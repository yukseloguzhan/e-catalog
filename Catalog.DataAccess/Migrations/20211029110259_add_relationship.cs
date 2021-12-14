using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.DataAccess.Migrations
{
    public partial class add_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Catagories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CatagoryCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Catagories",
                newName: "Id");
        }
    }
}
