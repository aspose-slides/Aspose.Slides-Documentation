---
title: Create tables on slides
description: Add editable tables with defined rows, columns and cell content.
type: docs
url: /features/create-tables/
weight: 880
feature_id: create-tables
feature_group: tables
translationKey: slides-feature-create-tables
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-table/
---

## **Overview**

Create a table on a slide, choose its column widths and row heights, and fill its cells with text. Tables remain structured slide objects, making them useful for price lists, schedules and reports that readers may need to edit later.

## **Usage example**

This C# example uses Aspose.Slides for .NET and creates *table.pptx* without an input file. The table has two columns and two rows. Cell indexes are column first, then row, both starting at zero. Dimensions and the position on the slide are in points.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var table = presentation.Slides[0].Shapes.AddTable(40, 40, new double[] { 180, 120 }, new double[] { 40, 40 });
table[0, 0].TextFrame.Text = "Item";
table[1, 0].TextFrame.Text = "Quantity";
table[0, 1].TextFrame.Text = "Notebooks";
table[1, 1].TextFrame.Text = "12";
presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Are the cells still editable in the saved presentation?**

Yes. The table is stored as a presentation table rather than a single image.

### **How are table column widths and row heights specified?**

Use arrays of column widths and row heights, measured in points, when creating the table. Their lengths determine the initial column and row counts. Text layout and cell margins can affect the space required by cell contents.

### **Can I put several paragraphs in one cell?**

Yes. A cell contains a text frame that can hold multiple paragraphs and formatted portions. Set the initial cell text, then add paragraphs when you need separate paragraph formatting; see the [table guide](/slides/net/manage-table/).

## **Guides**

- [Manage Presentation Tables in .NET](/slides/net/manage-table/)

Related feature: [Format table cells](/slides/features/format-table-cells/).

## Runnable .NET examples

- [Extract Table Data](/slides/net/examples/content-extraction/tables/)
- [Populate Tables from Data](/slides/net/examples/templates-data/populate-tables/)
