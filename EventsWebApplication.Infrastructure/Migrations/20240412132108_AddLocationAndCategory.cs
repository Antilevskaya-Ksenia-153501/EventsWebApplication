using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsWebApplication.Infrastructure.Migrations
{
    public partial class AddLocationAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("52191551-d43e-48f2-92c8-676fd6977fcf"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fd2b9d78-f72b-44da-9316-9bca4331ccce"));

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Events",
                newName: "CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("93c4f225-a7b1-4fb9-96e4-d69adef2b37d"), "Category 2" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("95e167a1-e4ca-4a97-8e0a-76af1a2dfbd3"), "Category 1" });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("167aa350-b65e-454e-bb6f-d1de0cbc51c2"), "Location 2" });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("483a445b-49c2-41fa-9161-42758c1a11da"), "Location 1" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "DateTime", "Description", "Image", "LocationId", "MaxParticipants", "Name" },
                values: new object[] { new Guid("c4f21aa6-111f-4e73-8162-a6b4d559f42c"), new Guid("93c4f225-a7b1-4fb9-96e4-d69adef2b37d"), null, new DateTime(2024, 4, 14, 16, 21, 4, 101, DateTimeKind.Local).AddTicks(5684), "Description of Event 2", "event2.jpg", new Guid("167aa350-b65e-454e-bb6f-d1de0cbc51c2"), 50, "Event 2" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "DateTime", "Description", "Image", "LocationId", "MaxParticipants", "Name" },
                values: new object[] { new Guid("fdd34aea-4b4d-4668-a25a-dcab04bf2175"), new Guid("95e167a1-e4ca-4a97-8e0a-76af1a2dfbd3"), null, new DateTime(2024, 4, 13, 16, 21, 4, 101, DateTimeKind.Local).AddTicks(5656), "Description of Event 1", "event1.jpg", new Guid("483a445b-49c2-41fa-9161-42758c1a11da"), 100, "Event 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId1",
                table: "Events",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Category_CategoryId1",
                table: "Events",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Category_CategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Category_CategoryId1",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c4f21aa6-111f-4e73-8162-a6b4d559f42c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fdd34aea-4b4d-4668-a25a-dcab04bf2175"));

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Events",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "DateTime", "Description", "Image", "Location", "MaxParticipants", "Name" },
                values: new object[] { new Guid("52191551-d43e-48f2-92c8-676fd6977fcf"), "Category 1", new DateTime(2024, 4, 10, 2, 53, 5, 233, DateTimeKind.Local).AddTicks(2032), "Description of Event 1", "event1.jpg", "Location 1", 100, "Event 1" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "DateTime", "Description", "Image", "Location", "MaxParticipants", "Name" },
                values: new object[] { new Guid("fd2b9d78-f72b-44da-9316-9bca4331ccce"), "Category 2", new DateTime(2024, 4, 11, 2, 53, 5, 233, DateTimeKind.Local).AddTicks(2077), "Description of Event 2", "event2.jpg", "Location 2", 50, "Event 2" });
        }
    }
}
