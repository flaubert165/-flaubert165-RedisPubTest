using StackExchange.Redis;
using System;

namespace RedisPubTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;

            var quote = redis.StringGet("_mktDataCurrentQuotePETR4");

            ISubscriber pub = redis.Multiplexer.GetSubscriber();

            pub.Publish("test124", quote);
        }
    }
}
