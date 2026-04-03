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
            //migrationBuilder.CreateTable(
            //    name: "Enquiries",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UseCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Enquiries", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Enquiries");
        }
    }
}
