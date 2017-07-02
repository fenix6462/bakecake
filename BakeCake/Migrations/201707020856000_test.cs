namespace BakeCake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.RecipeProducts", new[] { "Product_Id" });
            RenameColumn(table: "dbo.RecipeProducts", name: "Product_Id", newName: "Product_Name");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RecipeProducts", "Product_Name", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.Products", "Name");
            CreateIndex("dbo.RecipeProducts", "Product_Name");
            AddForeignKey("dbo.RecipeProducts", "Product_Name", "dbo.Products", "Name");
            DropColumn("dbo.Products", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RecipeProducts", "Product_Name", "dbo.Products");
            DropIndex("dbo.RecipeProducts", new[] { "Product_Name" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.RecipeProducts", "Product_Name", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AddPrimaryKey("dbo.Products", "Id");
            RenameColumn(table: "dbo.RecipeProducts", name: "Product_Name", newName: "Product_Id");
            CreateIndex("dbo.RecipeProducts", "Product_Id");
            AddForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
