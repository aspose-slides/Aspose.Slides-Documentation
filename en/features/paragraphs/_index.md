---
title: Format paragraphs
description: Set paragraph alignment, spacing, indentation and list depth.
type: docs
url: /features/paragraphs/
weight: 740
feature_id: paragraphs
feature_group: text
translationKey: slides-feature-paragraphs
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-paragraph/
---

## **Overview**

Format individual paragraphs within a text frame. Adjust alignment and spacing, set margins or indents, and control the paragraph's level in a list. This lets a generated slide keep a clear structure without treating its text as a single formatting block.

## **Usage example**

This C# example places two paragraphs in one text box. The second is centered, has 10 points of space before it and uses 120-percent line spacing. It creates `paragraphs.pptx` and a PNG preview without an input file.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 480, 220);
shape.TextFrame.Paragraphs.Clear();
var firstParagraph = new Paragraph { Text = "Left aligned paragraph" };
firstParagraph.ParagraphFormat.Alignment = TextAlignment.Left;
var secondParagraph = new Paragraph { Text = "Centered paragraph with more breathing room" };
secondParagraph.ParagraphFormat.Alignment = TextAlignment.Center;
secondParagraph.ParagraphFormat.SpaceBefore = -10;
secondParagraph.ParagraphFormat.SpaceWithin = 120;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 10;
shape.TextFrame.Paragraphs.Add(firstParagraph);
shape.TextFrame.Paragraphs.Add(secondParagraph);
presentation.Save("paragraphs.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("paragraphs.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can paragraphs in one text box use different settings?**

Yes. Each paragraph has its own formatting, so headings, body text and list items can share a text frame.

### **What is the difference between paragraph spacing and line spacing?**

Paragraph spacing controls the gap before or after a paragraph. Line spacing controls the distance between lines within that paragraph. Positive spacing values are percentages; negative values specify points.

### **How do the first-line indent and left margin affect a paragraph?**

The left margin positions the paragraph body. The indent offsets its first line relative to that margin; a negative indent creates a hanging first line.

## **Guides**

- [Manage PowerPoint Text Paragraphs in .NET](/slides/net/manage-paragraph/)

Related feature: [Create bulleted lists](/slides/features/bulleted-lists/).
