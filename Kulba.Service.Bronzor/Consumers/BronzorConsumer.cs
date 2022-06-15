namespace Kulba.Service.Bronzor.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Kulba.Service.Bronzor.Contracts;
    using Microsoft.Extensions.Logging;

    public class BronzorConsumer : IConsumer<BronzorItem>
    {
        readonly ILogger<BronzorConsumer> _logger;

        public BronzorConsumer(ILogger<BronzorConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<BronzorItem> context)
        {
            _logger.LogInformation("BronzorConsumer Received Text: {Text}", context.Message.Value);
            return Task.CompletedTask;
        }
    }
}