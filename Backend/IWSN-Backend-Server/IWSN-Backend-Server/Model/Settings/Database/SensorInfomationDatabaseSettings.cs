using IWSN_Backend_Server.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models.Settings.Database
{
    public class SensorInfomationDatabaseSettings : IDatabaseSettings
    {
        public string DBCollectionName { get; set; }
        public string DBConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
