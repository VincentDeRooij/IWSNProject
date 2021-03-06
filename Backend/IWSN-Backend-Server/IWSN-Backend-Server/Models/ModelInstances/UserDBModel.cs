using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models.ModelInstances
{
    public class UserDBModel
    {
        public UserDBModel() { }

        [BsonElement("Referalid")]
        public string ReferalId { get; set; }

        [BsonElement("Username")]
        public string UserName { get;  set; }

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
