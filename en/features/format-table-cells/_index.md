---
title: Format table cells
description: Set individual cell fills, borders, margins and text formatting.
type: docs
url: /features/format-table-cells/
weight: 900
feature_id: format-table-cells
feature_group: tables
translationKey: slides-feature-format-table-cells
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-cells/
---

## **Overview**

Format cells independently to highlight totals, distinguish headings or improve spacing. A cell can have its own fill, border settings, text alignment and margins while remaining part of the table. Use this alongside a table style for details that need local formatting.

## **Usage example**

This C# example gives a header cell a dark-blue fill, a two-point white bottom border and bold white text. Cell margins are in points. It saves `format-table-cells.pptx` and a PNG preview; no existing presentation is needed.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var table = presentation.Slides[0].Shapes.AddTable(40, 40, new double[] { 220, 180 }, new double[] { 60, 60 });
table[0, 0].TextFrame.Text = "Product";
table[1, 0].TextFrame.Text = "Quantity";
table[0, 1].TextFrame.Text = "Notebook";
table[1, 1].TextFrame.Text = "12";
var header = table[0, 0];
header.CellFormat.FillFormat.FillType = FillType.Solid;
header.CellFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
header.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
header.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.White;
header.CellFormat.BorderBottom.Width = 2;
header.MarginLeft = 12;
var format = header.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
format.FontBold = NullableBool.True;
format.FillFormat.FillType = FillType.Solid;
format.FillFormat.SolidFillColor.Color = Color.White;
presentation.Save("format-table-cells.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("format-table-cells.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can each edge of a cell have a different border?**

Yes. Configure the cell's borders separately when a table needs different line widths or colors around particular cells.

### **How do cell margins affect the position of text within a cell?**

Margins reserve space between the cell’s edges and its text. Increasing them changes the usable text area without creating another shape.

### **How does cell text formatting differ from the cell fill?**

Cell fill paints the background. Text formatting applies to the paragraphs and portions in the cell, including font, size, emphasis and text color.

## **Guides**

- [Manage Table Cells in Presentations in .NET](/slides/net/manage-cells/)

Related feature: [Apply table styles](/slides/features/table-styles/).
