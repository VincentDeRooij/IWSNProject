using IWSN_Backend_Server.Models.ModelInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models.Builders
{
    public class UserDBModelBuilder
    {
        private UserDBModel _model;

        public UserDBModelBuilder()
        {
            this._model = new UserDBModel();
        }        

        public UserDBModelBuilder SetReferalId(string referalId) 
        { 
            this._model.ReferalId = referalId;
            return this;
        }

        public UserDBModelBuilder SetUserName(string userName) 
        {
            this._model.UserName = userName;
            return this;
        }

        public UserDBModelBuilder SetFirstName(string firstName) 
        {
            this._model.FirstName = firstName;
            return this;
        }

        public UserDBModelBuilder SetSurName(string surName)
        {
            this._model.SurName = surName;
            return this;
        }

        public UserDBModelBuilder SetLastName(string lastName) 
        {
            this._model.LastName = lastName;
            return this;
        }
        
        public UserDBModelBuilder SetAge(int age) 
        {
            this._model.Age = age;
            return this;
        }

        public UserDBModel CreateObject()
        {
            return this._model;
        }
    }
}
