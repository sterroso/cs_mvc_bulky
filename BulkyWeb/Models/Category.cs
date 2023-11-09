using MongoDB.Bson;

namespace BulkyWeb.Models
{
    public class Category
    {
        public ObjectId _id { get; set; }

        public required string Name { get; set; }

        public required int DisplayOrder { get; set; }
    }
}
