using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyFlow.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_User_UserId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_User_UserId",
                table: "Subjects",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_User_UserId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Subjects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_User_UserId",
                table: "Subjects",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
