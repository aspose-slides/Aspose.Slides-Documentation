---
title: Populate Tables from Data
type: docs
weight: 40
url: /net/examples/templates-data/populate-tables/
description: "Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting."
---

Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        const string csv = """
            Customer,Amount,Date
            "A,β",12.30,2026-01-01
            東京,4.50,2026-01-02
            """;
        var rows = ReadRows(csv);
        if (rows is null)
            return;
        using var presentation = new Presentation();
        var table = presentation.Slides[0].Shapes.AddTable(35, 50, [280, 140, 180], [50, 45]);
        table.Name = "Records";
        string[] labels = ["Customer", "Amount", "Date"];
        for (int column = 0; column < labels.Length; column++)
        {
            table[column, 0].TextFrame.Text = labels[column];
            table[column, 0].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;
        }

        Fill(table, rows);
        presentation.Save("report.pptx", SaveFormat.Pptx);
        SavePreview(presentation, "preview.png");
        Console.WriteLine($"Created report.pptx with {rows.Count} data rows.");
    }

    private sealed record Row(string Customer, decimal Amount, DateTime Date);
    private static List<Row>? ReadRows(string text)
    {
        using var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(text));
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        parser.TrimWhiteSpace = false;
        string[]? header = parser.ReadFields();
        if (header is null || !header.SequenceEqual(new[] { "Customer", "Amount", "Date" }))
        {
            Console.Error.WriteLine("Expected Customer,Amount,Date header.");
            return null;
        }

        var rows = new List<Row>();
        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();
            if (fields is null || fields.Length != 3 || string.IsNullOrWhiteSpace(fields[0]) || !decimal.TryParse(fields[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount) || !DateTime.TryParseExact(fields[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                Console.Error.WriteLine("Each row needs Customer, Amount and a yyyy-MM-dd Date.");
                return null;
            }

            rows.Add(new Row(fields[0], amount, date));
        }

        return rows;
    }

    private static void Fill(ITable table, List<Row> rows)
    {
        const int customerColumn = 0;
        const int amountColumn = 1;
        const int dateColumn = 2;
        if (rows.Count == 0)
        {
            table.Rows.RemoveAt(1, false); // Keep only the header.
            return;
        }

        for (int i = 0; i < rows.Count; i++)
        {
            if (i > 0)
                table.Rows.AddClone(table.Rows[1], false);
            var record = rows[i];
            table[customerColumn, i + 1].TextFrame.Text = record.Customer;
            table[amountColumn, i + 1].TextFrame.Text = record.Amount.ToString("0.00", CultureInfo.InvariantCulture);
            table[dateColumn, i + 1].TextFrame.Text = record.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }

    private static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(800, 450));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
}
```

## **Expected result and checks**

`report.pptx` has a bold header and two data rows with a quoted comma, Unicode, invariant amounts and ISO dates. `preview.png` shows the table. Header-only CSV keeps only the header. In evaluation mode, long text may be truncated when reopened; the download checks dates with that limitation in mind.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "data_rows": 2,
  "quoted_comma_and_unicode_checked": true,
  "invariant_numbers_checked": true,
  "empty_keeps_header": true,
  "missing_field_rejected": true,
  "header_format_retained": true
}
```

CSV parsing uses the .NET TextFieldParser and invariant number/date conversion. An empty dataset keeps only the header. A malformed row with a missing field is rejected. Every cell is assigned after cloning so data does not leak from the previous row.

## **Learn more**

- [Manage Presentation Tables in .NET](/slides/net/manage-table/)
- [Manage Rows and Columns in PowerPoint Tables in .NET](/slides/net/manage-rows-and-columns/)
- [Manage Table Cells in Presentations in .NET](/slides/net/manage-cells/)


## **Open and run the complete project**

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
