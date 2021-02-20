namespace DisqueraAlbumes.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicializandoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Año = c.Int(nullable: false),
                        Foto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Album");
        }
    }
}
