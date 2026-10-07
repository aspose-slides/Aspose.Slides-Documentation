---
title: Manage Table Cells in Presentations in .NET
linktitle: Manage Cells
type: docs
weight: 30
url: /net/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage PowerPoint table cells in C#: identify merged cells, remove borders, split cells, and set background colors and images with Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides allows you to access and modify table cells in PowerPoint presentations. This article explains how to identify merged table cells, remove cell borders, work with cell numbering after merging or splitting cells, change a cell’s background color, and add an image inside a table cell. The examples show how to create or open a presentation, get a table from a slide, update cell formatting through cell properties, and save the modified presentation as a PPTX file.

Aspose.Slides uses zero-based indices to access table cells in the order `(column, row)`.

## **Identify a Merged Table Cell**

The example opens an existing presentation and accesses the first shape on the first slide as a table. It assumes that the slide and shape exist and that the shape is a table. It then iterates through all rows and columns and uses [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) to identify cells in merged regions. For each match, it prints the cell coordinates in `row;column` order, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), and the region's starting coordinates, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) and [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Remove Table Cell Borders**

Create a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) and add a table to its first slide with [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Column widths, row heights, and the table position are specified in points. The example sets all four cell borders to [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), making them invisible.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Merge Table Cells**

Use [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) to combine a rectangular range of table cells into one cell. Specify the cells at the top-left and bottom-right corners of the range. The final argument controls whether the merge may include cells outside the specified range; `false` keeps the merge within that range.

The example creates a 4-by-4 table with 70-point columns and rows, then merges the four central cells from `(1, 1)` through `(2, 2)`. The resulting cell spans two columns and two rows, while the table's underlying grid retains four columns and four rows. To access the merged cell's content or formatting, use its top-left position: `table[1, 1]` in this example. The other positions in the merged range remain part of the table grid, so the indices of cells outside the range do not change.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Split Table Cells**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.

This example creates a 4-by-4 table with 70-point columns and rows and calls [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.

After this split, the two halves are accessed as `table[1, 1]` and `table[2, 1]`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Split Merged Cells by Row or Column Span**

To prepare merged template cells for data population, use [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) to split along an existing row boundary, or [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) to split along a column boundary.

The `index` argument counts rows in the upper part or columns in the left part of the split; it is relative to the merged region:

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

The example expects a presentation to have a table as the first shape on the first slide, with `(1, 2)` and `(1, 3)` merged vertically. Starting from the lower position, it uses [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) and [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) to locate the origin and checks both spans. `SplitByRowSpan(1)` then separates rows 2 and 3 for product names. For a horizontal two-column merge, use `SplitByColSpan(1)` instead.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Retrieve the resulting cells from the table after splitting.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

The table grid and surrounding cell indices stay unchanged. Retrieve the resulting cells by their coordinates; here, both have spans of 1 and [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) prints `False`. Larger regions can remain partly merged after one split.

The original text and its formatting remain in the upper (or left) cell; the new cell is empty but inherits cell formatting such as fill, borders, and margins. Populate the cells after splitting and set any required text formatting explicitly.

The saved presentation contains separate "Product A" and "Product B" cells with the template's cell formatting retained. See the [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) for details.

## **Change the Table Cell Background Color**

This example creates a table with 150-point columns and 50-point rows. It sets [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) to solid and [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) to red for cell `(2, 3)`, in the third column and fourth row.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Add an Image Inside a Table Cell**

Place the input image in the working directory before running this example. It loads the image with [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) and adds it to the presentation's image collection with [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). It then assigns the image to the picture fill of cell `(0, 0)`, the first cell in the table.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) stretches the image to fill the cell, which may change its aspect ratio. Column widths and row heights are in points. The loaded image is disposed automatically by its using declaration.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.
