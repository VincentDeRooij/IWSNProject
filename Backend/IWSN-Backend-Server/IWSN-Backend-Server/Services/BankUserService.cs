using IWSN_Backend_Server.Models;
using IWSN_Backend_Server.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Services
{
    public class BankUserService : IBankUserService
    {
        // generic database values
        private readonly IMongoCollection<User> _users;

        public BankUserService(IBankUserDatabaseSettings settings)
        {
            var mongoDbClient = new MongoClient(settings.ConnectionString); // connect to the MongoDB via the DB connection string 
            var databaseData = mongoDbClient.GetDatabase(settings.BankUserCollectionName); // get the IMongoDatabase object via the MongoDB client via a collection name

            // assign the db values to the readonly value
            this._users = databaseData.GetCollection<User>(settings.BankUserCollectionName); // get the IMongoCollection object from the IMongoDatabase object
        }
    }
}
