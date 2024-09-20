---
title: Создание резервного шрифта
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "Шрифты, резервный шрифт, презентация PowerPoint на Python, Aspose.Slides для Python через .NET"
description: "Резервный шрифт в PowerPoint на Python"
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) и класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) представляет собой ассоциацию между указанным диапазоном Юникода, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать соответствующие глифы:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Используя несколько способов, вы можете добавить список шрифтов:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Также возможно [Удалить()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) резервный шрифт или [ДобавитьРезервныеШрифты()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) может быть использован для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), когда необходимо указать правила замены резервного шрифта для нескольких диапазонов Юникода.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создание коллекции резервных шрифтов](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}