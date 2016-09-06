namespace MultiList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateListItemDescriptionAsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lists", "ListDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lists", "ListDescription", c => c.Int(nullable: false));
        }
    }
}
