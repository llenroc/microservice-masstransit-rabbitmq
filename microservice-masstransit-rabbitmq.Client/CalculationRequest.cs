using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice_masstransit_rabbitmq.Client
{
    class CalculationRequest : IDataRequest
    {
        public double a { get; set; }
        public double b { get; set; }
    }
}
