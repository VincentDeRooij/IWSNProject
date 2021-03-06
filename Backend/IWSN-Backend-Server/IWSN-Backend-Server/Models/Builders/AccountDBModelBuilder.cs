using IWSN_Backend_Server.Models.ModelInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models.Builders
{
    public class AccountDBModelBuilder
    {
        private AccountDBModel _model;

        public AccountDBModelBuilder() 
        {
            this._model = new AccountDBModel();            
        }

        public AccountDBModelBuilder SetBalance(int balance)
        {
            this._model.Balance = balance;
            return this;
        }

        public AccountDBModelBuilder SetUser(UserDBModel user)
        {
            this._model.User = user;
            return this;
        }

        public AccountDBModel CopyObject(AccountDBModel toCopy)
        {
            this._model = toCopy;
            return this._model;
        }

        public AccountDBModel CreateObject()
        {
            return this._model;
        }
    }
}
