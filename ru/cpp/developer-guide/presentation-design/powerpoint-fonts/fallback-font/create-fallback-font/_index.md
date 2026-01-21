---
title: Укажите резервные шрифты для презентаций на C++
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
- C++
- Aspose.Slides
description: "Освойте Aspose.Slides для C++, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая единообразное отображение текста на любом устройстве или ОС."
---

## **Правила резервного шрифта**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


Также можно вызвать метод [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) для удаления резервного шрифта или [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) для добавления резервных шрифтов в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/cpp/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Встраивание шрифта](/slides/ru/cpp/embedded-font/) помещает шрифты внутрь выходного файла, чтобы получатели могли видеть текст как задумано.

**Применяются ли резервные шрифты при экспорте в PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервные шрифты влияют на все [операции рендеринга и экспорта](/slides/ru/cpp/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

**Изменяется ли сам файл презентации при настройке резервных шрифтов и сохраняются ли эти настройки при будущих открытиях?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и в любых [дополнительных путях](/slides/ru/cpp/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не будет действовать.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для рендеринга недостающих символов.