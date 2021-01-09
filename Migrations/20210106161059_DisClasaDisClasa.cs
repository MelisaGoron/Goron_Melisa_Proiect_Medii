using Microsoft.EntityFrameworkCore.Migrations;

namespace Goron_Melisa_Proiect_Medii.Migrations
{
    public partial class DisClasaDisClasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasaID",
                table: "Tema",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClasa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDisciplina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TemaDisciplina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemaID = table.Column<int>(nullable: false),
                    DisciplinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemaDisciplina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemaDisciplina_Disciplina_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disciplina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemaDisciplina_Tema_TemaID",
                        column: x => x.TemaID,
                        principalTable: "Tema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tema_ClasaID",
                table: "Tema",
                column: "ClasaID");

            migrationBuilder.CreateIndex(
                name: "IX_TemaDisciplina_DisciplinaID",
                table: "TemaDisciplina",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_TemaDisciplina_TemaID",
                table: "TemaDisciplina",
                column: "TemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema",
                column: "ClasaID",
                principalTable: "Clasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tema_Clasa_ClasaID",
                table: "Tema");

            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.DropTable(
                name: "TemaDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Tema_ClasaID",
                table: "Tema");

            migrationBuilder.DropColumn(
                name: "ClasaID",
                table: "Tema");
        }
    }
}
