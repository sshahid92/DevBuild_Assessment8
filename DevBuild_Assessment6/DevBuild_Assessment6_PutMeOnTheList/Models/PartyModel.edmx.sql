
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2018 10:01:55
-- Generated from EDMX file: C:\Users\sshahid\source\repos\DevBuild_Assessment6\DevBuild_Assessment6-master\DevBuild_Assessment6_PutMeOnTheList\Models\PartyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShahPartyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Dish_Guest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dish] DROP CONSTRAINT [FK_Dish_Guest];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[Guest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guest];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dishes'
CREATE TABLE [dbo].[Dishes] (
    [DishID] int IDENTITY(1,1) NOT NULL,
    [PersonName] nvarchar(50)  NULL,
    [PhoneNumber] nvarchar(24)  NULL,
    [DishName] nvarchar(50)  NULL,
    [DishDescription] nvarchar(100)  NULL,
    [Option] nvarchar(20)  NULL,
    [GuestID] int  NOT NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [GuestID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [AttendanceDate] datetime  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Guest1] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DishID] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [PK_Dishes]
    PRIMARY KEY CLUSTERED ([DishID] ASC);
GO

-- Creating primary key on [GuestID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([GuestID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GuestID] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [FK_Dish_Guest]
    FOREIGN KEY ([GuestID])
    REFERENCES [dbo].[Guests]
        ([GuestID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dish_Guest'
CREATE INDEX [IX_FK_Dish_Guest]
ON [dbo].[Dishes]
    ([GuestID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------