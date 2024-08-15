using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToBusTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "ILr+YaaLayL7f5CyVi0nAA==.miQQpSTl6bAKOkMGoxrhi6nYmdk8ZWNtBImUVouk74w=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "/JTzQaEDJxC+noeZVkI3sg==.IAXV6H9n4irOdkD9rgOanddkZr5M2CoT6QEvl9gXTD0=");
        }
    }
}
