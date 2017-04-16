using MassTransit;
using Models;
using System;
using System.Configuration;

namespace microservice_masstransit_rabbitmq.Client
{
    class RequestClient : Microservice.RequestClient<IDataRequest, IDataResponse>
    {
        public RequestClient() : base(ConfigurationManager.AppSettings["RabbitMQHost"])
        {

        }

        public override IRequestClient<IDataRequest, IDataResponse> CreateRequestClient(IBusControl busControl)
        {
            var serviceAddress = new Uri(ConfigurationManager.AppSettings["ServiceAddress"]);
            IRequestClient<IDataRequest, IDataResponse> client = busControl.CreateRequestClient<IDataRequest, IDataResponse>(serviceAddress, TimeSpan.FromSeconds(500));
            return client;
        }
    }
}
