
using Confluent.Kafka;
using FishStore.Models;
using System.Collections.Concurrent;
using System.Text.Json;

namespace FishStore.BL.Kafka
{
    public class KafkaCacheConsumerService : BackgroundService
    {
        public static readonly ConcurrentDictionary<Guid, Fish> MemoryCache = new();
        private readonly IConsumer<Ignore, string> _consumer;

        public KafkaCacheConsumerService()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "fish-cache-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            _consumer.Subscribe("fish-cache");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume(stoppingToken);
                    var fish = JsonSerializer.Deserialize<Fish>(result.Message.Value);
                    if (fish != null)
                    {
                        MemoryCache[fish.Id] = fish;
                    }
                }
            }, stoppingToken);
        }
    }
}
