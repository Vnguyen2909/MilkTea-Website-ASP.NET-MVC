namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models.DBMilkTeaContext";
        }

        protected override void Seed(_2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
