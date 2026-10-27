---
title: Arrange text in columns
description: Lay out text in multiple columns within one text frame.
type: docs
url: /features/text-columns/
weight: 820
feature_id: text-columns
feature_group: text
translationKey: slides-feature-text-columns
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-textbox/
---

## **Overview**

Set the number of columns and the space between them for a text frame. Text can flow across the columns, making the layout useful for lists or longer passages on a wide slide. Keep paragraph formatting alongside the column settings.

## **Usage example**

This C# example uses a single 500-by-180-point text frame with two columns separated by 20 points. Twelve paragraphs provide enough text to flow into both columns. It saves `text-columns.pptx` and a PNG layout preview.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 180);
shape.TextFrame.TextFrameFormat.ColumnCount = 2;
shape.TextFrame.TextFrameFormat.ColumnSpacing = 20;
shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
shape.TextFrame.Paragraphs.Clear();
for (var number = 1; number <= 12; number++)
{
    var paragraph = new Paragraph { Text = $"Report item {number}" };
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 18;
    shape.TextFrame.Paragraphs.Add(paragraph);
}
presentation.Save("text-columns.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("text-columns.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Do I need a separate text box for every column?**

No. A single text frame can use multiple columns. Separate text boxes remain useful when each column needs independent content placement.

### **Can I control the spacing between text columns?**

Yes. Set the text-frame column spacing, measured in points. The gap reduces the width available to the text columns.

### **What determines the order in which text flows between columns?**

Text follows the text frame’s paragraph order and layout settings, flowing when the current column fills. Use separate text boxes when you need to position each column’s content independently.

## **Guides**

- [Manage Text Boxes in Presentations in .NET](/slides/net/manage-textbox/)

Related feature: [Format paragraphs](/slides/features/paragraphs/).
