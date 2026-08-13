---
title: Указание резервных шрифтов для презентаций в .NET
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/net/create-fallback-font/
keywords:
- резервный шрифт
- правило резервирования
- применить шрифт
- заменить шрифт
- диапазон Unicode
- отсутствующий глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Освойте Aspose.Slides для .NET, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая единообразное отображение текста на любом устройстве или ОС."
---
## **Обзор**

Aspose.Slides позволяет указывать резервные шрифты для визуализации презентаций и операций экспорта. Резервные шрифты используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение резервных шрифтов настраивается с помощью правил резервирования. Каждое правило связывает диапазон Unicode с одним или несколькими шрифтами, которые могут содержать требуемые глифы. Вы можете определять правила для разных диапазонов символов, добавлять или удалять резервные шрифты из существующих правил и упорядочивать несколько правил в коллекцию правил резервных шрифтов.

Правила резервных шрифтов являются настройками визуализации во время выполнения. Они не изменяют сам файл презентации и не сохраняются внутри файла PPTX.

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/iFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Используя различные способы, вы можете добавить список шрифтов:
string[] fontNames = new string[] { "Segoe UI Emoji, Segue UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Также можно [Remove()](https://reference.aspose.com/slides/ru/net/ifontfallbackrule/methods/remove) резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/ru/net/fontfallbackrule/methods/addfallbackfonts) добавить в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/ru/net/aspose.slides/fontfallbackrulescollection) может использоваться для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/FontFallBackRule), когда необходимо указать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ru/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### В чём разница между резервным шрифтом, заменой шрифта и внедрением шрифта?

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/net/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели могли видеть текст как задумано.

### Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при визуализации на экране?

Да. Резервные шрифты влияют на все [rendering and export operations](/slides/ru/net/convert-presentation/), где символы должны быть отрисованы, но отсутствуют в исходном шрифте.

### Меняют ли правила резервных шрифтов сам файл презентации и сохранятся ли они при последующих открытиях?

Нет. Правила резервных шрифтов являются настройками визуализации во время выполнения в вашем коде; они не сохраняются внутри файла .pptx и не появятся в PowerPoint.

### Влияют ли операционная система (Windows/Linux/macOS) и набор папок со шрифтами на выбор резервного шрифта?

Да. Движок ищет шрифты в доступных системных каталогах и любых [additional paths](/slides/ru/net/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

### Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отображения недостающих символов.