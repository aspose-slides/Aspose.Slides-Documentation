---
title: Create bulleted lists
description: Create bulleted lists with symbols, pictures and multiple levels.
type: docs
url: /features/bulleted-lists/
weight: 790
feature_id: bulleted-lists
feature_group: text
translationKey: slides-feature-bulleted-lists
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-lists/
---

## **Overview**

Format paragraphs as bullet items and choose the bullet appearance. Use symbols or picture bullets, set their size and color, and control indentation and paragraph depth for nested lists. The list structure stays editable in the saved presentation.

## **Usage example**

This C# example builds three editable bullet items. Their paragraph depths are 0, 1 and 2, with increasing left margins in points and a negative first-line indent. It creates `bulleted-lists.pptx` and a PNG preview.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 240);
shape.TextFrame.Paragraphs.Clear();
string[] items = { "Planning", "Implementation", "Review" };
for (var index = 0; index < items.Length; index++)
{
    var paragraph = new Paragraph { Text = items[index] };
    paragraph.ParagraphFormat.Depth = (short)index;
    paragraph.ParagraphFormat.MarginLeft = 25 + index * 25;
    paragraph.ParagraphFormat.Indent = -15;
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '•';
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 24;
    shape.TextFrame.Paragraphs.Add(paragraph);
}
presentation.Save("bulleted-lists.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("bulleted-lists.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can different levels use different bullet styles?**

Yes. Configure the paragraph and bullet settings for each level to create the hierarchy your slide needs.

### **Can I set a custom bullet character?**

Yes. Set a symbol bullet and choose its character. Use a font containing that glyph so the bullet can render on the target host.

### **How do indentation and hanging offset affect bullet layout?**

The left margin positions the text body. A negative first-line indent places the bullet to its left; increasing the margin for deeper paragraphs creates a visible hierarchy.

## **Guides**

- [Manage Bulleted and Numbered Lists in Presentations in .NET](/slides/net/manage-lists/)

Related feature: [Format paragraphs](/slides/features/paragraphs/).
