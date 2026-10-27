---
title: Add, remove and resize table rows and columns
description: Insert, copy, remove and resize table rows and columns.
type: docs
url: /features/table-rows-columns/
weight: 930
feature_id: table-rows-columns
feature_group: tables
translationKey: slides-feature-table-rows-columns
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-rows-and-columns/
---

## **Overview**

Change a table's structure as its data changes. Add or clone rows and columns, remove unused ones, and set column widths or minimum row heights. The table remains editable, so the layout can be adjusted again after saving.

## **Usage example**

This C# example appends a clone of the second row and removes the middle column. It uses zero-based indices and a table without merged cells. `table-rows-columns.pptx` contains three rows and the original first and last columns; a PNG previews the result.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var table = presentation.Slides[0].Shapes.AddTable(40, 40, new double[] { 180, 140, 180 }, new double[] { 50, 50 });
string[,] values = { { "Item", "Notebook" }, { "Unused", "Remove me" }, { "Count", "12" } };
for (var column = 0; column < 3; column++)
    for (var row = 0; row < 2; row++)
        table[column, row].TextFrame.Text = values[column, row];
table.Rows.AddClone(table.Rows[1], false);
table.Columns.RemoveAt(1, false);
presentation.Save("table-rows-columns.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("table-rows-columns.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Why can a row remain taller than the value I set?**

The row height is a minimum. Its content may require more space, and the table computes the resulting height.

### **How do row and column indexes change after removal?**

Removing a row or column shifts the later indices down by one. Recalculate positions before subsequent edits, especially when splitting or merging also changes the table grid.

### **Can I copy a row's formatting when adding rows?**

Yes. Clone an existing row to reuse its cell contents and formatting, then replace the new row’s data. Check the merge-handling argument for tables with merged cells.

## **Guides**

- [Manage Rows and Columns in PowerPoint Tables in .NET](/slides/net/manage-rows-and-columns/)

Related feature: [Create tables on slides](/slides/features/create-tables/).
