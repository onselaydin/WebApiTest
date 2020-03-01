CREATE TABLE [dbo].[Photos] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CityId]      INT            NOT NULL,
    [DateAdded]   DATETIME2 (7)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsMain]      BIT            NOT NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [PublicId]    NVARCHAR (250) NULL
);