using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AGWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Hard" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Medium" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("21bbf909-108c-4180-bb8d-009f86ce40a8"), "AKL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("2f2e8f4f-4c9b-5d9b-ad7f-2d3e4f5a6b7c"), "NL", "Northland", "https://example.com/images/northland.jpg" },
                    { new Guid("4a5ea8be-0308-4d20-b2ba-9144873728cb"), "WKO", "Waikato", "https://example.com/images/waikato.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("21bbf909-108c-4180-bb8d-009f86ce40a8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2f2e8f4f-4c9b-5d9b-ad7f-2d3e4f5a6b7c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4a5ea8be-0308-4d20-b2ba-9144873728cb"));
        }
    }
}
