---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.1.0
linktitle: Aspose.Slides для .NET 15.1.0
type: docs
weight: 130
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}}

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) классы, методы, свойства и т.п., а также другие изменения, введённые в API Aspose.Slides for .NET 15.1.0.

{{% /alert %}}
## **Изменения публичного API**
#### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобально заменять шрифт во всей презентации и временно для рендеринга.

В классе Presentation введено новое свойство «FontsManager». Класс FontsManager содержит следующие члены:

**IFontSubstRuleCollection FontSubstRuleList** Property

Эта коллекция экземпляров IFontSubstRule используется для замены шрифтов во время рендеринга. IFontSubstRule имеет свойства SourceFont и DestFont, реализующие интерфейс IFontData, а также свойство ReplaceFontCondition, позволяющее выбрать условие замены («WhenInaccessible» или «Always»).

**IFontData[] GetFonts()** Method

Используется для получения всех шрифтов, используемых в текущей презентации.

**ReplaceFont** Methods

Используется для постоянной замены шрифта в презентации.

Следующий пример показывает, как заменить шрифт в презентации:

```csharp
Presentation pres = new Presentation("PresContainsArialFont.pptx");
IFontData sourceFont = new FontData("Arial");
IFontData destFont = new FontData("Times New Roman");
pres.FontsManager.ReplaceFont(sourceFont, destFont);
pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);
```

Другой пример демонстрирует замену шрифта при рендеринге, когда исходный шрифт недоступен:

```csharp
Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
IFontData sourceFont = new FontData("SomeRareFont");
IFontData destFont = new FontData("Arial");
IFontSubstRule fontSubstRule = new FontSubstRule(
    sourceFont, destFont, FontSubstCondition.WhenInaccessible);
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);
pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
// Шрифт Arial будет использован вместо SomeRareFont, когда он недоступен
pres.Slides[0].GetThumbnail();
```