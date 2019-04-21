namespace VisitorAccountingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorAccountingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateTimeToComeIn = c.DateTime(nullable: false),
                        DateTimeToComeOut = c.DateTime(nullable: false),
                        NumberIdentification = c.Long(nullable: false),
                        VisitPurpose = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitors");
        }
    }
}
