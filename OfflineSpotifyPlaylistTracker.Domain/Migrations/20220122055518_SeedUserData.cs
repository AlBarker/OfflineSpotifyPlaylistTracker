using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfflineSpotifyPlaylistTracker.Domain.Migrations
{
    public partial class SeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "ImageName" },
                values: new object[,]
                {
                    { "1232101260", "Chris Quigley", "cq" },
                    { "1233033915", "Alex Barker", "ab" },
                    { "1238290776", "Joshua Landy", "jl" },
                    { "1244598275", "Daniel Hornblower", "db" },
                    { "1278556031", "Matt Knightbridge", "mk" },
                    { "braeden.wilson", "Braeden Wilson", "bw" },
                    { "genjamon1234", "Josh Anderson", "ja" },
                    { "griffkyn22", "Griffyn Heels", "gh" },
                    { "karnage11i", "Alex Karney", "ak" },
                    { "magsatire", "Jack McGrath", "jm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1232101260");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1233033915");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1238290776");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1244598275");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1278556031");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "braeden.wilson");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "genjamon1234");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "griffkyn22");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "karnage11i");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "magsatire");
        }
    }
}
