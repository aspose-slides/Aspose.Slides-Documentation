---
title: Create Fallback Font
type: docs
weight: 10
url: /net/create-fallback-font/
---

Aspose.Slides supports [IFontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/iFontFallBackRule) interface and [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) class to specify the rules to apply a fallback font. [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-SetFontFallBack-SetFontFallBack.cs" >}}



It is also possible to [Remove()](https://apireference.aspose.com/net/slides/aspose.slides/ifontfallbackrule/methods/remove) fallback font or [AddFallBackFonts()](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrule/methods/addfallbackfonts) into existing [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrulescollection)[ ](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrulescollection)can be used to organize a list of [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/net/create-fallback-fonts-collection/)
{{% /alert %}}
