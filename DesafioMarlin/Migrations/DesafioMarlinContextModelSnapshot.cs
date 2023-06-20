﻿// <auto-generated />
using DesafioMarlin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioMarlin.Migrations
{
    [DbContext(typeof(DesafioMarlinContext))]
    partial class DesafioMarlinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesafioMarlin.Aluno", b =>
                {
                    b.Property<int>("idAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAluno"), 1L, 1);

                    b.Property<long>("Cpf")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAluno");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("DesafioMarlin.Matricula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("DesafioMarlin.Turma", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("DesafioMarlin.Matricula", b =>
                {
                    b.HasOne("DesafioMarlin.Aluno", null)
                        .WithMany("Matricula")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioMarlin.Aluno", b =>
                {
                    b.Navigation("Matricula");
                });
#pragma warning restore 612, 618
        }
    }
}
