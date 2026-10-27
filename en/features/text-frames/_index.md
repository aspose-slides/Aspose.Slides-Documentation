---
title: Work with text frames
description: Control text margins, wrapping, alignment and orientation within shapes.
type: docs
url: /features/text-frames/
weight: 730
feature_id: text-frames
feature_group: text
translationKey: slides-feature-text-frames
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-textbox/
---

## **Overview**

Work with a shape's text frame to control how its text sits inside the available space. Set margins, wrapping and vertical alignment, or choose a vertical text orientation. Text-frame settings apply to the container while paragraphs and portions handle the content inside it.

## **Usage example**

This C# example creates two paragraphs in one rectangle, sets 12-point internal margins and saves an editable text frame to `text-frames.pptx`. The PNG previews the same slide; no input file is needed.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 440, 180);
shape.AddTextFrame("First paragraph");
shape.TextFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
shape.TextFrame.TextFrameFormat.MarginLeft = 12;
shape.TextFrame.TextFrameFormat.MarginRight = 12;
shape.TextFrame.TextFrameFormat.WrapText = NullableBool.True;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
presentation.Save("text-frames.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("text-frames.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Where do I format just one word?**

Use portion-level text formatting. A text frame can contain several paragraphs and differently formatted portions.

### **How do I tell whether a shape has a text frame?**

Check that the shape supports text and that its text frame is available before reading or editing it. Picture frames and tables need their own object handling.

### **Can a text frame contain several paragraphs?**

Yes. Add paragraphs to the text frame. Each paragraph can contain separately formatted portions.

## **Guides**

- [Manage Text Boxes in Presentations in .NET](/slides/net/manage-textbox/)

Related feature: [Format text within slides](/slides/features/text-formatting/).
