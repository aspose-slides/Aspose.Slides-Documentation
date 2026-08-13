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
## **Обзор**

Aspose.Slides позволяет задавать резервные шрифты для рендеринга презентаций и операций экспорта. Резервные шрифты используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение резервных шрифтов настраивается с помощью правил резервирования. Каждое правило связывает диапазон Unicode с одним или несколькими шрифтами, которые могут содержать требуемые глифы. Вы можете определить правила для разных диапазонов символов, добавить или удалить резервные шрифты из существующих правил и организовать несколько правил в коллекцию правил резервных шрифтов.

Правила резервных шрифтов являются настройками рендеринга во время выполнения. Они не изменяют файл презентации и не сохраняются внутри файла PPTX.

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) представляет связь между заданным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать нужные глифы:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Используя разные способы, вы можете добавить список шрифтов:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Также возможно вызвать [Remove()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/remove/) для удаления резервного шрифта или [AddFallBackFonts()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrulescollection/) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/), когда требуется задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ru/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/cpp/font-substitution/) заменяет полностью указанный шрифт другим шрифтом. [Font embedding](/slides/ru/cpp/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли видеть текст так, как задумано.

### Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при отображении на экране?

Да. Резервный шрифт влияет на все [rendering and export operations](/slides/ru/cpp/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

### Изменяет ли настройка резервного шрифта сам файл презентации и сохраняется ли она при последующих открываниях?

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри файла .pptx и не видны в PowerPoint.

### Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?

Да. Движок ищет шрифты в доступных системных папках и в любых [additional paths](/slides/ru/cpp/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

### Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для рендеринга отсутствующих символов.