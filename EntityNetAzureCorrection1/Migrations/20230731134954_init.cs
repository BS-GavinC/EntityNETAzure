using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityNetAzureCorrection1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Password", "Pseudo" },
                values: new object[] { 1, new DateTime(2023, 7, 31, 15, 49, 54, 241, DateTimeKind.Local).AddTicks(2279), "User@user.com", "User123=", "UserGuy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Password", "Pseudo" },
                values: new object[] { 2, new DateTime(2023, 7, 31, 15, 49, 54, 241, DateTimeKind.Local).AddTicks(2319), "Admin@admin.com", "Admin123=", "AdminGuy" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
