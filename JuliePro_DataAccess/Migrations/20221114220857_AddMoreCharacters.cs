using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuliePro_DataAccess.Migrations
{
    public partial class AddMoreCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Disciplines_Discipline_Id",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "Discipline_Id",
                table: "Records",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Trainer_Id",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certifications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "CertificationCenter",
                table: "Certifications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_Records_Trainer_Id",
                table: "Records",
                column: "Trainer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Disciplines_Discipline_Id",
                table: "Records",
                column: "Discipline_Id",
                principalTable: "Disciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Trainers_Trainer_Id",
                table: "Records",
                column: "Trainer_Id",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Disciplines_Discipline_Id",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Trainers_Trainer_Id",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_Trainer_Id",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Trainer_Id",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "Discipline_Id",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certifications",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CertificationCenter",
                table: "Certifications",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Disciplines_Discipline_Id",
                table: "Records",
                column: "Discipline_Id",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
