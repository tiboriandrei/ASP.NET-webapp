CREATE TABLE [dbo].[Tasks] (
    [Id]              INT           NOT NULL,
    [TaskName]        NVARCHAR (50) NOT NULL,
    [TaskDescription] NVARCHAR (50) NULL,
    [linkEventID]     INT           NOT NULL,
    [Deadline]        DATETIME2 (7) NOT NULL
);

