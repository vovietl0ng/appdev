namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTeams", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserTeams", "TeamId", "dbo.Teams");
            DropIndex("dbo.UserTeams", new[] { "TeamId" });
            DropIndex("dbo.UserTeams", new[] { "UserId" });
            DropTable("dbo.UserTeams");
            DropTable("dbo.Teams");
        }
    }
}
