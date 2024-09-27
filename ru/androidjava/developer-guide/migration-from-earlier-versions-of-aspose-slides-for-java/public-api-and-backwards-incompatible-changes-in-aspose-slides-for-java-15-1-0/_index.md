---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.1.0
type: docs
weight: 100
url: /ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) классов, методов, свойств и так далее, а также новых ограничений и других [изменений](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), введённых в API Aspose.Slides для Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Известны проблемы с некоторыми маркерами изображения и объектами WordArt, которые будут исправлены в Aspose.Slides для Java 15.2.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобально заменять шрифты в презентации и временно для отображения.

Введён новый метод getFontsManager() класса Presentation. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection getFontSubstRuleList**() метод

Это коллекция экземпляров IFontSubstRule, используемых для замены шрифтов во время рендеринга. IFontSubstRule имеет методы getSourceFont() и getDestFont(), реализующие интерфейс IFontData, и метод getReplaceFontCondition(), позволяющий выбрать условие замены ("WhenInaccessible" или "Always").

**IFontData[] getFonts()** метод можно использовать для извлечения всех шрифтов, используемых в текущей презентации.

**replaceFont(...)** методы могут быть использованы для постоянной замены шрифта в презентации.

Следующий пример показывает, как заменить шрифт в презентации:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Другой пример показывает замену шрифта для отображения, когда он недоступен:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Шрифт Arial будет использоваться вместо SomeRareFont, когда он будет недоступен

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```