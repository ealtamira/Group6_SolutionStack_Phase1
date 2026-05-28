namespace SQLGameDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Thumbnail = c.String(),
                        Status = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        GameUrl = c.String(),
                        Genre = c.String(),
                        Platform = c.String(),
                        Publisher = c.String(),
                        Developer = c.String(),
                        ReleaseDate = c.DateTime(),
                        FreeToGameProfileUrl = c.String(),
                        IsFavoriteGame = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavedGames");
        }
    }
}
