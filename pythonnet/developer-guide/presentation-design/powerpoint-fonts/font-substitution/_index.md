---
title: Font Substitution
type: docs
weight: 70
url: /pythonnet/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Substitute font in PowerPoint in Python"
---

## **Rule Based Font Substitution**
To replace the fonts by setting some rules of replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replaced inside the presentation.
- Load the replacing font.
- Add rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

```py
// Load presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Load source font to be replaced
IFontData sourceFont = new FontData("SomeRareFont");

// Load the replacing font
IFontData destFont = new FontData("Arial");

// Add font rule for font replacement
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Add rule to font substitute rules collection
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Add font rule collection to rule list
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

// Arial font will be used instead of SomeRareFont when inaccessible
Bitmap bmp = presentation.Slides[0].GetThumbnail(1f, 1f);

// Save the image to disk in JPEG format
bmp.Save("Thumbnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
```

