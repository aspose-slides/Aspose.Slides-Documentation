---
title: Extract Table Data
type: docs
weight: 40
url: /net/examples/content-extraction/tables/
description: "Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates."
---

Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `output/` in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        Directory.CreateDirectory("output");
        ExtractTables();
    }

    private sealed record Cell(int Row, int Column, int FirstRow, int FirstColumn, int RowSpan, int ColumnSpan, bool Merged, string? Text);
    private sealed record TableData(int Slide, string Shape, Cell[] Cells);
    private static bool IsMergedAnchor(ICell cell, int row, int column) => !cell.IsMergedCell || cell.FirstRowIndex == row && cell.FirstColumnIndex == column;
    private static void ExtractTables()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        var tables = new List<TableData>();
        var csv = new StringBuilder("Slide,Shape,Row,Column,Text\n");
        for (int slideIndex = 0; slideIndex < input.Slides.Count; slideIndex++)
        {
            foreach (var table in Walk(input.Slides[slideIndex].Shapes).OfType<ITable>())
            {
                var cells = new List<Cell>();
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int column = 0; column < table.Columns.Count; column++)
                    {
                        var cell = table[column, row]; // Aspose indexes column first, then row.
                        string? text = IsMergedAnchor(cell, row, column) ? cell.TextFrame.Text : null;
                        var record = new Cell(row, column, cell.FirstRowIndex, cell.FirstColumnIndex, cell.RowSpan, cell.ColSpan, cell.IsMergedCell, text);
                        cells.Add(record);
                        csv.AppendLine(string.Join(",", slideIndex + 1, CsvCell(table.Name), record.Row, record.Column, CsvCell(record.Text ?? "")));
                    }
                }

                tables.Add(new TableData(slideIndex + 1, table.Name, cells.ToArray()));
            }
        }

        Json("output/tables.json", tables);
        File.WriteAllText("output/tables.csv", csv.ToString(), new UTF8Encoding(false));
        Console.WriteLine("Results: " + Path.GetFullPath("output"));
    }

    private static void CreateInput()
    {
        using var presentation = new Presentation();
        var group = presentation.Slides[0].Shapes.AddGroupShape();
        var table = group.Shapes.AddTable(30, 30, [200, 160, 200], [45, 45, 45]);
        table.Name = "Source table";
        table[0, 0].TextFrame.Text = "Name";
        table[1, 0].TextFrame.Text = "Info";
        table.MergeCells(table[1, 0], table[2, 0], false);
        table[0, 1].TextFrame.Text = "A,β";
        table[1, 1].TextFrame.Text = "東京";
        table[2, 1].TextFrame.Text = "\"Q\"";
        table[0, 2].TextFrame.Text = "é";
        presentation.Save("output/input.pptx", SaveFormat.Pptx);
    }

    private static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
            {
                foreach (var child in Walk(group.Shapes))
                    yield return child;
            }
        }
    }

    private static void Json(string path, object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json, new UTF8Encoding(false));
    }

    private static string CsvCell(string text) => "\"" + text.Replace("\"", "\"\"") + "\"";
}
```

## **Expected result and checks**

`output/tables.json` retains all nine zero-based grid coordinates. The merged anchor has a column span of two; its covered cell has JSON null text, represented as a blank CSV field in `output/tables.csv`. CSV fields quote commas, quotes and Unicode correctly.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "tables": 1,
  "grid_cells": 9,
  "merged_coverage_explicit": true,
  "unicode_and_csv_quoting_checked": true,
  "group_traversal_checked": true
}
```

Rows and columns in each table are zero-based; slide numbers are one-based. JSON records every grid position and the anchor/extent of merged regions. Covered cells use null text, preventing duplicated merged-cell content. CSV uses blank text for those covered positions; consult JSON for merge structure.

## **Learn more**

- [Manage Presentation Tables in .NET](/slides/net/manage-table/)
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
