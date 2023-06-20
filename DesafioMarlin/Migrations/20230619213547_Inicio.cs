using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMarlin.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    idAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.idAluno);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoidAluno = table.Column<int>(type: "int", nullable: false),
                    Turmaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_AlunoidAluno",
                        column: x => x.AlunoidAluno,
                        principalTable: "Aluno",
                        principalColumn: "idAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Turma_Turmaid",
                        column: x => x.Turmaid,
                        principalTable: "Turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoidAluno",
                table: "Matricula",
                column: "AlunoidAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Turmaid",
                table: "Matricula",
                column: "Turmaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
