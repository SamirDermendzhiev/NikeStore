namespace NikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ShoeTags");
            AddColumn("dbo.ShoeTags", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShoeTags", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ShoeTags");
            DropColumn("dbo.ShoeTags", "Id");
            AddPrimaryKey("dbo.ShoeTags", new[] { "Shoe_Id", "Tag_Id" });
        }
    }
}
