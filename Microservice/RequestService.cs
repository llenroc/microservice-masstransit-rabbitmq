using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.Util;
using System;
using Topshelf;
using Topshelf.Logging;

namespace Microservice
{
    public abstract class RequestService : ServiceControl
    {
        readonly string RabbitMQHost;
        readonly string ServiceQueueName;

        public RequestService(string rabbitMQHost, string serviceQueueName)
        {
            RabbitMQHost = rabbitMQHost;
            ServiceQueueName = serviceQueueName;
        }
        readonly LogWriter _log = HostLogger.Get<RequestService>();

        IBusControl _busControl;

        public bool Start(HostControl hostControl)
        {
            _log.Info("Creating bus...");

            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                IRabbitMqHost host = x.Host(new Uri(RabbitMQHost), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                x.ReceiveEndpoint(host, ServiceQueueName, configure());
            });

            _log.Info("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _log.Info("Stopping bus...");

            _busControl?.Stop();

            return true;
        }

        public abstract Action<IRabbitMqReceiveEndpointConfigurator> configure();
    }
}
