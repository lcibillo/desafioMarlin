IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Aluno] (
    [idAluno] int NOT NULL IDENTITY,
    [Cpf] bigint NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([idAluno])
);
GO

CREATE TABLE [Turma] (
    [id] int NOT NULL IDENTITY,
    [ano] int NOT NULL,
    CONSTRAINT [PK_Turma] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Matricula] (
    [id] int NOT NULL IDENTITY,
    [AlunoidAluno] int NOT NULL,
    [Turmaid] int NOT NULL,
    CONSTRAINT [PK_Matricula] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Matricula_Aluno_AlunoidAluno] FOREIGN KEY ([AlunoidAluno]) REFERENCES [Aluno] ([idAluno]) ON DELETE CASCADE,
    CONSTRAINT [FK_Matricula_Turma_Turmaid] FOREIGN KEY ([Turmaid]) REFERENCES [Turma] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Matricula_AlunoidAluno] ON [Matricula] ([AlunoidAluno]);
GO

CREATE INDEX [IX_Matricula_Turmaid] ON [Matricula] ([Turmaid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230619213547_Inicio', N'6.0.18');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Matricula] DROP CONSTRAINT [FK_Matricula_Aluno_AlunoidAluno];
GO

ALTER TABLE [Matricula] DROP CONSTRAINT [FK_Matricula_Turma_Turmaid];
GO

DROP INDEX [IX_Matricula_AlunoidAluno] ON [Matricula];
GO

DROP INDEX [IX_Matricula_Turmaid] ON [Matricula];
GO

EXEC sp_rename N'[Matricula].[Turmaid]', N'TurmaId', N'COLUMN';
GO

EXEC sp_rename N'[Matricula].[AlunoidAluno]', N'AlunoId', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230619220041_updateTurmaAlunoId', N'6.0.18');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE UNIQUE INDEX [IX_Matricula_AlunoId] ON [Matricula] ([AlunoId]);
GO

ALTER TABLE [Matricula] ADD CONSTRAINT [FK_Matricula_Aluno_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno] ([idAluno]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230619234651_AlunoMatriculaCriacao', N'6.0.18');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Matricula_AlunoId] ON [Matricula];
GO

CREATE INDEX [IX_Matricula_AlunoId] ON [Matricula] ([AlunoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230620004509_ListaMatriculasAluno', N'6.0.18');
GO

COMMIT;
GO

