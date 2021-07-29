---
title: Create Fallback Font
type: docs
weight: 10
url: /cpp/create-fallback-font/
---

Aspose.Slides supports [IFontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) interface and [FontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) class to specify the rules to apply a fallback font. [FontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) class represents an association between the specified Unicode range, used for searching missed glyphs, and a list of fonts that may contain proper glyphs:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



It is also possible to [Remove()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) fallback font or [AddFallBackFonts()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) into existing [FontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) object.

[FontFallBackRulesCollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)can be used to organize a list of [FontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) objects, when there is a need to specify fallback font replacement rules for multiple Unicode ranges.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/cpp/create-fallback-fonts-collection/)
{{% /alert %}}