using IWSN_Backend_Server.Models;
using System.Collections.Generic;

namespace IWSN_Backend_Server.Services.Interfaces
{
    public interface IBankUserService
    {
        // getters
        public List<User> GetAll();
        public User GetById(string referalId);

        // create
        public User CreateUser(User user);

        // update
        public void Update(string referalId, User userUpdated);

        // deletes
        public void Remove(User user);
        public void Remove(string referalId);
    }
}