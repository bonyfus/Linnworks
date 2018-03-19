using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CommandLine;
using Linnworks.OrderProcessor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StructureMap;

namespace Linnworks.OrderProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<ArgsOptions>(args)
                  .WithParsed(opts => RunApplication(opts));
       }

        private static void RunApplication(ArgsOptions opts)
        {
            var location = opts.FileInputPath;
            var destination = opts.FileOutputPath;

            Console.WriteLine("Processing orders");

            var container = InitContainer();
            IFileReader fileReader = container.GetInstance<IFileReader>();
            IOrderDataProcessor orderDataProcessor = container.GetInstance<OrderDataProcessor>();
            IFileWriter fileWriter = container.GetInstance<CsvFileWriter>();

            try
            {
                var processingObject = fileReader.Read(location, "json");
                var orders = orderDataProcessor.GenerateOrderObjects(processingObject);

                foreach (var order in orders)
                {
                    var orderOutput = orderDataProcessor.BuildOrderOutput(order);
                    fileWriter.Write(orderOutput, destination, order.OrderReference);
                }

                Console.WriteLine("Processing completed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static Container InitContainer()
        {
            return new Container(c =>
           {
               c.For<IFileReader>().Use<DiskFileReader>();
               c.For<IOrderDataProcessor>().Use<OrderDataProcessor>();
               c.For<IFileWriter>().Use<CsvFileWriter>();
           });
        }
    }

    public class ArgsOptions
    {
        [Option('l', Required = true, HelpText = "Input files location")]
        public string FileInputPath { get; set; }

        [Option('d', Required = true, HelpText = "Output file location")]
        public string FileOutputPath { get; set; }
    }
}
