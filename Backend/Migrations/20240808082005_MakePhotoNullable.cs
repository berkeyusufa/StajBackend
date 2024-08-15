using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class MakePhotoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "zBj82spZ4HTU2KHp6H8Y2Q==.YLkf8ZvHbAK898AJLhqsAIOIRgyas4wDaiPmN9bMPt4=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "mgny/and5ygqZQ8mcnYpSQ==.gLX5fk54EcMpdYT1cQe+mYg6JxbeD42wfYJASx8nZmU=");
        }
    }
}
