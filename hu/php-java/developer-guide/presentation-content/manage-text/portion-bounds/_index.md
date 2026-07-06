---
title: Szövegrészlet határok lekérése prezentációkból PHP-ben
linktitle: Részlet határok
type: docs
weight: 47
url: /hu/php-java/portion-bounds/
keywords:
- szövegrészlet határok
- szövegrészlet
- szövegrész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan lehet lekérni a szövegrészlet határait PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A szövegrészlet egy bekezdésen belüli konkrét szövegszakaszt jelöl, és lehetővé teszi, hogy a környező tartalomtól függetlenül dolgozzon ezzel a szakaszzal. Az Aspose.Slides-ban a részek akkor használhatók, amikor a szövegszakasz határait kell lekérdezni, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szinten kell a szöveg viselkedését szabályozni.

Ez a cikk bemutatja, hogyan lehet lekérni egy szövegrészlet határoló téglalapját a [Portion::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/getrect/) használatával. Emellett bemutatja, hogyan lehet lekérni a szövegrészlet elejének koordinátáit a [Portion::getCoordinates](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/getcoordinates/) használatával. Továbbá kiemeli a gyakori részlethez kapcsolódó forgatókönyveket, például egyetlen szövegszakaszra való hiperhivatkozás alkalmazását, a formázás megoldásának megértését a részlet, bekezdés, szövegkeret és téma öröklődésén keresztül, valamint a megadott betűtípus hiánya esetén történő kezelést.

## **A szövegrészlet határainak lekérése**

Használja a [Portion::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/getrect/) a szövegrészlet határoló téglalapjának lekéréséhez:

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

## **A szövegrészlet koordinátáinak lekérése**

Használja a [Portion::getCoordinates](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/getcoordinates/) a szövegrészlet elejének koordinátáinak lekéréséhez:

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

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, egy [hiperhivatkozás hozzárendelése](/slides/hu/php-java/manage-hyperlinks/) egy egyedi részlethez; csak ez a szakasz lesz kattintható, nem a teljes bekezdés.

**Hogyan működik a stílus öröklés: mit felülír egy részlet, és mi származik bekezdésből vagy szövegkeretből?**

A részletszintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/), az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/)‑tól veszi. Ha ott sem van beállítva, az Aspose.Slides a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/theme/) stílusát használja.

**Mi történik, ha a részlethez megadott betűtípus hiányzik a céleszközön vagy a szerveren?**

[Betűtípus helyettesítési szabályok](/slides/hu/php-java/font-selection-sequence/) érvényesek. A szöveg újra tördelődhet: a metrikák, elválasztás és a szélesség változhat, ami a pontos elhelyezés szempontjából fontos.

**Beállíthatok részlet‑specifikus szövegtöltés átlátszóságot vagy színátmenetet a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) szinten eltérhet a szomszédos szakaszoktól.