namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        customer_id = c.Int(nullable: false),
                        product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.customers", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.product_Id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "product_Id", "dbo.products");
            DropForeignKey("dbo.Rentals", "customer_id", "dbo.customers");
            DropIndex("dbo.Rentals", new[] { "product_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_id" });
            DropTable("dbo.Rentals");
        }
    }
}
