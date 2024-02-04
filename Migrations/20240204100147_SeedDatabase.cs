using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeStoreCore.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoeTags",
                columns: new[] { "Id", "Shoe_Id", "Tag_Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "Name", "Picture", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "AirForce1Blue", "https://picsum.photos/200/300?random=1", 199f, "41,42,43,44" },
                    { 2, "AirJordan1RetroLow4", "https://picsum.photos/200/300?random=2", 240f, "41,42,43,44" },
                    { 3, "AirJordan2Wing", "https://picsum.photos/200/300?random=3", 180f, "41,42,43,44" },
                    { 4, "AirJordan4From", "https://picsum.photos/200/300?random=4", 270f, "38" },
                    { 5, "AirJOrdan4Knicks", "https://picsum.photos/200/300?random=5", 140f, "41,42,43,44" },
                    { 6, "AirJordan4Retro", "https://picsum.photos/200/300?random=6", 230f, "38" },
                    { 7, "AirJordan5", "https://picsum.photos/200/300?random=7", 320f, "45,46,47" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Winter" },
                    { 2, "Summer" },
                    { 3, "Men" },
                    { 4, "Autumn" },
                    { 5, "Spring" },
                    { 6, "Women" },
                    { 7, "New" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "nikihouse", "nikiv@gmail.com", "nikiv", false, "nikipass", "nikipass", "0896543210", "nikiv" },
                    { 2, "Memo", "semo@abv.bg", "semo", true, "memo", "memo", "0896543210", "semo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShoeTags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
