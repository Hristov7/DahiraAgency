using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DahiraAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlANDPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13c31966-a3e1-40a6-a4a9-f1db23c30d7f", "AQAAAAIAAYagAAAAEBQrSlU2ztlmmx1UufaH3hFIKNhJCfzs7gmcHZLmrlXS5y37zIlu9hZz1dVuzTtxhA==", "32d0db8c-2593-4bb8-8d6b-3aff67efcdf6" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beach" },
                    { 2, "Mountain" },
                    { 3, "City" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City of luxury.", "https://lp-cms-production.imgix.net/features/2017/09/dubai-marina-skyline-2c8f1708f2a1.jpg?auto=format,compress&q=72&w=1440&h=810&fit=crop", "Dubai", 1900m },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beautiful mountains.", "https://www.montagnaestate.it/wp-content/uploads/8otmnnrjuhm.jpg", "Swiss Alps", 1500m },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stunning beaches.", "https://digital.ihg.com/is/image/ihg/vignette-collection-noonu-atoll-9970118335-2x1", "Maldives", 2000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be651761-89ac-48a5-92cd-5b62f78a1f9c", "AQAAAAIAAYagAAAAEOWPiLC4Yg1of7TWloQn6j89+UncosVz0Abuerm/HbZ/eaYgCZWfbPbxDqpYYafJ5w==", "8ec87430-1912-489b-85dd-a1eda6a895f2" });
        }
    }
}
