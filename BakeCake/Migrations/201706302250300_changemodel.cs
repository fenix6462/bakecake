namespace BakeCake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeProducts", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipeProducts", new[] { "RecipeId" });
            RenameColumn(table: "dbo.RecipeProducts", name: "RecipeId", newName: "Recipe_Id");
            AlterColumn("dbo.RecipeProducts", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.RecipeProducts", "Recipe_Id");
            AddForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeProducts", new[] { "Recipe_Id" });
            AlterColumn("dbo.RecipeProducts", "Recipe_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RecipeProducts", name: "Recipe_Id", newName: "RecipeId");
            CreateIndex("dbo.RecipeProducts", "RecipeId");
            AddForeignKey("dbo.RecipeProducts", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
