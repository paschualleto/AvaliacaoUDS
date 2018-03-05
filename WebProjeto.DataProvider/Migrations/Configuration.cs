namespace WebProjeto.DataProvider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<WebProjeto.DataProvider.Context.WebProjetoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebProjeto.DataProvider.Context.WebProjetoContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebProjeto.DataProvider.Context.WebProjetoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
