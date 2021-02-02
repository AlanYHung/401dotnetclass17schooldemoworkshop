using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
    public partial class newSchoolDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropColumn(
                name: "Technology",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TechnologyId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TechnologyId",
                table: "Courses",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TechnologyId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Technology",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });
        }
    }
}
