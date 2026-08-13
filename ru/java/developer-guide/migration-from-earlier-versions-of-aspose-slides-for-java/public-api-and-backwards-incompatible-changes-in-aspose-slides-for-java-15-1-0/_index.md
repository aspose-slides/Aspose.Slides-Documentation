---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) введённые в API Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="info" %}} 

Известны проблемы с некоторыми маркерами‑изображениями и объектами WordArt, которые будут исправлены в Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобальной замены шрифтов во всей презентации и временной замены для рендеринга.

В классе Presentation введён новый метод getFontsManager(). Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection getFontSubstRuleList**() метод

Это коллекция экземпляров IFontSubstRule, используемых для замены шрифтов во время рендеринга. IFontSubstRule имеет методы getSourceFont() и getDestFont(), реализующие интерфейс IFontData, и метод getReplaceFontCondition(), позволяющий выбрать условие замены ("WhenInaccessible" или "Always").

**IFontData[] getFonts()** метод может использоваться для получения всех шрифтов, используемых в текущей презентации.

**replaceFont(...)** методы могут использоваться для постоянной замены шрифта в презентации.  

Следующий пример показывает, как заменить шрифт в презентации:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Другой пример показывает замену шрифта при рендеринге, когда он недоступен:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Шрифт Arial будет использоваться вместо SomeRareFont, когда он недоступен.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```