---
title: Set font substitution rules
description: Choose replacement fonts when rendering presentation text.
type: docs
url: /features/font-substitution/
weight: 770
feature_id: font-substitution
feature_group: text
translationKey: slides-feature-font-substitution
feature_catalogue_version: 3
feature_guides:
- /slides/net/font-substitution/
---

## **Overview**

Set font substitution rules to control which font is used when the original is unavailable or when your workflow requires a replacement. Make the replacement fonts accessible to the library so the rules can be applied during presentation rendering.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It assumes that Arial is available and that the deliberately named *CatalogueMissingFont* is not installed. It creates its own text, attaches the portion before assigning the font, and selects Arial for rendering. The PDF and PNG show the replacement; *font-source.pptx* keeps the original font assignment. Provide the replacement font legally in your deployment environment.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 100);
shape.TextFrame.Paragraphs.Clear();
var paragraph = new Paragraph();
shape.TextFrame.Paragraphs.Add(paragraph);
var portion = new Portion("Font substitution example");
paragraph.Portions.Add(portion);
portion.PortionFormat.LatinFont = new FontData("CatalogueMissingFont");
portion.PortionFormat.FontHeight = 28;
var rule = new FontSubstRule(new FontData("CatalogueMissingFont"), new FontData("Arial"), FontSubstCondition.WhenInaccessible);
var rules = new FontSubstRuleCollection();
rules.Add(rule);
presentation.FontsManager.FontSubstRuleList = rules;
presentation.Save("font-source.pptx", SaveFormat.Pptx);
presentation.Save("font-substitution.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("font-substitution.png", ImageFormat.Png);
```

## **FAQ**

### **Does the substitution report always reflect a configured rule?**

The report has limitations for explicit rules. Also attach a text portion to its paragraph before assigning its font when relying on substitution rules.

### **When should I attach a text portion before assigning its font?**

Attach the paragraph to the text frame and the portion to the paragraph before assigning the portion font when relying on substitution rules. The example follows that construction order.

### **How do substitution rules differ from missing-glyph fallback?**

A substitution rule selects a replacement for a specified font under its configured condition. Missing-glyph fallback selects fonts for characters that the chosen font cannot draw. They address different problems; see [font fallback](/slides/net/fallback-font/).

## **Guides**

- [Configure Font Substitution in Presentations in .NET](/slides/net/font-substitution/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).

## Runnable .NET examples

- [Replace Presentation Fonts](/slides/net/examples/fonts-text/replace-fonts/)
