---
title: Create Fallback Font
type: docs
weight: 10
url: /java/create-fallback-font/
---

Aspose.Slides supports [IFontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) interface and [FontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class to specify the rules to apply a fallback font. [FontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

It is also possible to [remove](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) fallback font or [addFallBackFonts](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) into existing [FontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) can be used to organize a list of [FontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/java/create-fallback-fonts-collection/)
{{% /alert %}}
