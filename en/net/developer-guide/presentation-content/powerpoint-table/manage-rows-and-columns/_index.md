---
title: Manage Rows and Columns in PowerPoint Tables in .NET
linktitle: Rows and Columns
type: docs
weight: 20
url: /net/manage-rows-and-columns/
keywords:
- table row
- table column
- first row
- table header
- clone row
- clone column
- copy row
- copy column
- remove row
- remove column
- row text formatting
- column text formatting
- table style
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage table rows and columns in PowerPoint with Aspose.Slides for .NET and speed up presentation editing and data updates."
---

## **Introduction**

Aspose.Slides for .NET lets you manage table structure and formatting in PowerPoint presentations through the [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) class and [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interface. You can designate a header row, clone or remove rows and columns, and apply text formatting to an entire row or column.

This article explains these operations with C# examples. It also shows how to retrieve a table's style preset so you can reuse it. Table row and column indices are zero-based.

## **Control Row Height**

Use [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) to set a row's minimum height in points. It is a lower bound, not a fixed height. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) returns the actual height and is read-only. Access the row through [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

The example loads [row-height-input.pptx](row-height-input.pptx), which has a table as the first shape on the first slide. Its first row starts at 70 points. The cells use 18-point Arial text, wrapping, and 6-point top and bottom margins; the longer text in the second column wraps onto multiple lines. The example increases the minimum to 100 points, then decreases it to 20 points, prints the actual height after each change, and saves both results.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

With the supplied presentation, increasing the minimum adds space to the row. Decreasing it removes that extra space, but the actual height remains greater than 20 points because the text and cell margins need more room. Reducing the minimum alone cannot force the row below the space required by its content.

Several factors affect the actual height:

- **Text and font size:** longer text, explicit line breaks, or a larger font can require more vertical space.
- **Wrapping and column width:** with wrapping enabled, a narrower [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) can produce more lines. A wider column can reduce the space required vertically.
- **Cell margins:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) and [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) add vertical space. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) and [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) reduce the width available for text and can cause additional wrapping.

For this table without merged cells, the cell that needs the most vertical space determines the content-driven lower limit for the entire row. To make the row shorter, you may also need to shorten the text, reduce the font size or margins, or widen a column.

The images below show the same table at the same scale. In this run, the actual heights were 70, 100, and 55.2 points: the final row remained taller than its 20-point minimum. Exact text measurements can vary with the fonts available in your environment. Download the saved results: [increased minimum](row-height-increased.pptx) and [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Use the [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) property to mark the first row for header formatting. Its appearance depends on the table style applied to the table.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Access the table stored as the first shape on the slide.
4. Enable header formatting for its first row.
5. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide. It enables header formatting for the first row and saves `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clone a Table Row or Column**

Clone rows or columns to reuse their content and formatting. You can append a copy to the end of the table or insert it at a specific position.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) method.
5. Clone the required rows.
6. Clone the required columns.
7. Save the modified presentation.

The example requires `Test.pptx` with at least one slide. It creates a table with three columns and five rows, with dimensions specified in points. It appends copies of the first row and column, then inserts copies of the second row and column at index 3 (the fourth position). The resulting table has seven rows and five columns. The `false` argument disables cloning into adjacent merged rows or columns; this table has no merged cells.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Remove a Row or Column from a Table**

Remove rows or columns that are no longer needed in a table. Removing an item shifts the indices of the rows or columns that follow it.

1. Create a presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) method.
5. Remove the second row and second column.
6. Save the modified presentation.

This example creates a three-by-three table and removes the row and column at index 1, leaving a two-by-two table in `TestTable_out.pptx`. The dimensions are in points. The `false` argument disables removal of adjacent merged rows or columns; this table has no merged cells.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Set Text Formatting on the Table Row Level**

Apply text formatting to an entire row to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) for the first row.
4. Set [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) and [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) for the first row.
5. Set [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) for the second row.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two rows. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first row, then sets vertical text in the second row.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Set Text Formatting on the Table Column Level**

Apply text formatting to an entire column to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) for the first column.
4. Set [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) and [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) for the first column.
5. Set [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) for the second column.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two columns. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first column, then sets vertical text in the second column.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Get Table Style Properties**

Use the [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) property to retrieve the preset applied to a table and reuse it on another table. This identifies the preset rather than individual cell formatting overrides.

The example creates a table, applies [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), and reads the preset back. It prints `DarkStyle1` and saves the table in `table.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that's already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don't have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
