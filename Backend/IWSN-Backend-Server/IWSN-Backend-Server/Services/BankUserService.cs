using IWSN_Backend_Server.Models;
using IWSN_Backend_Server.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Services
{
    public class BankUserService
    {
        // generic database values
        private readonly IMongoCollection<User> _users;

        public BankUserService(IBankUserDatabaseSettings settings)
        {
            var mongoDbClient = new MongoClient(settings.ConnectionString); // connect to the MongoDB via the DB connection string 
            var databaseData = mongoDbClient.GetDatabase(settings.DatabaseName); // get the IMongoDatabase object via the MongoDB client via a collection name

            // assign the db values to the readonly value
            this._users = databaseData.GetCollection<User>(settings.BankUserCollectionName); // get the IMongoCollection object from the IMongoDatabase object
        }

        // get all database entries
        public List<User> GetAll()
        {
            // returns the user if it was found
            return this._users.Find(user => true).ToList();
        }


        // get a single database entry by id
        public User GetById(string id)
        {
            // get a user by id
            return this._users.Find(user => user.Id == id).FirstOrDefault();
        }

        // create a user
        public User CreateUser(User user)
        {
            // insert a new user entry
            this._users.InsertOne(user);
            return user;
        }

        // update a existing record/document
        public void Update(string id, User userUpdated)
        {
            // find and replace the user with the new user
            this._users.ReplaceOne(user => user.Id == id, userUpdated);
        }

        // remove a user-document by a given user
        public void Remove(User userToDelete)
        {
            this._users.DeleteOne(user => user.Id == userToDelete.Id);
            
        }

        // remove a user-document by a given user referalId
        public void Remove(string id)
        {
            this._users.DeleteOne(user => user.Id == id);
        }
    }
}
