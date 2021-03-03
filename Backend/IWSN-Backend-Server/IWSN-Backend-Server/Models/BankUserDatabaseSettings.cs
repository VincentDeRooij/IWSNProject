using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models
{
    public interface IBankUserDatabaseSettings
    {
        string BankUserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class BankUserDatabaseSettings : IBankUserDatabaseSettings
    {
        public string BankUserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
