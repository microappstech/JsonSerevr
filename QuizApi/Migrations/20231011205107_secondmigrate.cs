using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApi.Migrations
{
    /// <inheritdoc />
    public partial class secondmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_Quizid",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Categories_Categoriesid",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_Categoriesid",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Categoriesid",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "Quizid",
                table: "Questions",
                newName: "quizid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_Quizid",
                table: "Questions",
                newName: "IX_Questions_quizid");

            migrationBuilder.AlterColumn<int>(
                name: "quizid",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CategoryId",
                table: "Sections",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_quizid",
                table: "Questions",
                column: "quizid",
                principalTable: "Quizzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Categories_CategoryId",
                table: "Sections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_quizid",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Categories_CategoryId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CategoryId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "quizid",
                table: "Questions",
                newName: "Quizid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_quizid",
                table: "Questions",
                newName: "IX_Questions_Quizid");

            migrationBuilder.AddColumn<int>(
                name: "Categoriesid",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Quizid",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Categoriesid",
                table: "Sections",
                column: "Categoriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_Quizid",
                table: "Questions",
                column: "Quizid",
                principalTable: "Quizzes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Categories_Categoriesid",
                table: "Sections",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
