using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDoc.Migrations
{
    public partial class IntBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SYS_INASES_INV_INVENTORY_BOX",
                table: "SYS_INASES_INV_INVENTORY",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SYS_INASES_INV_INVENTORY_BOX",
                table: "SYS_INASES_INV_INVENTORY",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
