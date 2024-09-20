---
title: Публичный API и обратимо несовместимые изменения в Aspose.Slides для .NET 15.1.0
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) или [удаленные](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) классы, методы, свойства и так далее, а также другие изменения, введенные в API Aspose.Slides для .NET 15.1.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобально заменять шрифты по всей презентации и временно для рендеринга.

Введено новое свойство "FontsManager" класса Presentation. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection FontSubstRuleList** Свойство

Эта коллекция экземпляров IFontSubstRule используется для замены шрифтов во время рендеринга. IFontSubstRule имеет свойства SourceFont и DestFont, реализующие интерфейс IFontData, и свойство ReplaceFontCondition, позволяющее выбрать условие замены ("WhenInaccessible" или "Always").

**IFontData[] GetFonts()** Метод

Используется для получения всех шрифтов, используемых в текущей презентации.

**ReplaceFont** Методы

Используется для постоянной замены шрифта в презентации.

Следующий пример показывает, как заменить шрифт в презентации:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNewRomanFont.pptx", SaveFormat.Pptx);


``` 

Другой пример демонстрирует замену шрифта для рендеринга, когда он недоступен:

``` csharp

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