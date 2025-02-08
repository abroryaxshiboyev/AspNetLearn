using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bedf951-0bd5-4dea-b4ce-010d95289096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61db7c37-b332-425b-86ec-8dd223501809");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b223b77-1a69-4fcd-8b30-2145bd3745a1", null, "Admin", "ADMIN" },
                    { "2d77a3a5-2c7b-4de8-9a44-517d2f1a4d2b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b223b77-1a69-4fcd-8b30-2145bd3745a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d77a3a5-2c7b-4de8-9a44-517d2f1a4d2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bedf951-0bd5-4dea-b4ce-010d95289096", null, "User", "USER" },
                    { "61db7c37-b332-425b-86ec-8dd223501809", null, "Admin", "ADMIN" }
                });
        }
    }
}
