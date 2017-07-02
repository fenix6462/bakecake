namespace BakeCake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteProductFromRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Products", new[] { "Recipe_Id" });
            DropColumn("dbo.Products", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Products", "Recipe_Id");
            AddForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
