using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureInBloodDonorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_BloodDonorId",
                table: "Donations");

            migrationBuilder.AddColumn<int>(
                name: "BloodDonorEntityId",
                table: "Donations",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "BloodDonors",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BloodDonors",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "BloodDonors",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "BloodDonors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "BloodDonors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodDonorEntityId",
                table: "Donations",
                column: "BloodDonorEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorEntityId",
                table: "Donations",
                column: "BloodDonorEntityId",
                principalTable: "BloodDonors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorEntityId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_BloodDonorEntityId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "BloodDonorEntityId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "BloodDonors");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "BloodDonors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BloodDonors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "BloodDonors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "BloodDonors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodDonorId",
                table: "Donations",
                column: "BloodDonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorId",
                table: "Donations",
                column: "BloodDonorId",
                principalTable: "BloodDonors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
