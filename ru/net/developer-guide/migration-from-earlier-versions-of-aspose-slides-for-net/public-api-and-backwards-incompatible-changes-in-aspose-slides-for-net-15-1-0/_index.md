---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 15.1.0
linktitle: Aspose.Slides for .NET 15.1.0
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides for .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Public API Chages**
#### **Fonts Substitutions Functinality Has Been Added**
Добавлена возможность глобально заменять шрифт во всей презентации и временно для рендеринга.

В классе Presentation введено новое свойство **FontsManager**. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection FontSubstRuleList** Property

Эта коллекция экземпляров IFontSubstRule используется для подстановки шрифтов во время рендеринга. IFontSubstRule содержит свойства SourceFont и DestFont, реализующие интерфейс IFontData, а также свойство ReplaceFontCondition, позволяющее выбрать условие замены («WhenInaccessible» или «Always»).

**IFontData[] GetFonts()** Method

Используется для получения всех шрифтов, используемых в текущей презентации.

**ReplaceFont** Methods

Используется для постоянной замены шрифта в презентации. 

Следующий пример показывает, как заменить шрифт в презентации:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Другой пример демонстрирует подстановку шрифта для рендеринга, когда шрифт недоступен:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Шрифт Arial будет использоваться вместо SomeRareFont, когда недоступен

            pres.Slides[0].GetImage();

```