using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRVIndia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    States = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBanners", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiries");

            migrationBuilder.DropTable(
                name: "MainBanners");
        }
    }
}
