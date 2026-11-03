using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;
using Aspose.Slides;

internal static class Example
{
    public static ExampleContext Context = null!;
    public static void Setup()
    {
        Directory.CreateDirectory("output");
    }

    public static string Choice(string licensed, string evaluation) => Context.IsLicensed ? licensed : evaluation;
    public static void Require(bool value, string message)
    {
        if (!value)
            throw new InvalidOperationException(message);
    }

    public static void Result(object checks)
    {
        File.WriteAllText("output/result.json", JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static void Json(string path, object value)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (IShape shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
                foreach (var child in Walk(group.Shapes))
                    yield return child;
        }
    }

    public static List<string[]> Csv(string text, int columns)
    {
        using var parser = new TextFieldParser(new StringReader(text));
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        parser.TrimWhiteSpace = false;
        var rows = new List<string[]>();
        while (!parser.EndOfData)
        {
            var row = parser.ReadFields()!;
            if (row.Length != columns)
                throw new InvalidDataException("CSV field count differs.");
            rows.Add(row);
        }

        return rows;
    }

    public static string CsvCell(string text) => "\"" + text.Replace("\"", "\"\"") + "\"";
}
