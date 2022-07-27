using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Database.Migrations
{
    public partial class AddRoleAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801b2f7d-46dd-42d3-8fd1-ca713e2017a8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0797daaa-8e06-461e-a4e8-c0fe63ca58fb", "6257ea55-02d5-44b6-bbdd-c7bca3f14371", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56ae7003-cb7d-4c17-88f8-f4a3345343e3", "5032ac37-efc7-488f-bfca-1a4411f15251", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0797daaa-8e06-461e-a4e8-c0fe63ca58fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56ae7003-cb7d-4c17-88f8-f4a3345343e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "801b2f7d-46dd-42d3-8fd1-ca713e2017a8", "39f838f7-9389-41d2-983c-321473ad5ddc", "User", "USER" });
        }
    }
}
