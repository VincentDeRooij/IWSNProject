using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models
{
    public interface IBankAccountDatabaseSettings
    {
        string BankAccountCollectionName { get; set; }
        string BankConnectionString { get; set; }
        string BankDatabaseName { get; set; }
    }

    public class BankAccountDatabaseSettings :  IBankAccountDatabaseSettings
    {
        public string BankAccountCollectionName { get; set; }
        public string BankConnectionString { get; set; }
        public string BankDatabaseName { get; set; }
    }
}
