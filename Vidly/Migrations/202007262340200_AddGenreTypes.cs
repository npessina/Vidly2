namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES('Thriller')");
        }

        public override void Down()
        {
        }
    }
}
