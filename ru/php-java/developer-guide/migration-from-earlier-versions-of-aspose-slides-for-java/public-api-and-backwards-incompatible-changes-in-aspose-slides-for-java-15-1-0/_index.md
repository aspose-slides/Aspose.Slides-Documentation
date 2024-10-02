---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 15.1.0
type: docs
weight: 100
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) классов, методов, свойств и так далее, любых новых ограничений и других [изменений](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), введённых с API Aspose.Slides для PHP через Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Известны проблемы с некоторыми маркерами изображений и объектами WordArt, которые будут исправлены в Aspose.Slides для PHP через Java 15.2.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобально заменять шрифты по всей презентации и временно для рендеринга.

Представлен новый метод getFontsManager() класса Presentation. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection getFontSubstRuleList**() метод

Это коллекция экземпляров IFontSubstRule, используемых для замены шрифтов во время рендеринга. IFontSubstRule имеет методы getSourceFont() и getDestFont(), реализующие интерфейс IFontData, и метод getReplaceFontCondition(), который позволяет выбрать условие замены ("WhenInaccessible" или "Always").

**IFontData[] getFonts()** метод может быть использован для получения всех шрифтов, используемых в текущей презентации.

**replaceFont(...)** методы могут быть использованы для постоянной замены шрифта в презентации. 

Следующий пример показывает, как заменить шрифт в презентации:

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);
```

Другой пример показывает замену шрифта для рендеринга, когда он недоступен:

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # Шрифт Arial будет использован вместо SomeRareFont, когда он недоступен
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);
```