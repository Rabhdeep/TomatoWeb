using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abby.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addShoppingCartToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCart_AspNetUsers_ApplicationUserId",
                table: "shoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCart_MenuItem_MenuItemId",
                table: "shoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCart",
                table: "shoppingCart");

            migrationBuilder.RenameTable(
                name: "shoppingCart",
                newName: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCart_MenuItemId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCart_ApplicationUserId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_ApplicationUserId",
                table: "ShoppingCart",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_MenuItem_MenuItemId",
                table: "ShoppingCart",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_ApplicationUserId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_MenuItem_MenuItemId",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "shoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_MenuItemId",
                table: "shoppingCart",
                newName: "IX_shoppingCart_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ApplicationUserId",
                table: "shoppingCart",
                newName: "IX_shoppingCart_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCart",
                table: "shoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCart_AspNetUsers_ApplicationUserId",
                table: "shoppingCart",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCart_MenuItem_MenuItemId",
                table: "shoppingCart",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
