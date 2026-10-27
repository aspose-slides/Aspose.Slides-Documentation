---
title: Save presentations as ODP
description: Save presentations in the OpenDocument ODP format.
type: docs
url: /features/write-odp/
weight: 70
feature_id: write-odp
feature_group: formats
translationKey: slides-feature-write-odp
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-openoffice-odp/
---

## **Overview**

Export a presentation as ODP for use in an OpenDocument workflow. The output contains slide content such as text and tables, along with presentation notes. This gives you a document that can be opened and edited rather than a set of rendered slide images.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a title and a two-column table, then saves *table.odp*. The cells contain *Item*, *Count*, *Pens* and *12*, so the saved table can be checked after reopening.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Stock";
var table = slide.Shapes.AddTable(40, 120, new double[] { 240, 120 }, new double[] { 50, 50 });
table[0, 0].TextFrame.Text = "Item";
table[1, 0].TextFrame.Text = "Count";
table[0, 1].TextFrame.Text = "Pens";
table[1, 1].TextFrame.Text = "12";
presentation.Save("table.odp", SaveFormat.Odp);
```

## **FAQ**

### **Can I start with a PowerPoint file?**

Yes. Open the PowerPoint presentation and save it as ODP. The source file can stay unchanged.

### **Can I write an ODP to a memory stream?**

Yes. Choose ODP as the save format and pass a writable stream. Rewind the stream before reopening it or sending it to a reader.

### **How do I check visual differences after ODP export?**

Reopen the ODP and render representative slides, then compare them with the source presentation. Check fonts, text wrapping, tables and graphics in the application that will consume the ODP.

## **Guides**

- [Convert OpenDocument Presentations in .NET](/slides/net/convert-openoffice-odp/)

Related feature: [Read OpenDocument presentations](/slides/features/read-odp/).
