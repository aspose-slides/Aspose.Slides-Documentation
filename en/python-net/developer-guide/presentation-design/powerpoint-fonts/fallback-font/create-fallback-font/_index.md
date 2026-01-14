---
title: Specify Fallback Fonts for Presentations in Python
linktitle: Fallback Font
type: docs
weight: 10
url: /python-net/create-fallback-font/
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
- Aspose.Slides
description: "Master Aspose.Slides for Python via .NET to set fallback fonts in PPT, PPTX and ODP files, safeguarding consistent text display on any device or OS."
---

## **Specify Fallback Fonts**

Aspose.Slides supports [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) class to specify the rules to apply a fallback font. [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Using multiple ways you can add fonts list:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



It is also possible to [remove](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) fallback font or [add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) into existing [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) can be used to organize a list of [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**What is the difference between a fallback font, font substitution, and font embedding?**

A fallback font is used only for characters missing in the primary font. [Font substitution](/slides/python-net/font-substitution/) replaces the entire specified font with another font. [Font embedding](/slides/python-net/embedded-font/) packages the fonts inside the output file so recipients can view the text as intended.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Yes. Fallback affects all [rendering and export operations](/slides/python-net/convert-presentation/) where characters must be drawn but are absent in the source font.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

No. Fallback rules are runtime rendering settings in your code; they are not stored inside the .pptx and won’t appear in PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Yes. The engine resolves fonts from available system folders and any [additional paths](/slides/python-net/custom-font/) you provide. If a font isn’t physically available, a rule referencing it cannot take effect.

**Does fallback work for WordArt, SmartArt, and charts?**

Yes. When these objects contain text, the same glyph-substitution mechanism applies to render missing characters.
