using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using LogLevel = NLog.LogLevel;

namespace Listing
{
    class Program
    {
        static void Main(string[] args)
        {

            //ЛИНК тест + экстеншен
            //инт лист -> стринг -> экран -> обратно в инт + рандом число -> только четные -> сортировка туда сюда и шафл
        //     var myList = new List<int>();
        //     var rand = new Random();
        //
        //     for (int i = 0; i < 10000; i++)
        //     {
        //         myList.Add(rand.Next(0, 1000));
        //     }
        //
        //     var myList2 = from i1 in myList select i1.ToString();
        //
        //
        //     myList2.Select(i1 => i1).ToList().ForEach(Console.Write);
        //
        //     myList = myList.Select(i1 => i1 + rand.Next(1, 101)).ToList();
        //     Console.WriteLine(
        //         "\n-------------------------------------------------------------------------------------");
        //     myList.Where(i => i % 2 == 0).Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
        //     Console.WriteLine(
        //         "\n-------------------------------------------------------------------------------------");
        //     myList.Where(i => i % 2 == 0).OrderBy(i => i).Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
        //     Console.WriteLine(
        //         "\n-------------------------------------------------------------------------------------");
        //     myList.Where(i => i % 2 == 0).OrderByDescending(i => i).Select(i => i).ToList()
        //         .ForEach(i => Console.Write($"{i} "));
        //     Console.WriteLine(
        //         "\n-------------------------------------------------------------------------------------");
        //     Console.WriteLine(myList.Select(i => i).Count());
        //     Console.WriteLine(myList.Select(i => i).Distinct().Count());
        //     Console.WriteLine(
        //         "\n-------------------------------------------------------------------------------------");
        //     myList = myList.OrderBy(i => rand.Next()).ToList();
        //     myList.Select(i => i).ToList().ForEach(i => Console.Write($"{i} "));
        //     myList.Select(i => i).ForEach(i => Console.WriteLine($"{i} "));
        var config = new LoggingConfiguration();
        var logfile = new FileTarget("logFile")
        {
            FileName = "ProducerConsumerFile.txt",
            Layout = @"${date:format=HH\:mm\:ss.fffff}|${level:uppercase=true}|${logger}|${message}",
            DeleteOldFileOnStartup = true
        };
        var consoletarget = new ConsoleTarget("consoleLog")
        {
            Layout = @"${date:format=HH\:mm\:ss.fffff}|${level:uppercase=true}|${logger}|${message}"
        };

        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoletarget);
        LogManager.Configuration = config;
        
        
        Producer producer = new Producer();
        Consumer1 consumer1 = new Consumer1("Consumer1");
        Consumer2 consumer2 = new Consumer2("Consumer2");
        //producer.Notify += DisplayMessage;
        Producer.ProducerHandler producerHandler1 = null;
        Producer.ProducerHandler producerHandler2 = null;
        producerHandler1 += consumer1.Subscribe;
        producerHandler2 += consumer2.Subscribe;
        producerHandler1?.Invoke($"{consumer1.numberConsumer} is triggering delegate");
        producerHandler2?.Invoke($"{consumer2.numberConsumer} is triggering delegate");
        producer.Notify += consumer1.Subscribe;
        producer.Notify += consumer2.Subscribe;
        producer.Trigger();

        }
    }

    // public static class EnumerableExtension
    // {
    //     public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    //     {
    //         foreach (var value in enumerable)
    //         {
    //             action(value);
    //         }
    //     }
    // }

    public class Producer
    {
        public delegate void ProducerHandler(string message);
        private readonly TimeSpan delay = TimeSpan.FromSeconds(10);
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public event ProducerHandler Notify;

        public void Trigger()
        {
            ProducerHandler producerHandler = delegate(string message)
            {
                logger.Debug(message);
            };
            while (true)
            {
                Notify?.Invoke("is Triggering event");
                Thread.Sleep(delay);
            }
        }
    }

    public class Consumer1
    {
        public string numberConsumer;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Consumer1(string value)
        {
            numberConsumer = value;
        }

        public void Subscribe(string message)
        {
            logger.Debug($"{numberConsumer} {message}");
            
            //Console.WriteLine($"{numberConsumer} {message}");
        }
    }

    public class Consumer2
    {
        public string numberConsumer;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();


        public Consumer2(string value)
        {
            numberConsumer = value;
        }
        
        public void Subscribe(string message)
        {
            
            logger.Debug($"{numberConsumer} {message}");
            //Console.WriteLine($"{numberConsumer} {message}");
        }
    }

}
//extention method посмотреть, делегаты, фанк, экшн, предикат
