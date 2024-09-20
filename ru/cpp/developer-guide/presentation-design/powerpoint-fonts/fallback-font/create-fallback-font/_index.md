---
title: Создание резервного шрифта
type: docs
weight: 10
url: /cpp/create-fallback-font/
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) и класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) представляет собой связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать подходящие глифы:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Используя несколько способов, вы можете добавить список шрифтов:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Также возможно [Удалить()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) резервный шрифт или [ДобавитьРезервныеШрифты()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) может быть использован для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule), когда необходимо указать правила замены резервного шрифта для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создание коллекции резервных шрифтов](/slides/cpp/create-fallback-fonts-collection/)
{{% /alert %}}