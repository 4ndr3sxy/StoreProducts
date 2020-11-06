
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/06/2020 14:43:14
-- Generated from EDMX file: C:\Users\EKS-UAI\source\repos\StoreProducts\ConectDB\ProductModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_store_product];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__transacti__fk_co__145C0A3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[transaction] DROP CONSTRAINT [FK__transacti__fk_co__145C0A3F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product];
GO
IF OBJECT_ID(N'[dbo].[transaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[transaction];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [code] int  NOT NULL,
    [name] varchar(32)  NOT NULL,
    [status] varchar(32)  NULL,
    [defective] bit  NOT NULL,
    [stock] int  NOT NULL
);
GO

-- Creating table 'transactions'
CREATE TABLE [dbo].[transactions] (
    [id] int  NOT NULL,
    [fk_code_product] int  NOT NULL,
    [amount] int  NOT NULL,
    [typeT] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [code] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([code] ASC);
GO

-- Creating primary key on [id] in table 'transactions'
ALTER TABLE [dbo].[transactions]
ADD CONSTRAINT [PK_transactions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fk_code_product] in table 'transactions'
ALTER TABLE [dbo].[transactions]
ADD CONSTRAINT [FK__transacti__fk_co__145C0A3F]
    FOREIGN KEY ([fk_code_product])
    REFERENCES [dbo].[products]
        ([code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__transacti__fk_co__145C0A3F'
CREATE INDEX [IX_FK__transacti__fk_co__145C0A3F]
ON [dbo].[transactions]
    ([fk_code_product]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------