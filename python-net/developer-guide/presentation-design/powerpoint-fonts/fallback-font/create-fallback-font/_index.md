---
title: Create Fallback Font
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "Fonts, fallback font, PowerPoint presentation Python, Aspose.Slides for Python via .NET"
description: "Fallback font in PowerPoint in Python"
---

Aspose.Slides supports [IFontFallBackRule](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iFontFallBackRule/) interface and [FontFallBackRule](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/FontFallBackRule/) class to specify the rules to apply a fallback font. [FontFallBackRule](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/FontFallBackRule/) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Using multiple ways you can add fonts list:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



It is also possible to [Remove()](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ifontfallbackrule/) fallback font or [AddFallBackFonts()](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/fontfallbackrule/) into existing [FontFallBackRule](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/FontFallBackRule/) object.

[FontFallBackRulesCollection](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/fontfallbackrulescollection/) can be used to organize a list of [FontFallBackRule](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/FontFallBackRule/) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}