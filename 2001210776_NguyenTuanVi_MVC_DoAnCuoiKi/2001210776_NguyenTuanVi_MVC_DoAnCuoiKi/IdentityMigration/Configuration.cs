namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.IdentityMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"IdentityMigration";
        }

        protected override void Seed(_2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
