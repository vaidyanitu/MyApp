using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmnilTest.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contestant",
                columns: new[] { "Id", "Address", "DateOfBirth", "DistrictId", "Firstname", "Gender", "IsActive", "Lastname", "PhotoUrl" },
                values: new object[] { 1, "Kathmandu", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nischhal", "Male", false, "Shrestha", null });

            migrationBuilder.InsertData(
                table: "Contestant",
                columns: new[] { "Id", "Address", "DateOfBirth", "DistrictId", "Firstname", "Gender", "IsActive", "Lastname", "PhotoUrl" },
                values: new object[] { 2, "Lalitpur", new DateTime(1976, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ram", "Male", false, "Shrestha", null });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Kaski" });

            migrationBuilder.InsertData(
                table: "Contestant",
                columns: new[] { "Id", "Address", "DateOfBirth", "DistrictId", "Firstname", "Gender", "IsActive", "Lastname", "PhotoUrl" },
                values: new object[] { 3, "Kaski", new DateTime(1960, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sita", "Male", false, "Malla", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
