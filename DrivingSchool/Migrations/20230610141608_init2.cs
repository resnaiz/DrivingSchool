using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivingSchool.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PracticalDrivingMark",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TheoryDrivingMark",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "UniqueCode",
                table: "Students",
                newName: "UniqueCodeForTheoryExam");

            migrationBuilder.RenameColumn(
                name: "ExamTime",
                table: "Students",
                newName: "DateOfTheoryExam");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfBirth",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDrivingExam",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrivingMark",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheoryMark",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCodeForDrivingExam",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfDrivingExam",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DrivingMark",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TheoryMark",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniqueCodeForDrivingExam",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "UniqueCodeForTheoryExam",
                table: "Students",
                newName: "UniqueCode");

            migrationBuilder.RenameColumn(
                name: "DateOfTheoryExam",
                table: "Students",
                newName: "ExamTime");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfBirth",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "PracticalDrivingMark",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TheoryDrivingMark",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
