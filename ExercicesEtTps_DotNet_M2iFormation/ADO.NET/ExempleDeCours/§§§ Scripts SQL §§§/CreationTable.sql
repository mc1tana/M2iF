DROP TABLE UTILISATEUR

CREATE TABLE [dbo].[UTILISATEUR]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[NOM] VARCHAR(50) NOT NULL,
	[PRENOM] VARCHAR(50) NOT NULL,
	[EMAIL] VARCHAR(50) NOT NULL,	
	[TELEPHONE] VARCHAR(17) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);