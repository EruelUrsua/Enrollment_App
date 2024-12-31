using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enrollment.Datamodel.Migrations
{
    /// <inheritdoc />
    public partial class CreatedStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudent", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblStudent",
                columns: new[] { "Id", "GivenName", "Surname" },
                values: new object[] { 1, "Eruel", "Ursua" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblStudent");
        }
    }
}
