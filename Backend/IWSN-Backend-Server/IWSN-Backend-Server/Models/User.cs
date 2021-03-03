using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Referalid")]
        public string ReferalId { get; set; }

        [BsonElement("Username")]
        public string UserName { get; set; }

        [BsonElement("Firstname")]
        public string FirstName { get; set; }

        [BsonElement("Surname")]
        public string SurName { get; set; }

        [BsonElement("Lastname")]
        public string LastName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }
    }
}
