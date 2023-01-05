using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class MOdelSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Description", "Name" },
                values: new object[] { 100, "Supplier 100 Desc", "Supplier 100" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 100);
        }
    }
}
