using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDoc.Migrations
{
    public partial class InventoryMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_INASES_INV_INVENTORY",
                columns: table => new
                {
                    SYS_INASES_INV_INVENTORY_INVENTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_INASES_INV_INVENTORY_NUMBER = table.Column<int>(nullable: false),
                    SYS_INASES_INV_INVENTORY_REFERENCE_CODE = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_DOCUMENT_TITLE = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_SERIES = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_SECOND_NUMBER = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_EXTREME_DATE = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_INSTALLATION_UNIT = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_NUMBER_SHEETS = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_PRODUCER_NAME = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_STATE_CONVERSATION = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_DOCUMENT_OBSERVATION = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_SHELF = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_BALD = table.Column<string>(nullable: true),
                    SYS_INASES_INV_INVENTORY_BOX = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INASES_INV_INVENTORY", x => x.SYS_INASES_INV_INVENTORY_INVENTORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "SYS_INASES_INV_MOVEMENTS",
                columns: table => new
                {
                    SYS_INASES_INV_MOVEMENTS_MOVEMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYS_INASES_INV_MOVEMENTS_MOVEMENT_TYPE = table.Column<string>(nullable: true),
                    SYS_INASES_INV_MOVEMENTS_MOVEMENT_DATE = table.Column<DateTime>(nullable: false),
                    SYS_INASES_INV_MOVEMENTS_MOVEMENT_OBSERVATION = table.Column<string>(nullable: true),
                    SYS_INASES_INV_MOVEMENTS_INVENTORY_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INASES_INV_MOVEMENTS", x => x.SYS_INASES_INV_MOVEMENTS_MOVEMENT_ID);
                    table.ForeignKey(
                        name: "FK_SYS_INASES_INV_MOVEMENTS_SYS_INASES_INV_INVENTORY_SYS_INASES_INV_MOVEMENTS_INVENTORY_ID",
                        column: x => x.SYS_INASES_INV_MOVEMENTS_INVENTORY_ID,
                        principalTable: "SYS_INASES_INV_INVENTORY",
                        principalColumn: "SYS_INASES_INV_INVENTORY_INVENTORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INASES_INV_MOVEMENTS_SYS_INASES_INV_MOVEMENTS_INVENTORY_ID",
                table: "SYS_INASES_INV_MOVEMENTS",
                column: "SYS_INASES_INV_MOVEMENTS_INVENTORY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_INASES_INV_MOVEMENTS");

            migrationBuilder.DropTable(
                name: "SYS_INASES_INV_INVENTORY");
        }
    }
}
