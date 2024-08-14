namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
