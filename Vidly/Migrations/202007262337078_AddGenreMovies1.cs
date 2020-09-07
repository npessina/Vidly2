namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddGenreMovies1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "IdGenre");
        }

        public override void Down()
        {
            AddColumn("dbo.Movies", "IdGenre", c => c.Byte(nullable: false));
        }
    }
}
