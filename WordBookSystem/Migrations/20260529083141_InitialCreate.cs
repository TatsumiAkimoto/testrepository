using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordBookSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(124)", maxLength: 124, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WordBooks",
                columns: table => new
                {
                    WordBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WordBookName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "無名の単語帳"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordBooks", x => x.WordBookId);
                    table.ForeignKey(
                        name: "FK_WordBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordBookId = table.Column<int>(type: "int", nullable: false),
                    WordName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WordMeaning = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WordClass = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WordExample = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                    table.ForeignKey(
                        name: "FK_Words_WordBooks_WordBookId",
                        column: x => x.WordBookId,
                        principalTable: "WordBooks",
                        principalColumn: "WordBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordBooks_UserId",
                table: "WordBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordBookId",
                table: "Words",
                column: "WordBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordBooks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
