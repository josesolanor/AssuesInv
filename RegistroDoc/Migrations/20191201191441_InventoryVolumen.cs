using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDoc.Migrations
{
    public partial class InventoryVolumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SYS_INASES_INV_INVENTORY_VOLUMEN",
                table: "SYS_INASES_INV_INVENTORY",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SYS_INASES_INV_INVENTORY_VOLUMEN",
                table: "SYS_INASES_INV_INVENTORY");
        }
    }
}
