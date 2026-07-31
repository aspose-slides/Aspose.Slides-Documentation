---
title: Указать запасные шрифты для презентаций на C++
linktitle: Запасной шрифт
type: docs
weight: 10
url: /ru/cpp/create-fallback-font/
keywords:
- запасной шрифт
- правило запасного шрифта
- применить шрифт
- заменить шрифт
- диапазон Unicode
- пропущенный глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте Aspose.Slides для C++ чтобы задавать запасные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---
## **Обзор**

Aspose.Slides позволяет указать запасные шрифты для отображения презентаций и операций экспорта. Запасные шрифты используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение запасных шрифтов настраивается через правила запасных шрифтов. Каждое правило связывает диапазон Unicode с одним или несколькими шрифтами, которые могут содержать требуемые глифы. Вы можете определять правила для разных диапазонов символов, добавлять или удалять запасные шрифты из существующих правил и организовывать несколько правил в коллекцию правил запасных шрифтов.

Правила запасных шрифтов являются настройками рендеринга во время выполнения. Они не изменяют сам файл презентации и не сохраняются внутри файла PPTX.

## **Правила запасных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) для указания правил применения запасного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) представляет связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать подходящие глифы:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Используя различные способы, вы можете добавить список шрифтов:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Также можно [Remove()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/remove/) удалить запасный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) добавить запасные шрифты в существующий [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) объект.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrulescollection/) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/), когда необходимо указать правила замены запасных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создать коллекцию запасных шрифтов](/slides/ru/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чём разница между запасным шрифтом, заменой шрифта и внедрением шрифта?**

Запасный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифтов](/slides/ru/cpp/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Внедрение шрифтов](/slides/ru/cpp/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли видеть текст как задумано.

**Применяются ли запасные шрифты при экспорте, например PDF, PNG или SVG, или только при отображении на экране?**

Да. Запасные шрифты влияют на все [операции рендеринга и экспорта](/slides/ru/cpp/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяет ли настройка запасных шрифтов сам файл презентации и сохраняется ли эта настройка при последующих открытиях?**

Нет. Правила запасных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не будут видны в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор запасного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительных путях](/slides/ru/cpp/custom-font/), которые вы указываете. Если шрифт недоступен физически, правило, ссылающееся на него, не может сработать.

**Работают ли запасные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отрисовки отсутствующих символов.