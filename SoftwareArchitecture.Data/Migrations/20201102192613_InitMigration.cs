using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareArchitecture.Data.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.Sql(
                @"SET IDENTITY_INSERT [dbo].[Customer] ON 
                INSERT[dbo].[Customer]([Id], [FirstName], [LastName], [Address]) VALUES(1, N'John', N'Rambo', N'Jungle')
                INSERT[dbo].[Customer]([Id], [FirstName], [LastName], [Address]) VALUES(2, N'Tom', N'Hanks', N'New York, US')
                SET IDENTITY_INSERT[dbo].[Customer] OFF
                GO

                SET IDENTITY_INSERT[dbo].[Order] ON
                INSERT[dbo].[Order] ([Id], [Number], [CustomerId]) VALUES(1, N'NBR-0001', 1)
                INSERT[dbo].[Order]([Id], [Number], [CustomerId]) VALUES(2, N'NBR-0002', 1)
                INSERT[dbo].[Order]([Id], [Number], [CustomerId]) VALUES(3, N'NBR-0003', 2)
                SET IDENTITY_INSERT[dbo].[Order] OFF
                GO

                SET IDENTITY_INSERT[dbo].[Product] ON
                INSERT[dbo].[Product] ([Id], [Name], [Price], [OrderId]) VALUES(1, N'Water', CAST(0.99 AS Decimal(16, 2)), 1)
                INSERT[dbo].[Product]([Id], [Name], [Price], [OrderId]) VALUES(2, N'Pepsi', CAST(1.99 AS Decimal(16, 2)), 1)
                INSERT[dbo].[Product]([Id], [Name], [Price], [OrderId]) VALUES(3, N'Smartphone', CAST(999.00 AS Decimal(16, 2)), 2)
                INSERT[dbo].[Product]([Id], [Name], [Price], [OrderId]) VALUES(6, N'Book', CAST(7.00 AS Decimal(16, 2)), 3)
                SET IDENTITY_INSERT[dbo].[Product] OFF
                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
