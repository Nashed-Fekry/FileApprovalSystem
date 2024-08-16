using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileApprovalSystem.Migrations
{
    public partial class SeedUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "349374d1-0d0a-409d-8422-5bbf8e5c1001", "8939421d-7412-40ff-899a-b3817f05c0b4", "Employee3", "EMPLOYEE3" },
                    { "9ac030e1-d236-4e5e-8312-e976a190345c", "a8586a1c-4dfe-435b-9eab-8b5a28ae394e", "Employee2", "EMPLOYEE2" },
                    { "a3bac334-1f15-43e2-bb2e-a789a9281c11", "49586b92-ff01-4a34-9002-cf260b2c6696", "Employee1", "EMPLOYEE1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0aeeefff-42a5-46f6-b824-49dca2023166", 0, "43b9af42-1e05-4a20-bfae-5dbee13268d8", "employee3@example.com", true, false, null, "EMPLOYEE3@EXAMPLE.COM", "EMPLOYEE3", "AQAAAAEAACcQAAAAELI6WOg6ccqcUjaKfie/jS8TfEVwIRroHtT1E7LGiBMy9gDvEyBvqkfbVqn0Vlt6BQ==", null, false, "21d31966-60ce-4e99-b805-c1f0e18b1a06", false, "employee3" },
                    { "9e264ba5-1214-46ed-aa4b-96997d28664c", 0, "b941d838-d454-4109-bc4e-525f2cc617df", "employee2@example.com", true, false, null, "EMPLOYEE2@EXAMPLE.COM", "EMPLOYEE2", "AQAAAAEAACcQAAAAELd8lkDUMoRwUalRYtVxQoGQY4Yi+j09XqWb3IDVrrMBCh6QvckNj9//x7saE0Z3IA==", null, false, "490acff2-a435-42b6-836a-661cd4f3705f", false, "employee2" },
                    { "f2ad01ce-83b6-4d0a-8054-155c74d3166a", 0, "a8b0819f-8ec7-40bb-8b61-4fc2c1a92f71", "employee1@example.com", true, false, null, "EMPLOYEE1@EXAMPLE.COM", "EMPLOYEE1", "AQAAAAEAACcQAAAAEMFmkRYmW0CpH7NK28CQjzZmgfPPf7MtdAby6yV75HxrKBsv8kzDUiM7L5DNjTWeVg==", null, false, "a0cfd8f9-3ac3-4e32-b7f8-d0aab43e982e", false, "employee1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "349374d1-0d0a-409d-8422-5bbf8e5c1001", "0aeeefff-42a5-46f6-b824-49dca2023166" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ac030e1-d236-4e5e-8312-e976a190345c", "9e264ba5-1214-46ed-aa4b-96997d28664c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3bac334-1f15-43e2-bb2e-a789a9281c11", "f2ad01ce-83b6-4d0a-8054-155c74d3166a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "349374d1-0d0a-409d-8422-5bbf8e5c1001", "0aeeefff-42a5-46f6-b824-49dca2023166" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ac030e1-d236-4e5e-8312-e976a190345c", "9e264ba5-1214-46ed-aa4b-96997d28664c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3bac334-1f15-43e2-bb2e-a789a9281c11", "f2ad01ce-83b6-4d0a-8054-155c74d3166a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "349374d1-0d0a-409d-8422-5bbf8e5c1001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ac030e1-d236-4e5e-8312-e976a190345c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3bac334-1f15-43e2-bb2e-a789a9281c11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aeeefff-42a5-46f6-b824-49dca2023166");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e264ba5-1214-46ed-aa4b-96997d28664c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2ad01ce-83b6-4d0a-8054-155c74d3166a");
        }
    }
}
