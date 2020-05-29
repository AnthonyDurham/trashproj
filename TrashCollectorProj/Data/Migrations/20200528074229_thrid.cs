using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Data.Migrations
{
    public partial class thrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d48987e0-d721-495c-b88f-3597d67bf327");

            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Address",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f8be026-3d50-4a7a-9fa6-eb1e3065f9a4", "36bf7dfe-0ed6-45cd-b7b1-63d13ee346d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "664864a3-5180-4b10-9c34-b3419cc6b0f3", "5218aff4-4279-4a71-a00c-4df88d997e9e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67d18250-e914-4837-9686-8736fa389a4c", "11952d92-1cdc-4602-a885-5221b1c9f7e5", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f8be026-3d50-4a7a-9fa6-eb1e3065f9a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664864a3-5180-4b10-9c34-b3419cc6b0f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67d18250-e914-4837-9686-8736fa389a4c");

            migrationBuilder.AlterColumn<double>(
                name: "Zip",
                table: "Employees",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Zip",
                table: "Customers",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d48987e0-d721-495c-b88f-3597d67bf327", "5eff9b2e-6d9f-4a9f-a4c1-f050f508d12e", "Admin", "ADMIN" });
        }
    }
}
