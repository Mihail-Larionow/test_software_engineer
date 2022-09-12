CREATE TABLE [dbo].[Schedule] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Подразделение] NVARCHAR (50) NOT NULL,
    [Должность]     NVARCHAR (50) NOT NULL,
    [Дата]          DATE          NOT NULL,
    [Количество]    NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

