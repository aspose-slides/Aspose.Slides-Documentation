---
title: Укажите резервные шрифты для презентаций в С++
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/cpp/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применить шрифт
- заменить шрифт
- диапазон Unicode
- отсутствующий глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- С++
- Aspose.Slides
description: "Освойте Aspose.Slides для С++, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---

## **Правила резервного шрифта**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) и класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Используя несколько способов, вы можете добавить список шрифтов:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```




Также возможно [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule), когда необходимо задать правила замены резервного шрифта для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**В чём разница между резервным шрифтом, заменой шрифта и внедрением шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/cpp/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Внедрение шрифта](/slides/ru/cpp/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели видели текст так, как задумано.

**Применяются ли резервные шрифты при экспорте в PDF, PNG или SVG, или только при рендеринге на экране?**

Да. Резервный шрифт влияет на все [операции рендеринга и экспорта](/slides/ru/cpp/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяет ли настройка резервного шрифта сам файл презентации и сохраняется ли она при последующих открываниях?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не появятся в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор папок со шрифтами на выбор резервного шрифта?**

Да. Движок определяет шрифты из доступных системных папок и любых [дополнительных путей](/slides/ru/cpp/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отображения недостающих символов.