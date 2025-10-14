---
title: Table
type: docs
weight: 120
url: /net/examples/elements/table/
keywords:
- code example
- table
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with tables in Aspose.Slides for .NET: create, format, merge cells, apply styles, import data, and export with C# examples for PPT, PPTX, and ODP."
---

Examples for adding tables, accessing them, removing them, and merging cells using **Aspose.Slides for .NET**.

## **Add a Table**

Create a simple table with two rows and two columns.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Access a Table**

Retrieve the first table shape on the slide.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Access first table on slide.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Remove a Table**

Delete a table from a slide.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Merge Table Cells**

Merge adjacent cells of a table into a single cell.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
