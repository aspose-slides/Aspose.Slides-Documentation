---
title: Укажите резервные шрифты для презентаций в .NET
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Освойте Aspose.Slides для .NET, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---

## **Правила резервного шрифта**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать правильные глифы:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways, you can add fonts list:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Также можно [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) объект.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)может использоваться для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**В чем разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Встраивание шрифта](/slides/ru/net/embedded-font/) упаковывает шрифты внутри выходного файла, чтобы получатели могли корректно просматривать текст.

**Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при рендеринге на экране?**

Да. Резервные шрифты влияют на все [операции рендеринга и экспорта](/slides/ru/net/convert-presentation/), где необходимо вывести символы, отсутствующие в исходном шрифте.

**Изменяют ли настройки резервных шрифтов сам файл презентации и сохраняются ли они при последующих открытиях?**

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительных путях](/slides/ru/net/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не сработает.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения недостающих символов.