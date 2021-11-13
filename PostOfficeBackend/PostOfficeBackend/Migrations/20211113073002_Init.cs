using Microsoft.EntityFrameworkCore.Migrations;

namespace PostOfficeBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParcelLockers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MaxParcelsCount = table.Column<short>(type: "smallint", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelLockers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    ReceiverPhone = table.Column<string>(type: "char(12)", fixedLength: true, maxLength: 12, nullable: false),
                    WeightInKg = table.Column<decimal>(type: "decimal(6,3)", precision: 6, scale: 3, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParcelLockerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_ParcelLockers_ParcelLockerId",
                        column: x => x.ParcelLockerId,
                        principalTable: "ParcelLockers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ParcelLockerId",
                table: "Parcels",
                column: "ParcelLockerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "ParcelLockers");
        }
    }
}
