---
title: Szövegrészek kezelése bemutatókban PHP használatával
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/php-java/portion/
keywords:
- szövegrész
- szövegrészlet
- szöveg koordinátái
- szöveg pozíciója
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a szövegrészeket PowerPoint bemutatókban az Aspose.Slides for PHP Java-n keresztül, javítva a teljesítményt és a testreszabást."
---
## **Bevezetés**

Egy szövegrészlet egy bekezdésen belüli konkrét szövegtöredéket képvisel, és lehetővé teszi, hogy a töredékkel a környező tartalomtól függetlenül dolgozzon. Az Aspose.Slides-ben a részek akkor használhatók, amikor szükség van egy szövegtöredék pozíciójának lekérdezésére, formázás alkalmazására csak a bekezdés egy részére, vagy a szöveg viselkedésének részletesebb szintű szabályozására.

## **A szövegrészlet koordinátáinak lekérése**

[**getCoordinates()**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/getcoordinates/) metódus hozzá lett adva a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) osztályhoz, amely lehetővé teszi a rész elejének koordinátáinak lekérését.

```php
  # Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # A bemutató környezetének újraformálása
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

## **GYIK**

**Alkalmazhatok hivatkozást csak egy bekezdésen belüli szövegrészletre?**

Igen, egy egyéni részhez [rendelhatsz hivatkozást](/slides/hu/php-java/manage-hyperlinks/); csak ez a töredék lesz kattintható, nem az egész bekezdés.

**Hogyan működik a stílusöröklődés: mit felülír a Portion, és mi származik a Paragraph/TextFrame‑ből?**

A Portion szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumban, a motor a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) beállításait veszi; ha ott sem, akkor a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/theme/) stílusából.

**Mi történik, ha a Portion-hoz megadott betűkészlet hiányzik a célgépen/kiszolgálón?**

[Font substitution rules](/slides/hu/php-java/font-selection-sequence/) érvényesek. A szöveg átrendeződhet: a metrikák, elválasztás és a szélesség változhat, ami a pontos pozicionálásnál fontos.

**Beállíthatok a Portion-hoz specifikus szövegkitöltés átlátszóságot vagy gradienst, függetlenül a bekezdés többi részétől?**

Igen, a szövegszín, kitöltés és átlátszóság a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) szinten eltérő lehet a szomszédos töredékektől.