using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkUppgift.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Olof Olofsson", "0733456021" },
                    { 2, 2, "Per Persson", "0733456022" },
                    { 3, 3, "Anders Andersson", "0733456023" },
                    { 4, 4, "Rolf Rolfsson", "0733456024" },
                    { 5, 5, "Björn Björnsson", "0733456025" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
