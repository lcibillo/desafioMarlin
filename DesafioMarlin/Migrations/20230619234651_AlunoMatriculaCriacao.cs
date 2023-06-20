using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMarlin.Migrations
{
    public partial class AlunoMatriculaCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula");
        }
    }
}
