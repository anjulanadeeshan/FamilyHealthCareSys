CREATE TABLE [dbo].[MemberTb] (
    [MotherId]     INT          NOT NULL,
    [Childname]    VARCHAR (50) NOT NULL,
    [Mothername]   VARCHAR (50) NOT NULL,
    [Add]          VARCHAR (50) NOT NULL,
    [BOD]          VARCHAR (50) NOT NULL,
    [Tel]          VARCHAR (50) NOT NULL,
    [Email]        VARCHAR (50) NOT NULL,
    [Password]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([MotherId] ASC)
);

