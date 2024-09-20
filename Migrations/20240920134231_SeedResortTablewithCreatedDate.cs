using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WanderHub_ResortAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedResortTablewithCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 42, 31, 689, DateTimeKind.Local).AddTicks(150), "A serene getaway blending luxury and nature, perfect for relaxation and adventure.", "Mountain Retreat" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 42, 31, 689, DateTimeKind.Local).AddTicks(162), "A serene getaway blending luxury and nature, perfect for relaxation and adventure.", "Sunny Beach Resort" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 42, 31, 689, DateTimeKind.Local).AddTicks(189), "A serene getaway blending luxury and nature, perfect for relaxation and adventure.", "Luxury Forest Oasis" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 42, 31, 689, DateTimeKind.Local).AddTicks(191), "A serene getaway blending luxury and nature, perfect for relaxation and adventure.", "Royal Desert Villa" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(2024, 9, 20, 21, 42, 31, 689, DateTimeKind.Local).AddTicks(193), "A serene getaway blending luxury and nature, perfect for relaxation and adventure..", "Diamond Pool Resort" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Royal Villa" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Premium Pool Villa" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Luxury Pool Villa" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Villa" });

            migrationBuilder.UpdateData(
                table: "Resort",
                keyColumn: "ResortId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Details", "ResortName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Pool Villa" });
        }
    }
}
