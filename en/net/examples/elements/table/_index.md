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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Table**

Create a simple table with two rows and two columns.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] widths = { 80, 80 };
double[] heights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, widths, heights);

presentation.Save("table-01.pptx", SaveFormat.Pptx);
```

## **Access a Table**

Retrieve the first table shape on the slide.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] widths = { 80, 80 };
double[] heights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, widths, heights);

// Access first table on slide.
var firstTable = slide.Shapes.OfType<ITable>().First();
Console.WriteLine(firstTable.Rows.Count);

presentation.Save("table-02.pptx", SaveFormat.Pptx);
```

## **Remove a Table**

Delete a table from a slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] widths = { 80, 80 };
double[] heights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, widths, heights);

slide.Shapes.Remove(table);

presentation.Save("table-03.pptx", SaveFormat.Pptx);
```

## **Merge Table Cells**

Merge adjacent cells of a table into a single cell.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] widths = { 80, 80 };
double[] heights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, widths, heights);

table.MergeCells(table[0, 0], table[1, 1], false);

presentation.Save("table-04.pptx", SaveFormat.Pptx);
```
