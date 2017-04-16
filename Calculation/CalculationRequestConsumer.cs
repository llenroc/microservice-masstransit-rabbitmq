using MassTransit;
using Models;
using System.Threading.Tasks;

namespace Calculation
{
    public class CalculationRequestConsumer : IConsumer<IDataRequest>
    {
        public async Task Consume(ConsumeContext<IDataRequest> context)
        {
            context.Respond(new CalculationResponse
            {
                result = context.Message.a + context.Message.b
            });
        }
    }
}
