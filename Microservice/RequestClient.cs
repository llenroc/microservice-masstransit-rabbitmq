using MassTransit;
using System;

namespace Microservice
{
    public abstract class RequestClient<IRequest, IResponse>
    {
        readonly string RabbitMQHost;

        public RequestClient(string rabbitMQHost)
        {
            RabbitMQHost = rabbitMQHost;
        }

        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(x => {
                x.Host(new Uri(RabbitMQHost), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

            });
        }

        public abstract IRequestClient<IRequest, IResponse> CreateRequestClient(IBusControl busControl);
    }
}
