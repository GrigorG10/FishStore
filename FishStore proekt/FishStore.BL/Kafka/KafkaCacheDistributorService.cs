
using Confluent.Kafka;
using FishStore.Models;
using System.Text.Json;

namespace FishStore.BL.Kafka
{
    public class KafkaCacheDistributorService : BackgroundService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaCacheDistributorService()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var fish = new Fish
                {
                    Id = Guid.NewGuid(),
                    Name = "Salmon",
                    Weight = new Random().NextDouble() * 10
                };

                var json = JsonSerializer.Serialize(fish);
                await _producer.ProduceAsync("fish-cache", new Message<Null, string> { Value = json });

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
