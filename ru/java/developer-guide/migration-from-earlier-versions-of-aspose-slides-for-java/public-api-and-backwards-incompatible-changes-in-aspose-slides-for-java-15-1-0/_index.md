---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.1.0
type: docs
weight: 100
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), введенные в API Aspose.Slides для Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Существуют известные проблемы с некоторыми изображениями и объектами WordArt, которые будут исправлены в Aspose.Slides для Java 15.2.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлены функции замены шрифтов**
Добавлена возможность глобально заменять шрифты по всей презентации и временно для рендеринга.

Введен новый метод getFontsManager() класса Presentation. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection getFontSubstRuleList**() метод

Это коллекция экземпляров IFontSubstRule, используемых для замены шрифтов во время рендеринга. IFontSubstRule имеет методы getSourceFont() и getDestFont(), реализующие интерфейс IFontData, и метод getReplaceFontCondition(), позволяющий выбрать условие замены ("КогдаНедоступен" или "Всегда").

**IFontData[] getFonts()** метод можно использовать для получения всех шрифтов, используемых в текущей презентации.

**replaceFont(...)** методы могут быть использованы для постоянной замены шрифта в презентации. 

Следующий пример демонстрирует, как заменить шрифт в презентации:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Другой пример демонстрирует замену шрифта для рендеринга, когда он недоступен:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Шрифт Arial будет использоваться вместо SomeRareFont, когда он недоступен

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```