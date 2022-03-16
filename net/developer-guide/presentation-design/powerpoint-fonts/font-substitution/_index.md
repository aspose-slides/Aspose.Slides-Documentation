---
title: Font Substitution
type: docs
weight: 70
url: /net/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Substitute font in PowerPoint in C# or .NET"
---

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This C# code demonstrates the font substitution process:

```c#
// Loads a presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Loads the source font that will be replaced
IFontData sourceFont = new FontData("SomeRareFont");

// Loads the new font
IFontData destFont = new FontData("Arial");

// Adds a font rule for font replacement
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Adds the rule to font substitute rules collection
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Adds the font rule collection to the rule list
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

Bitmap bmp = presentation.Slides[0].GetThumbnail(1f, 1f);

// Saves the image to disk in the JPEG format
bmp.Save("Thumbnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
```

{{%  alert title="NOTE"  color="warning"   %}} 

You may want to see [**Font Replacement**](/slides/net/font-replacement/). 

{{% /alert %}}
