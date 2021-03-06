using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Model.Settings
{
    public interface IDatabaseSettings
    {
        string DBCollectionName { get; set; }
        string DBConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
