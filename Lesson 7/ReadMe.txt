1. Создать базу данных Workers

2. CREATE TABLE [dbo].[Workers] (
    [WorkerID]   INT            NOT NULL,
    [FullName]   NVARCHAR (MAX) NULL,
    [Birthday]   DATE           NULL,
    [Position]   NVARCHAR (MAX) NULL,
    [Department] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([WorkerID] ASC)
);

3. Для заполнения таблицы первичными данными раскомментировать
   метод LoadBase() в конструкторе класса DB