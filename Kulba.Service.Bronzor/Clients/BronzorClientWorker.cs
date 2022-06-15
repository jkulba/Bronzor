using System;
using System.Threading;
using System.Threading.Tasks;
using Kulba.Service.Bronzor.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kulba.Service.Bronzor.Clients
{
    public class BronzorClientWorker : BackgroundService
    {

        readonly ILogger<BronzorClientWorker> _logger;

        IBus _bus;

        public BronzorClientWorker(ILogger<BronzorClientWorker> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new BronzorItem { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
                _logger.LogInformation("BronzorClientWorker published Text: {Text}", "My Value");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}