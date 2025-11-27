using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFile.Core;

public class NugetCsvHelper
{

    private readonly CsvConfiguration _config;

    public NugetCsvHelper()
    {
        _config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ","
        };
    }

    public List<Person> Read(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Person>();
        }

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, _config);
        return csv.GetRecords<Person>().ToList();
    }

    public void Write(string filePath, IEnumerable<Person> people)
    {
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, _config);
        csv.WriteRecords(people);
    }

}