CREATE TABLE [dbo].[tblExperience] (
    [USERID]    INT          NOT NULL,
    [YEAR]      VARCHAR (50) NOT NULL,
    [LEARING]   VARCHAR (50) NOT NULL,
    [INSTITUTE] VARCHAR (50) NOT NULL,
    CONSTRAINT [FK_tblExperience_tblUserData] FOREIGN KEY ([USERID]) REFERENCES [dbo].[tblUserData] ([USERID])
);

