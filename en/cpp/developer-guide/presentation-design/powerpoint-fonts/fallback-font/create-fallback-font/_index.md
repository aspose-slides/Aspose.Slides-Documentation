---
title: Specify Fallback Fonts for Presentations in С++
linktitle: Fallback Font
type: docs
weight: 10
url: /cpp/create-fallback-font/
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
- С++
- Aspose.Slides
description: "Master Aspose.Slides for С++ to set fallback fonts in PPT, PPTX and ODP files, safeguarding consistent text display on any device or OS."
---

## **Fallback Rules**

Aspose.Slides supports [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) interface and [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) class to specify the rules to apply a fallback font. [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



It is also possible to [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) fallback font or [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) into existing [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) can be used to organize a list of [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**What is the difference between a fallback font, font substitution, and font embedding?**

A fallback font is used only for characters missing in the primary font. [Font substitution](/slides/cpp/font-substitution/) replaces the entire specified font with another font. [Font embedding](/slides/cpp/embedded-font/) packages the fonts inside the output file so recipients can view the text as intended.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Yes. Fallback affects all [rendering and export operations](/slides/cpp/convert-presentation/) where characters must be drawn but are absent in the source font.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

No. Fallback rules are runtime rendering settings in your code; they are not stored inside the .pptx and won’t appear in PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Yes. The engine resolves fonts from available system folders and any [additional paths](/slides/cpp/custom-font/) you provide. If a font isn’t physically available, a rule referencing it cannot take effect.

**Does fallback work for WordArt, SmartArt, and charts?**

Yes. When these objects contain text, the same glyph-substitution mechanism applies to render missing characters.
