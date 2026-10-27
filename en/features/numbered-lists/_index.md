---
title: Create numbered lists
description: Create numbered lists with a chosen style and starting value.
type: docs
url: /features/numbered-lists/
weight: 800
feature_id: numbered-lists
feature_group: text
translationKey: slides-feature-numbered-lists
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-lists/
---

## **Overview**

Use generated numbering for paragraph lists rather than typing numbers into the text. Choose the numbering style and starting value, then add or reorder list paragraphs as needed. The numbering can be recalculated when the presentation is rendered.

## **Usage example**

This C# example creates three decimal-numbered paragraphs starting at 4, 5 and 6. Setting the start value explicitly on each paragraph makes the intended sequence clear. It saves `numbered-lists.pptx` and renders the numbering to PNG.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 220);
shape.TextFrame.Paragraphs.Clear();
string[] items = { "Collect data", "Build report", "Share results" };
for (var index = 0; index < items.Length; index++)
{
    var paragraph = new Paragraph { Text = items[index] };
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
    paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)(4 + index);
    paragraph.ParagraphFormat.MarginLeft = 35;
    paragraph.ParagraphFormat.Indent = -25;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 24;
    shape.TextFrame.Paragraphs.Add(paragraph);
}
presentation.Save("numbered-lists.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("numbered-lists.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can a list start at a number other than one?**

Yes. Set the starting value for the numbered list, for example when continuing a sequence from another slide.

### **How can I indent a second-level numbered paragraph?**

Set its paragraph depth and adjust its left margin and indent. Choose the numbering settings for that paragraph as well; indentation alone does not define the desired sequence.

### **Can I choose a numbering style other than decimal digits?**

Yes. Select an available numbering preset, such as Roman numerals or letters. Check the rendered result with the fonts and viewer used by your audience.

## **Guides**

- [Manage Bulleted and Numbered Lists in Presentations in .NET](/slides/net/manage-lists/)

Related feature: [Create bulleted lists](/slides/features/bulleted-lists/).
