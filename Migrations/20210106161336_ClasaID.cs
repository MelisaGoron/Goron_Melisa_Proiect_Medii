using Microsoft.EntityFrameworkCore.Migrations;

namespace Goron_Melisa_Proiect_Medii.Migrations
{
    public partial class ClasaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema");

            migrationBuilder.AlterColumn<int>(
                name: "ClasaID",
                table: "Tema",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema",
                column: "ClasaID",
                principalTable: "Clasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema");

            migrationBuilder.AlterColumn<int>(
                name: "ClasaID",
                table: "Tema",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema",
                column: "ClasaID",
                principalTable: "Clasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
