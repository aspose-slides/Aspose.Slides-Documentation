---
title: Создание запасного шрифта
type: docs
weight: 10
url: /ru/net/create-fallback-font/
keywords: "Шрифты, запасной шрифт, презентация PowerPoint C#, Csharp, Aspose.Slides для .NET"
description: "Запасной шрифт в PowerPoint на C# или .NET"
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) для указания правил применения запасного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) представляет собой ассоциацию между указанным диапазоном Юникода, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать необходимые глифы:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Используя несколько способов, вы можете добавить список шрифтов:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



Также возможно [удалить](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) запасной шрифт или [добавить запасные шрифты](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) может быть использован для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), когда необходимо указать правила замены запасного шрифта для нескольких диапазонов Юникода.

{{% alert color="primary" title="См. также" %}} 
- [Создание коллекции запасных шрифтов](/slides/ru/net/create-fallback-fonts-collection/)
{{% /alert %}}