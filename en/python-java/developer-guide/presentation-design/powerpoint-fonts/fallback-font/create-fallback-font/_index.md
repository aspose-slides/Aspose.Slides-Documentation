---
title: Specify Fallback Fonts for Presentations in Python via Java
linktitle: Fallback Font
type: docs
weight: 10
url: /python-java/create-fallback-font/
keywords:
- fallback font
- fallback rule
- apply font
- replace font
- Unicode range
- missed glyph
- proper glyph
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Master Aspose.Slides for Python via Java to set fallback fonts in PPT, PPTX and ODP files, safeguarding consistent text display on any device or OS."
---

## **Overview**

Aspose.Slides allows you to specify fallback fonts for presentation rendering and export operations. Fallback fonts are used when the primary font does not contain glyphs for particular characters.

Fallback behavior is configured through fallback rules. Each rule associates a Unicode range with one or more fonts that may contain the required glyphs. You can define rules for different character ranges, add or remove fallback fonts from existing rules, and organize multiple rules in a fallback font rules collection.

Fallback rules are runtime rendering settings. They do not modify the presentation file itself and are not stored inside the PPTX file.

## **Fallback Rules**

Aspose.Slides provides the [FontFallBackRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/) class to specify rules for applying fallback fonts. This class represents an association between a Unicode range used to search for missing glyphs and a list of fonts that may contain the required glyphs:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Use multiple ways to specify a list of fonts.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

You can also remove a fallback font using [remove](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/#remove) or add fallback fonts using [addFallBackFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) in an existing [FontFallBackRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrulescollection/) can organize a list of [FontFallBackRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/) objects when you need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**What is the difference between a fallback font, font substitution, and font embedding?**

A fallback font is used only for characters missing in the primary font. [Font substitution](/slides/python-java/font-substitution/) replaces the entire specified font with another font. [Font embedding](/slides/python-java/embedded-font/) packages the fonts inside the output file so recipients can view the text as intended.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Yes. Fallback affects all [rendering and export operations](/slides/python-java/convert-presentation/) where characters must be drawn but are absent in the source font.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

No. Fallback rules are runtime rendering settings in your code; they are not stored inside the .pptx and won’t appear in PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Yes. The engine resolves fonts from available system folders and any [additional paths](/slides/python-java/custom-font/) you provide. If a font isn’t physically available, a rule referencing it cannot take effect.

**Does fallback work for WordArt, SmartArt, and charts?**

Yes. When these objects contain text, the same glyph-substitution mechanism applies to render missing characters.
