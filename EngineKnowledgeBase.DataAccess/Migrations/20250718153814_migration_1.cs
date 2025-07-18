using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineKnowledgeBase.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Simple = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                });

            migrationBuilder.CreateTable(
                name: "Includeds",
                columns: table => new
                {
                    IncludedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Includeds", x => x.IncludedId);
                    table.ForeignKey(
                        name: "FK_Includeds_Components_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Components",
                        principalColumn: "ComponentId");
                    table.ForeignKey(
                        name: "FK_Includeds_Components_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_ChildId",
                table: "Includeds",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_ParentId",
                table: "Includeds",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Includeds");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
