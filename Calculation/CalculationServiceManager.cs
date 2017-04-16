using Microservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Calculation
{
    public class CalculationServiceManager : ServiceManager
    {
        public override int Start()
        {
            return (int)HostFactory.Run(x => x.Service<CalculationRequestService>());
        }
    }
}
