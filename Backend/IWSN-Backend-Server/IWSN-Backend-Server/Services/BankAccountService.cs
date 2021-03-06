using IWSN_Backend_Server.Models;
using IWSN_Backend_Server.Models.Builders;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Services
{
    /// <summary>
    /// Class which is used as a service to connect to the BankUser MongoDatabase
    /// It uses Async Tasking to wait for results and support the use of Threading
    /// </summary>
    public class BankAccountService
    {
        // generic database values
        private readonly IMongoCollection<AccountDBModel> _accountsDB;

        public BankAccountService(IBankAccountDatabaseSettings settings)
        {
            var mongoDbClient = new MongoClient(settings.BankConnectionString); // connect to the MongoDB via the DB connection string 
            var databaseData = mongoDbClient.GetDatabase(settings.BankDatabaseName); // get the IMongoDatabase object via the MongoDB client via a collection name

            // assign the db values to the readonly value
            this._accountsDB = databaseData.GetCollection<AccountDBModel>(settings.BankAccountCollectionName); // get the IMongoCollection object from the IMongoDatabase object

            if (this._accountsDB.CountDocuments(new BsonDocument()) == 0)
            {
                insertDocuments();
            }
        }
        private void insertDocuments()
        {
            this._accountsDB.InsertOneAsync(new AccountDBModelBuilder()
                .SetBalance(1000)
                .SetUser(new UserDBModelBuilder()
                    .SetReferalId("JennLown")
                    .SetUserName("Jennny_21")
                    .SetFirstName("Jennifer")
                    .SetSurName("")
                    .SetLastName("Lown")
                    .SetAge(21)
                    .CreateObject()
                )
                .CreateObject());

            this._accountsDB.InsertOneAsync(new AccountDBModelBuilder()
                .SetBalance(1000)
                .SetUser(new UserDBModelBuilder()
                    .SetReferalId("JasonLown")
                    .SetUserName("Jay_23")
                    .SetFirstName("Jason")
                    .SetSurName("")
                    .SetLastName("Lown")
                    .SetAge(23)
                    .CreateObject()
                )
                .CreateObject());
        }

        // get all database entries
        public Task<IEnumerable<AccountDBModel>> GetAllAsync()
        {
            // returns the user if it was found
            return Task.FromResult<IEnumerable<AccountDBModel>>(this._accountsDB.Find(user => true).ToList());
        }

        // get a single database entry by id
        public Task<AccountDBModel> GetByIdAsync(string id)
        {
            // get a user by id
            return Task.FromResult<AccountDBModel>(this._accountsDB.Find(user => user.Id == id).FirstOrDefault());
        }

        // create a user 
        public Task<AccountDBModel> CreateUserAsync(AccountDBModel account)
        {
            // insert a new user entry
            this._accountsDB.InsertOneAsync(account);
            return Task.FromResult<AccountDBModel>(account);
        }

        // update a existing record/document
        public Task UpdateAsync(string id, AccountDBModel accountUpdated)
        {
            // find and replace the user with the new user
            return this._accountsDB.ReplaceOneAsync(account => account.Id == id, accountUpdated);
        }

        // remove a user-document by a given user referalId
        public Task RemoveAsync(string id)
        {
            return this._accountsDB.DeleteOneAsync(account => account.Id == id);
        }
    }
}
