using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Settings
{
    public interface IMqttSettings
    {
        public string BrokerId { get; set; }
        public int BrokerPort { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
