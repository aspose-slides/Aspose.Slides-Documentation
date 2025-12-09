---
title: Укажите резервные шрифты для презентаций в Python
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Освойте Aspose.Slides для Python через .NET, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая одинаковое отображение текста на любом устройстве или ОС."
---

## **Указать резервные шрифты**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) представляет ассоциацию между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Используя несколько способов, вы можете добавить список шрифтов:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```




Также можно [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), когда необходимо указать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ru/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/python-net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/python-net/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели могли увидеть текст как задумано.

**Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при рендеринге на экране?**

Да. Резервный шрифт влияет на все [rendering and export operations](/slides/ru/python-net/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

**Изменяет ли настройка резервного шрифта сам файл презентации и будет ли она сохраняться при будущих открываниях?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются в .pptx и не появятся в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/python-net/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для рендеринга недостающих символов.