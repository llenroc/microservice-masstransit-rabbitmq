using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice;
using System;
using System.Configuration;

namespace Calculation
{
    class CalculationRequestService : RequestService
    {
        public CalculationRequestService() : base(ConfigurationManager.AppSettings["RabbitMQHost"], ConfigurationManager.AppSettings["ServiceAddress"])
        {
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> configure()
        {
            return e =>
            {
                e.Consumer<CalculationRequestConsumer>();
            };
        }
    }
}
