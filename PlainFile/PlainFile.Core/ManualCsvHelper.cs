using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFile.Core;

public class ManualCsvHelper
{
    public void WriteCsv(string path, List<string[]> records)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
        }
        if (records is null)
        {
            throw new ArgumentNullException(nameof(records));
        }
        EnsureFileAndRirectory(path);

        using var sw = new StreamWriter(path);
        foreach (var record in records)
        {
            var line = string.Join(",", record);
            sw.WriteLine(line);
        }
    }

    public List<string[]> ReadCsv(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
        }
        EnsureFileAndRirectory(path);

        var result = new List<string[]>();
        using var sr = new StreamReader(path);
        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            var fields = line.Split(',');
            result.Add(fields);
        }
        return result;
    }

    public void DeleteCsv(string path, string[] record)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
        }
        if (File.Exists(path))
        {
            throw new FileNotFoundException("The file does not exit.");
        }
        if (record == null || record.Length == 0)
        {
            throw new ArgumentException("The record to delete cannot be null or empty.", nameof(record));
        }
        var records = ReadCsv(path);
        var updatedRecords = records.Where(r => !r.SequenceEqual(record)).ToList();
        WriteCsv(path, updatedRecords);
    }

    public void SortCsv(string path, int columnIndex = 0, bool ascending = true)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("The file path cannot be null or empty.", nameof(path));
        }
        if (File.Exists(path))
        {
            throw new FileNotFoundException("The file does not exit.");
        }

        var records = ReadCsv(path);
        if (records.Count == 0)
        {
            return;
        }
        if (columnIndex < 0 || columnIndex >= records[0].Length)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex), "The column index is out of range.");
        }

        var sortedRecords = ascending
            ? records.OrderBy(r => r[columnIndex]).ToList()
            : records.OrderByDescending(r => r[columnIndex]).ToList();
        
        WriteCsv(path, sortedRecords);
    }

    private static void EnsureFileAndRirectory(string path)
    {
        var directory = Path.GetDirectoryName(path);
        if (string.IsNullOrEmpty(directory) && Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (!File.Exists(path))
        {
            using var fs = File.Create(path);
        }
    }
}
