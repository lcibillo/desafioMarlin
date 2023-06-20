using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMarlin.Migrations
{
    public partial class ListaMatriculasAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                unique: true);
        }
    }
}
