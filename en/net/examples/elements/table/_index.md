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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

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

double[] columnWidths = { 80, 80 };
double[] rowHeights = { 30, 30 };
slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

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

double[] columnWidths = { 80, 80 };
double[] rowHeights = { 30, 30 };
slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

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

double[] columnWidths = { 80, 80 };
double[] rowHeights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

slide.Shapes.Remove(table);

presentation.Save("table-03.pptx", SaveFormat.Pptx);
```

## **Merge Table Cells**

Merge the rectangle from the top-left to the bottom-right cell, covering all four cells. These fixture cells are empty. The false flag disallows splitting cells; it is not a text-retention option.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 80, 80 };
double[] rowHeights = { 30, 30 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var topLeftCell = table[0, 0];
var bottomRightCell = table[1, 1];

// Merge the full 2-by-2 rectangle without splitting any cells.
table.MergeCells(topLeftCell, bottomRightCell, allowSplitting: false);

presentation.Save("table-04.pptx", SaveFormat.Pptx);
```
