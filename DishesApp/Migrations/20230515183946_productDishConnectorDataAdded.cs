using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishesApp.Migrations
{
    public partial class productDishConnectorDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDish_Dishes_DishId",
                table: "ProductDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDish_Products_ProductId",
                table: "ProductDish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDish",
                table: "ProductDish");

            migrationBuilder.DropIndex(
                name: "IX_ProductDish_ProductId",
                table: "ProductDish");

            migrationBuilder.RenameTable(
                name: "ProductDish",
                newName: "ProductDishConnectors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDishConnectors",
                table: "ProductDishConnectors",
                columns: new[] { "ProductId", "DishId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDishConnectors_DishId",
                table: "ProductDishConnectors",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDishConnectors_Dishes_DishId",
                table: "ProductDishConnectors",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDishConnectors_Products_ProductId",
                table: "ProductDishConnectors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDishConnectors_Dishes_DishId",
                table: "ProductDishConnectors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDishConnectors_Products_ProductId",
                table: "ProductDishConnectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDishConnectors",
                table: "ProductDishConnectors");

            migrationBuilder.DropIndex(
                name: "IX_ProductDishConnectors_DishId",
                table: "ProductDishConnectors");

            migrationBuilder.RenameTable(
                name: "ProductDishConnectors",
                newName: "ProductDish");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDish",
                table: "ProductDish",
                columns: new[] { "DishId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDish_ProductId",
                table: "ProductDish",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDish_Dishes_DishId",
                table: "ProductDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDish_Products_ProductId",
                table: "ProductDish",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
