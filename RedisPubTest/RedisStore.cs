﻿using StackExchange.Redis;
using System;

namespace RedisPubTest
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            var configurationOptions = ConfigurationOptions.Parse("localhost:7000");
            configurationOptions.Password = "test";
            configurationOptions.KeepAlive = 10;
            configurationOptions.SyncTimeout = 500;
            configurationOptions.AllowAdmin = true;

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
