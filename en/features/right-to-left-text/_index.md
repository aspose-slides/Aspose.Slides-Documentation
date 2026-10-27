---
title: Work with right-to-left text
description: Render right-to-left paragraphs and mixed-direction text.
type: docs
url: /features/right-to-left-text/
weight: 850
feature_id: right-to-left-text
feature_group: text
translationKey: slides-feature-right-to-left-text
feature_catalogue_version: 3
feature_guides:
- /slides/net/text-formatting/
---

## **Overview**

Set paragraph direction for text such as Arabic and combine it with left-to-right words or numbers. The renderer handles text shaping and bidirectional ordering, while your application supplies the content and appropriate fonts. This helps multilingual slides keep a readable text flow.

## **Usage example**

This C# example sets Arabic paragraph direction explicitly, separately from right alignment. It uses Arial, which must be available with Arabic glyphs on the rendering host, and saves `right-to-left-text.pptx` and a PNG preview. Inspect the preview for joined Arabic glyphs and right alignment.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 580, 120);
shape.AddTextFrame("مرحبا بالعالم");
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.RightToLeft = NullableBool.True;
paragraph.ParagraphFormat.Alignment = TextAlignment.Right;
var format = paragraph.Portions[0].PortionFormat;
format.ComplexScriptFont = new FontData("Arial");
format.LatinFont = new FontData("Arial");
format.FontHeight = 30;
presentation.Save("right-to-left-text.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("right-to-left-text.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can one paragraph contain both Arabic and Latin text?**

Yes. Mixed-direction content can share a paragraph. Use the paragraph direction and suitable fonts for the intended layout.

### **Is right alignment sufficient to enable right-to-left paragraph flow?**

No. Alignment chooses the paragraph’s position; direction controls its base text flow. Set both when the layout calls for a right-aligned RTL paragraph.

### **What fonts are needed for Arabic or Hebrew text?**

Use fonts containing the required script glyphs and shaping support. Make them available on the rendering host, either installed or loaded from an application-managed font source.

## **Guides**

- [Format Presentation Text in .NET](/slides/net/text-formatting/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).
