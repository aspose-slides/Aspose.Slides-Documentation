---
title: Укажите резервные шрифты для презентаций в Python
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/python-net/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применение шрифта
- замена шрифта
- диапазон Unicode
- пропущенный глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте Aspose.Slides для Python через .NET, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая единообразное отображение текста на любом устройстве или ОС."
---

## **Указать резервные шрифты**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) представляет связь между указанным диапазоном Unicode, используемым для поиска пропущенных глифов, и списком шрифтов, которые могут содержать правильные глифы:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Можно добавить список шрифтов несколькими способами:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Также возможно [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) резервный шрифт или [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**В чем разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/python-net/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Встраивание шрифта](/slides/ru/python-net/embedded-font/) помещает шрифты внутрь выходного файла, чтобы получатели могли видеть текст так, как задумывается.

**Применяются ли резервные шрифты при экспорте, например в PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервные шрифты влияют на все [операции рендеринга и экспорта](/slides/ru/python-net/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

**Изменяет ли настройка резервных шрифтов сам файл презентации и будет ли она сохранена при последующих открытиях?**

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

**Влияет ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительных путях](/slides/ru/python-net/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может вступить в силу.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отображения пропущенных символов.