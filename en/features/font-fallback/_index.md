---
title: Configure font fallback
description: Choose fallback fonts for specific character ranges.
type: docs
url: /features/font-fallback/
weight: 1240
feature_id: font-fallback
feature_group: rendering
translationKey: slides-feature-font-fallback
feature_catalogue_version: 3
feature_guides:
- /slides/net/fallback-font/
---

## **Overview**

Define ordered font fallbacks for characters missing from the preferred font. Rules can target Unicode ranges and list several fonts in order, helping multilingual presentations render with a suitable glyph source. Make those fonts available to the library before rendering.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Use a Greek character outside the base Microsoft Himalaya font's character coverage. Install Arial and Microsoft Himalaya before running. The rule assigns Arial to the Greek Unicode range for rendering; fallback rules are render-time configuration.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.TextFrame.Text = "α";
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Microsoft Himalaya");
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 72;
var rules = new FontFallBackRulesCollection();
rules.Add(new FontFallBackRule(0x0370, 0x03FF, "Arial"));
presentation.FontsManager.FontFallBackRulesCollection = rules;
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("fallback.png", Aspose.Slides.ImageFormat.Png);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does fallback order matter?**

Yes. The library tries the configured font sequence for the character range. Put the preferred fallback first.

### **How is missing-glyph fallback different from font substitution?**

Substitution replaces an unavailable font family. Missing-glyph fallback supplies a font for characters the selected font cannot display.

### **Can I assign fallback rules to a specific Unicode range?**

Yes. Define the start and end Unicode code points and the fallback font or ordered font list for that range.

## **Guides**

- [Manage Fallback Fonts for Presentations in .NET](/slides/net/fallback-font/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).
