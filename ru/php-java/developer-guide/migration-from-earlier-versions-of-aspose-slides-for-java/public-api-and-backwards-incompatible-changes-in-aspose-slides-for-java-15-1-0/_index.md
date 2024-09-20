---
title: Общий API и несовместимые изменения в Aspose.Slides для PHP через Java 15.1.0
type: docs
weight: 100
url: /php-java/общий-api-и-нснсовместимые-изменения-в-aspose-slides-для-java-15-1-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/php-java/общий-api-и-нснсовместимые-изменения-в-aspose-slides-для-java-15-1-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/php-java/общий-api-и-нснсовместимые-изменения-в-aspose-slides-для-java-15-1-0/), введенные с API Aspose.Slides для PHP через Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Есть известные проблемы с некоторыми изображениями маркеров и объектами WordArt, которые будут исправлены в Aspose.Slides для PHP через Java 15.2.0.

{{% /alert %}} 
## **Изменения в общем API**
### **Добавлена функциональность замены шрифтов**
Добавлена возможность глобально заменять шрифты по всей презентации и временно для рендеринга.

Введен новый метод getFontsManager() класса Presentation. Класс FontsManager имеет следующие члены:

**IFontSubstRuleCollection getFontSubstRuleList**() метод

Это коллекция экземпляров IFontSubstRule, используемых для замены шрифтов во время рендеринга. IFontSubstRule имеет методы getSourceFont() и getDestFont(), реализующие интерфейс IFontData, а также метод getReplaceFontCondition(), позволяющий выбрать условие замены ("WhenInaccessible" или "Always").

**IFontData[] getFonts()** метод можно использовать для получения всех шрифтов, используемых в текущей презентации.

**replaceFont(...)** методы могут быть использованы для постоянной замены шрифта в презентации. 

Следующий пример показывает, как заменить шрифт в презентации:

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNewRomanFont.pptx", SaveFormat::Pptx);

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
  # Шрифт Arial будет использоваться вместо SomeRareFont, когда он недоступен
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);

```