using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seed_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SystemUser",
                newName: "LastName");

            migrationBuilder.InsertData(
                table: "SystemUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "juan.frausto@gmail.com", "John", "Doe", "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "SystemUser",
                newName: "Name");
        }
    }
}
