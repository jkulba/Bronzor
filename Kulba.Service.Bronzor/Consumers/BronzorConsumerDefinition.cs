namespace Kulba.Service.Bronzor.Consumers
{
    using MassTransit;

    public class BronzorConsumerDefinition :
        ConsumerDefinition<BronzorConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<BronzorConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}