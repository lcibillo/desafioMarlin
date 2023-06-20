using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMarlin.Migrations
{
    public partial class entidadeMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoidAluno = table.Column<int>(type: "int", nullable: false),
                    turmaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_alunoidAluno",
                        column: x => x.alunoidAluno,
                        principalTable: "Aluno",
                        principalColumn: "idAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Turma_turmaid",
                        column: x => x.turmaid,
                        principalTable: "Turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_alunoidAluno",
                table: "Matricula",
                column: "alunoidAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_turmaid",
                table: "Matricula",
                column: "turmaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
