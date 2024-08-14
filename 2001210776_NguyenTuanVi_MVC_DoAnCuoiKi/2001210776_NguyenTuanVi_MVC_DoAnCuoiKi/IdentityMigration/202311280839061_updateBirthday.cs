namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBirthday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.String());
        }
    }
}
