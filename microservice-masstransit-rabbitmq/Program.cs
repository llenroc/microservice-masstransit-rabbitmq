using Calculation;

namespace microservice_masstransit_rabbitmq
{
    class Program
    {
        static int Main(string[] args)
        {
            var serviceManager = new CalculationServiceManager();
            serviceManager.ConfigureLogger();

            return serviceManager.Start();
        }
    }
}
