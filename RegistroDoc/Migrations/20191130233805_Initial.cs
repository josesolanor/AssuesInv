using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDoc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_INASES_INV_ROLE",
                columns: table => new
                {
                    SYS_INASES_INV_ROLE_ROLE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_INASES_INV_ROLE_ROLE_VALUE = table.Column<string>(nullable: true),
                    SYS_INASES_INV_ROLE_ROLE_DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INASES_INV_ROLE", x => x.SYS_INASES_INV_ROLE_ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SYS_INASES_INV_USER",
                columns: table => new
                {
                    SYS_INASES_INV_USER_USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_INASES_INV_USER_FIRST_NAME = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_LAST_NAME = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_SECOND_LAST_NAME = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_EMAIL = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_ACCOUNT = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_PASSWORD = table.Column<string>(nullable: true),
                    SYS_INASES_INV_USER_ROLE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INASES_INV_USER", x => x.SYS_INASES_INV_USER_USER_ID);
                    table.ForeignKey(
                        name: "FK_SYS_INASES_INV_USER_SYS_INASES_INV_ROLE_SYS_INASES_INV_USER_ROLE_ID",
                        column: x => x.SYS_INASES_INV_USER_ROLE_ID,
                        principalTable: "SYS_INASES_INV_ROLE",
                        principalColumn: "SYS_INASES_INV_ROLE_ROLE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INASES_INV_USER_SYS_INASES_INV_USER_ROLE_ID",
                table: "SYS_INASES_INV_USER",
                column: "SYS_INASES_INV_USER_ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_INASES_INV_USER");

            migrationBuilder.DropTable(
                name: "SYS_INASES_INV_ROLE");
        }
    }
}
