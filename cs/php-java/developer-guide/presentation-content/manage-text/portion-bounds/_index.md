---
title: Získání ohraničení textové části z prezentací v PHP
linktitle: Ohraničení části
type: docs
weight: 47
url: /cs/php-java/portion-bounds/
keywords:
- ohraničení textové části
- textová část
- textový úsek
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textové části v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Část textu představuje konkrétní fragment textu uvnitř odstavce a umožňuje pracovat s tímto fragmentem nezávisle na okolním obsahu. V Aspose.Slides lze části použít, když potřebujete získat ohraničení textového fragmentu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník části pomocí [Portion::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/getrect/). Také ukazuje, jak získat souřadnice začátku části pomocí [Portion::getCoordinates](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/getcoordinates/). Navíc zdůrazňuje běžné scénáře související s částmi, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení, jak se formátování řeší skrze část, odstavec, textový rámec a dědičnost motivu, a řešení případů, kdy je požadované písmo nedostupné.

## **Získání ohraničení textové části**

Použijte [Portion::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/getrect/) pro získání ohraničujícího obdélníku textové části:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Získání souřadnic textové části**

Použijte [Portion::getCoordinates](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/getcoordinates/) pro získání souřadnic začátku textové části:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Mohu aplikovat hypertextový odkaz pouze na část textu v rámci jednoho odstavce?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/php-java/manage-hyperlinks/) k jednotlivé části; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co přebíjí část a co je převzato z odstavce nebo textového rámce?**

Vlastnosti na úrovni části mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/), Aspose.Slides ji převezme z [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl z [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) nebo [theme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/theme/).

**Co se stane, pokud je písmo specifikované pro část na cílovém počítači nebo serveru chybějící?**

[Pravidla náhrady písma](/slides/cs/php-java/font-selection-sequence/) se uplatní. Text se může přetvořit: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifický pro část nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.