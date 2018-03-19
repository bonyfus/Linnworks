using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public class CsvFileWriter : IFileWriter
    {
        public void Write(List<OrderOutput> orderOutputs, string location, string fileName)
        {
            using (var textWriter = File.CreateText(Path.Combine(location, fileName + ".csv")))
            {
                var csvWriter = new CsvWriter(textWriter);
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.WriteRecords(orderOutputs);
            }
        }
    }
}
