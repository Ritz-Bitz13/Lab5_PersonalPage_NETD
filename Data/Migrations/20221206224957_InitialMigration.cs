using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5_PersonalPage.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    computerBrand = table.Column<string>(nullable: true),
                    computerPart = table.Column<string>(nullable: true),
                    computerCreatedYear = table.Column<int>(nullable: false),
                    computerPartPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SellerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    City_Location = table.Column<string>(nullable: true),
                    Year_Joined = table.Column<int>(nullable: false),
                    Selling_Computer_Part = table.Column<int>(nullable: false),
                    Part_Condition = table.Column<string>(nullable: true),
                    PartNumberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerID);
                    table.ForeignKey(
                        name: "FK_Seller_Parts_PartNumberID",
                        column: x => x.PartNumberID,
                        principalTable: "Parts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seller_PartNumberID",
                table: "Seller",
                column: "PartNumberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
