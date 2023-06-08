using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTasksAndBoardsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("48060f32-1242-40f9-b545-eccac33bb117"), 1, new DateTime(2023, 1, 8, 14, 23, 16, 337, DateTimeKind.Utc).AddTicks(506), "Create Android client App for the RESTful TaskBoard service", "eaf55ceb-ddd7-4a99-af7f-d91109cc65c7", "Android Client App" },
                    { new Guid("60de5315-3fde-4880-bba8-d6bcb9aa070b"), 1, new DateTime(2022, 11, 20, 14, 23, 16, 337, DateTimeKind.Utc).AddTicks(436), "Implement better styling for all public pages", "df1b9cb6-dfbb-4c34-8e4f-341b798e58e4", "Improve CSS styles" },
                    { new Guid("c306825b-b024-4570-877c-9c9fa9b5a0d2"), 2, new DateTime(2023, 5, 8, 14, 23, 16, 337, DateTimeKind.Utc).AddTicks(515), "Create Desktop client App for the RESTful TaskBoard service", "df1b9cb6-dfbb-4c34-8e4f-341b798e58e4", "Desktop Client App" },
                    { new Guid("dec0d0aa-b523-4988-bc10-bcccaf0c5f6b"), 3, new DateTime(2023, 5, 8, 14, 23, 16, 337, DateTimeKind.Utc).AddTicks(518), "Implement [Create Task] page for adding tasks", "df1b9cb6-dfbb-4c34-8e4f-341b798e58e4", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
