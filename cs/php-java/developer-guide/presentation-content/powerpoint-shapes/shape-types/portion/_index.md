---
title: Správa textových částí v prezentacích pomocí PHP
linktitle: Textová část
type: docs
weight: 70
url: /cs/php-java/portion/
keywords:
- textová část
- textový úsek
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak spravovat textové části v PowerPoint prezentacích pomocí Aspose.Slides pro PHP přes Java, což zvyšuje výkon a umožňuje přizpůsobení."
---
## **Úvod**

Textová část představuje specifický úsek textu uvnitř odstavce a umožňuje s tímto úsekem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze části použít, když potřebujete získat pozici textového úseku, aplikovat formátování jen na část odstavce nebo řídit chování textu na podrobnější úrovni.

## **Získání souřadnic textové části**
[**getCoordinates()**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/getcoordinates/) metoda byla přidána do třídy [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/), která umožňuje získat souřadnice začátku části.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Úprava kontextu prezentace
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu použít hypertextový odkaz pouze na část textu uvnitř jednoho odstavce?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/php-java/manage-hyperlinks/); pouze tento úsek bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co přepisuje Portion a co je převzato z Paragraph/TextFrame?**

Vlastnosti na úrovni Portion mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/), engine ji získá z [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/); pokud není nastavena ani tam, získá ji z [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) nebo ze stylu [theme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro Portion na cílovém počítači/serveru chybějící?**

[Pravidla substituce písma](/slides/cs/php-java/font-selection-sequence/) se použijí. Text se může přeuspořádat: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost nebo přechod výplně textu specifické pro Portion nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) se mohou lišit od sousedních úseků.