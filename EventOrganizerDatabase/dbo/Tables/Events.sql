CREATE TABLE [dbo].[Events] (
    [Id]               INT           NOT NULL,
    [EventName]        NVARCHAR (50) NOT NULL,
    [EventDescription] NVARCHAR (50) NULL,
    [StartDate]        DATETIME2 (7) NOT NULL,
    [EndDate]          DATETIME2 (7) NOT NULL,
    [userID]           INT           NULL
);

