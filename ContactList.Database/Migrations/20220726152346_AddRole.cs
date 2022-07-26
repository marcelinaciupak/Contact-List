using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Database.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb5bb24e-2184-44a5-bc69-2a6fda29a9ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8ae827d-bff4-4f27-8855-ac25d1523cf0", "48613919-886a-450d-9a01-ae5efe763b4d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8ae827d-bff4-4f27-8855-ac25d1523cf0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb5bb24e-2184-44a5-bc69-2a6fda29a9ce", "9ee4db84-96e5-4626-8aa9-8b77f112389c", "User", "USER" });
        }
    }
}
