---
title: Apply table styles
description: Apply built-in table styles and banding options.
type: docs
url: /features/table-styles/
weight: 920
feature_id: table-styles
feature_group: tables
translationKey: slides-feature-table-styles
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-table/
---

## **Overview**

Choose a table style to give headings, rows and columns a consistent appearance. Set options such as first-row emphasis or horizontal banding, then use individual cell formatting for exceptions. Reuse a style across tables to keep a presentation consistent.

## **Usage example**

This C# example applies a built-in medium table style, emphasizes the header and enables horizontal banding. It creates `table-styles.pptx` and a PNG preview. Direct cell formatting can be used afterwards for individual exceptions.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var table = presentation.Slides[0].Shapes.AddTable(40, 40, new double[] { 240, 180 }, new double[] { 50, 50, 50 });
string[,] values = { { "Region", "North", "South" }, { "Sales", "120", "145" } };
for (var column = 0; column < 2; column++)
    for (var row = 0; row < 3; row++)
        table[column, row].TextFrame.Text = values[column, row];
table.StylePreset = TableStylePreset.MediumStyle2Accent1;
table.FirstRow = true;
table.HorizontalBanding = true;
presentation.Save("table-styles.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("table-styles.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can I author a custom table-style definition?**

This feature applies the built-in style presets. Use direct cell formatting when you need appearance settings beyond those presets.

### **Can I turn banded rows on and off?**

Yes. Change the table’s horizontal-banding option. Vertical banding is controlled separately.

### **Do explicit cell formats override a table style?**

Direct formatting can override style-derived appearance for individual cells. Remove or adjust those local settings when you want the built-in style to determine the result.

## **Guides**

- [Manage Presentation Tables in .NET](/slides/net/manage-table/)

Related feature: [Format table cells](/slides/features/format-table-cells/).
