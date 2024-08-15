using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class tamgaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "Tpa7N28056UAqeFalvK7xg==.C/PFjqh1+JEbjNmwwvN4W7cc5HGJuO7lf0Zrs3qgDBs=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "PR6hdSPX8o9tEv43j8+Aow==.tZnpBBAEhVXbPnhhYFfvn8fKiznO9B1ux9DETjDu8sU=");
        }
    }
}
