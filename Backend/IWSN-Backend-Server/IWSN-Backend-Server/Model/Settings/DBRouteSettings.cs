using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Models.Settings.Class
{
    public class DBRouteSettings
    {
        public const string MAIN_ROUTE = "api/v1";

        public const string ACCOUNT_MAIN_ROUTE_NAME = MAIN_ROUTE + "/bank/"; 
        public const string ACCOUNT_SUB_ROUTE_NAME = "account";

        public const string SENSOR_MAIN_ROUTE_NAME = MAIN_ROUTE + "/sensor/";
        public const string SENSOR_SUB_ROUTE_NAME = "data";
    }
}
