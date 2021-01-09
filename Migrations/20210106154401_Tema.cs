using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goron_Melisa_Proiect_Medii.Migrations
{
    public partial class Tema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tema",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(nullable: true),
                    Elev = table.Column<string>(nullable: true),
                    DataPublicarii = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tema");
        }
    }
}
