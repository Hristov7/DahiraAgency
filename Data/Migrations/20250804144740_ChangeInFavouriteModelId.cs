using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DahiraAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInFavouriteModelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Favourites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                columns: new[] { "UserId", "DestinationId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e45a7be5-2181-46f7-9030-7fe5966c94f9", "AQAAAAIAAYagAAAAEF2nRmPo3DDUegkloLkFA/AYeuqlJgBaieLRAPs8FSYvc3VPteWMZSduReMkmiTdzg==", "3cab2f57-cf7c-47db-83e0-714719dc20a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bba621e7-5c10-4df5-86f3-f009a786e930", "AQAAAAIAAYagAAAAECy37TsSf6obj2ZLcRHhFoighhhXKtc+QWuR0tQwOy8yat24eL3A5FK8aZZCrvgI9w==", "bde69890-8edd-45ef-8393-c6687a115b5f" });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");
        }
    }
}
