---
title: Create Fallback Font
type: docs
weight: 10
url: /nodejs-java/create-fallback-font/
---

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
