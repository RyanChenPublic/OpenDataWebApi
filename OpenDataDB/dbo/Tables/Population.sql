CREATE TABLE [dbo].[Population] (
    [site_id]            NVARCHAR (50) NOT NULL,
    [people_total]       NVARCHAR (50) NOT NULL,
    [area]               NVARCHAR (50) NOT NULL,
    [population_density] NVARCHAR (50) NOT NULL,
    [statistic_yyy]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Population] PRIMARY KEY CLUSTERED ([site_id] ASC)
);

