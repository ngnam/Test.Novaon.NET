using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Novaon.Web.Infrastructure.Data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AppTest");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "AppTest",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 1000, nullable: true),
                    OnCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "AppTest",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "AppTest");
        }
    }
}
