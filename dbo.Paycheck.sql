CREATE TABLE [dbo].[Paycheck] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Должность] NVARCHAR (50) NOT NULL,
    [Дата]      DATE          NOT NULL,
    [Ставка]    NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

