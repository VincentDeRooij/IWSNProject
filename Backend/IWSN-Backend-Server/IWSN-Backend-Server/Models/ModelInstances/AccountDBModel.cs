using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IWSN_Backend_Server.Models.ModelInstances;
using System.Runtime.Serialization;

namespace IWSN_Backend_Server.Models
{
    public class AccountDBModel
    {
        public AccountDBModel() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("User")]
        public UserDBModel User { get; set; }

        [BsonElement("Balance")]
        public int Balance { get; set; }
    }
}
