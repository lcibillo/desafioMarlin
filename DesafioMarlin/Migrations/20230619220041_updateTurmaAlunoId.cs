using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMarlin.Migrations
{
    public partial class updateTurmaAlunoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aluno_AlunoidAluno",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Turma_Turmaid",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoidAluno",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_Turmaid",
                table: "Matricula");

            migrationBuilder.RenameColumn(
                name: "Turmaid",
                table: "Matricula",
                newName: "TurmaId");

            migrationBuilder.RenameColumn(
                name: "AlunoidAluno",
                table: "Matricula",
                newName: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Matricula",
                newName: "Turmaid");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Matricula",
                newName: "AlunoidAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoidAluno",
                table: "Matricula",
                column: "AlunoidAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Turmaid",
                table: "Matricula",
                column: "Turmaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aluno_AlunoidAluno",
                table: "Matricula",
                column: "AlunoidAluno",
                principalTable: "Aluno",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Turma_Turmaid",
                table: "Matricula",
                column: "Turmaid",
                principalTable: "Turma",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
