using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyCitizens.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeputyAppraiser",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "YearBuilt",
                table: "Item",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "PhysicalAddress",
                table: "Item",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "MailingAddress",
                table: "Item",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsInsured",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Item",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsInsured",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Item",
                newName: "PhysicalAddress");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Item",
                newName: "MailingAddress");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "Item",
                newName: "YearBuilt");

            migrationBuilder.AddColumn<string>(
                name: "DeputyAppraiser",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
