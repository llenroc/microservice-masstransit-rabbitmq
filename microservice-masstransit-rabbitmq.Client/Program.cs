using MassTransit;
using MassTransit.Util;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice_masstransit_rabbitmq.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestClient = new RequestClient();
            var busControl = requestClient.CreateBus();
            TaskUtil.Await(() => busControl.StartAsync());
            IRequestClient<IDataRequest, IDataResponse> client = requestClient.CreateRequestClient(busControl);

            var request = new CalculationRequest() { a = 3, b = 5 };
            var respone = client.Request(request).Result;

            Console.WriteLine(request.a + " + " + request.b + " = " + respone.result);
        }
    }
}
