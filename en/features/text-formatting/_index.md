---
title: Format text within slides
description: Apply fonts, sizes, colors and emphasis to parts of a paragraph.
type: docs
url: /features/text-formatting/
weight: 750
feature_id: text-formatting
feature_group: text
translationKey: slides-feature-text-formatting
feature_catalogue_version: 3
feature_guides:
- /slides/net/text-formatting/
---

## **Overview**

Format individual text portions so words in the same paragraph can have different appearances. Change font, size, color, emphasis and other text settings without replacing the entire paragraph. This is useful for highlighting a value or styling a title with mixed formatting.

## **Usage example**

This C# example creates a single line with an Arial label and a bold blue Times New Roman value. Both portions remain editable in `text-formatting.pptx`; the PNG shows their mixed formatting. It requires Arial and Times New Roman on the rendering host.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();
var label = new Portion("Revenue: ");
label.PortionFormat.LatinFont = new FontData("Arial");
label.PortionFormat.FontHeight = 28;
label.PortionFormat.FillFormat.FillType = FillType.Solid;
label.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
var value = new Portion("$125,000");
value.PortionFormat.LatinFont = new FontData("Times New Roman");
value.PortionFormat.FontHeight = 28;
value.PortionFormat.FontBold = NullableBool.True;
value.PortionFormat.FillFormat.FillType = FillType.Solid;
value.PortionFormat.FillFormat.SolidFillColor.Color = Color.RoyalBlue;
paragraph.Portions.Add(label);
paragraph.Portions.Add(value);
presentation.Save("text-formatting.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("text-formatting.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can I keep several styles in one line of text?**

Yes. Divide the text into portions and apply the required formatting to each one.

### **Can I change the text color without replacing its characters?**

Yes. Change the portion’s text-fill settings while leaving its text value unchanged.

### **Which formatting is inherited when a portion has no explicit font?**

Unset values can come from paragraph defaults, text styles, the layout or the master. Read effective formatting when you need the resolved font rather than only locally assigned settings.

## **Guides**

- [Format Presentation Text in .NET](/slides/net/text-formatting/)

Related feature: [Format paragraphs](/slides/features/paragraphs/).
