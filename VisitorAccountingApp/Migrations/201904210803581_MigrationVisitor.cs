namespace VisitorAccountingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationVisitor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "Condition", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "Condition");
        }
    }
}
