using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class ConfigureReleationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductsProductId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagsTagId",
                table: "ProductTag");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.RenameTable(
                name: "ProductTag",
                newName: "ProductTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagsTagId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagsTagId");

            migrationBuilder.AddColumn<int>(
                name: "SelectedProductProductId",
                table: "LineItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                columns: new[] { "ProductsProductId", "TagsTagId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_SelectedProductProductId",
                table: "LineItem",
                column: "SelectedProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Products_SelectedProductProductId",
                table: "LineItem",
                column: "SelectedProductProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductsProductId",
                table: "ProductTags",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagsTagId",
                table: "ProductTags",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Products_SelectedProductProductId",
                table: "LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductsProductId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagsTagId",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_SelectedProductProductId",
                table: "LineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "SelectedProductProductId",
                table: "LineItem");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "ProductTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagsTagId",
                table: "ProductTag",
                newName: "IX_ProductTag_TagsTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                columns: new[] { "ProductsProductId", "TagsTagId" });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductsProductId",
                table: "ProductTag",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagsTagId",
                table: "ProductTag",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
