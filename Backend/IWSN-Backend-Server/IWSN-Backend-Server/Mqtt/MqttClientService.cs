using IWSN_Backend_Server.Settings;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Mqtt
{
    public class MqttClientService
    {
        private readonly IMqttClient _MqttClientService;
        private readonly IMqttClientOptions _MqttOptions;

        public MqttClientService(IMqttSettings settings)
        {
            var factory = new MqttFactory();
            this._MqttClientService = factory.CreateMqttClient();

            this._MqttOptions = new MqttClientOptionsBuilder()
                .WithClientId(settings.ClientId)
                .WithTcpServer(settings.BrokerId, settings.BrokerPort)
                .Build();
        }

        private async Task ConnectToMqttBroker()
        {
            await this._MqttClientService.ConnectAsync(this._MqttOptions, CancellationToken.None);

            Console.WriteLine();
        }   
    }
}
