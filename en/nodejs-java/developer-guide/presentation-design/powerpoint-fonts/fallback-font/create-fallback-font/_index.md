---
title: Create Fallback Font
type: docs
weight: 10
url: /nodejs-java/create-fallback-font/
---

## **Fallback Rules**

Aspose.Slides supports [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) class and [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) class to specify the rules to apply a fallback font. [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Using multiple ways you can add fonts list:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

It is also possible to [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) fallback font or [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) into existing [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) can be used to organize a list of [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**What is the difference between a fallback font, font substitution, and font embedding?**

A fallback font is used only for characters missing in the primary font. [Font substitution](/slides/nodejs-java/font-substitution/) replaces the entire specified font with another font. [Font embedding](/slides/nodejs-java/embedded-font/) packages the fonts inside the output file so recipients can view the text as intended.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Yes. Fallback affects all [rendering and export operations](/slides/nodejs-java/convert-presentation/) where characters must be drawn but are absent in the source font.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

No. Fallback rules are runtime rendering settings in your code; they are not stored inside the .pptx and won’t appear in PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Yes. The engine resolves fonts from available system folders and any [additional paths](/slides/nodejs-java/custom-font/) you provide. If a font isn’t physically available, a rule referencing it cannot take effect.

**Does fallback work for WordArt, SmartArt, and charts?**

Yes. When these objects contain text, the same glyph-substitution mechanism applies to render missing characters.
