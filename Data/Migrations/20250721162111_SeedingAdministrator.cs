using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DahiraAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdministrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "42627712-8789-490d-907d-1e3d908744ff", "IdentityUser", "admin@touristagency.com", true, false, null, "ADMIN@TOURISTAGENCY.COM", "ADMIN@TOURISTAGENCY.COM", "AQAAAAIAAYagAAAAEMr6C8wnZjLdbgoYZHrXNsN+1ez3LdHiW48d1wb1D3llwnThOLi9Rertc7V6wvg4tw==", null, false, "ecc5c8cc-7961-4a98-ab58-9fd941b8f1a7", false, "admin@touristagency.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");
        }
    }
}
