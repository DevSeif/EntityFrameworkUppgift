using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkUppgift.Migrations
{
    public partial class Seedingpeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Göteborg", "Olof Olofsson", "0733456021" },
                    { 2, "Stockholm", "Per Persson", "0733456022" },
                    { 3, "Malmö", "Anders Andersson", "0733456023" },
                    { 4, "Borås", "Rolf Rolfsson", "0733456024" },
                    { 5, "Gbg", "Björn Björnsson", "0733456025" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
