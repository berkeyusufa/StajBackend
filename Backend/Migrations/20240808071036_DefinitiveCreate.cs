using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class DefinitiveCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "mgny/and5ygqZQ8mcnYpSQ==.gLX5fk54EcMpdYT1cQe+mYg6JxbeD42wfYJASx8nZmU=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "k7Yw8qpUi6hz6YF9OP0WYg==.eupamerdw5nRmLA6I9ncnQqruES0uNHeDgnR8s5G52Y=");
        }
    }
}
