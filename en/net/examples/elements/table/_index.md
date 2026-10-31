---
title: Table
type: docs
weight: 120
url: /net/examples/elements/table/
keywords:
- table
- add table
- access table
- remove table
- merge cells
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with tables in Aspose.Slides for .NET: create, format, merge cells, apply styles, import data, and export with C# examples for PPT, PPTX, and ODP."
---

Examples for adding tables, accessing them, removing them, and merging cells using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Table**

Create a simple table with two rows and two columns.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 2 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 2, "AddTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-001", "AddTable", "save-reopen-structure");
    }
}
```

## **Access a Table**

Retrieve the first table shape on the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        // Access first table on slide.
        var firstTable = slide.Shapes.OfType<ITable>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 2, "AccessTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-002", "AccessTable", "save-reopen-structure");
    }
}
```

## **Remove a Table**

Delete a table from a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        slide.Shapes.Remove(table);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<ITable>().Any(), "RemoveTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-003", "RemoveTable", "save-reopen-structure");
    }
}
```

## **Merge Table Cells**

Merge adjacent cells of a table into a single cell.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        
        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        table.MergeCells(table[0, 0], table[1, 1], false);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 1 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 1, "MergeTableCells: semantic check 1 failed.");
            Context.Require(Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Width - 160) < 0.1 && Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Height - 60) < 0.1, "MergeTableCells: semantic check 2 failed.");
        });
        Context.Pass("elements/table/block-004", "MergeTableCells", "save-reopen-structure");
    }
}
```
