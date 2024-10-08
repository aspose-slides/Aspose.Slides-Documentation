---
title: Fallback-Schriftart erstellen
type: docs
weight: 10
url: /de/cpp/create-fallback-font/
---

Aspose.Slides unterstützt das [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) Interface und die [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) Klasse, um die Regeln für die Anwendung einer Fallback-Schriftart festzulegen. Die [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) Klasse stellt eine Verbindung zwischen dem angegebenen Unicode-Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten können:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Mithilfe mehrerer Methoden können Sie die Schriftartenliste hinzufügen:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Es ist auch möglich, die Fallback-Schriftart mit [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) zu entfernen oder [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) zu einer vorhandenen [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) Objekten zu organisieren, wenn es notwendig ist, Fallback-Schriftart-Ersatzregeln für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftarten-Sammlung erstellen](/slides/de/cpp/create-fallback-fonts-collection/)
{{% /alert %}}