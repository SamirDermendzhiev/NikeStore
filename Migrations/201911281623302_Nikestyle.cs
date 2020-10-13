namespace NikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nikestyle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Shoe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Shoe_Id });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Client = c.String(),
                        Addres = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.String(),
                        Picture = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoeTags",
                c => new
                    {
                        Shoe_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shoe_Id, t.Tag_Id });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
            DropTable("dbo.ShoeTags");
            DropTable("dbo.Shoes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
