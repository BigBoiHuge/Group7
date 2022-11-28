using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyCitizens.Data.Migrations
{
    /// <inheritdoc />
    public partial class stringlyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_AspNetUsers_UserId1",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId",
                table: "Item",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_AspNetUsers_UserId",
                table: "Item",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_AspNetUsers_UserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Item",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId1",
                table: "Item",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_AspNetUsers_UserId1",
                table: "Item",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

       /* private void DropConstraint()
        {
            Sql(@"DECLARE @var0 nvarchar(128)
                  SELECT @var0 = name
                  FROM sys.default_constraints
                  WHERE parent_object_id = object_id(N'dbo.Item')
                  AND col_name(parent_object_id, parent_column_id) = 'UserId';
                  IF @var0 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[Item] DROP CONSTRAINT [' + @var0 + ']')");
        }*/
    }

    
}
