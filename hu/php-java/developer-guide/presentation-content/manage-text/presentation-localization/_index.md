---
title: Az előadás lokalizációjának automatizálása PHP-ben
linktitle: Előadás lokalizációja
type: docs
weight: 100
url: /hu/php-java/presentation-localization/
keywords:
- nyelv megváltoztatása
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizációját az Aspose.Slides for PHP segítségével Java-n keresztül, gyakorlati kódmintákkal és tippekkel a gyorsabb globális bevezetéshez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `LanguageId` a szövegre egy prezentációban az Aspose.Slides használatával. Megmutatja, hogyan nyithatunk meg egy prezentációt, adhatunk hozzá szöveggel ellátott alakzatot, rendelhetünk nyelvi azonosítót egy szövegrészhez, és menthetjük az eredményt PPTX fájlként.

## **Nyelv módosítása egy prezentációban és az alakzat szövegében**
- Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation)osztályból.
- Szerezze be egy dia hivatkozását az Index használatával.
- Adjon egy[AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)[Rectangle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeType#Rectangle) típusú alakzatot a diára.
- Adjon szöveget a TextFrame-hez.
- [Nyelvi azonosító beállítása](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) a szövegre.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább egy példán keresztül látható.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**A nyelvi azonosító automatikus szövegfordítást indít el?**

Nem. A[Language ID](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) az Aspose.Slides-ben a helyesírás- és nyelvtani ellenőrzés nyelvét tárolja, de nem fordítja le vagy módosítja a szöveg tartalmát. Ez egy metaadat, amelyet a PowerPoint a lektoráláshoz értelmez.

**A nyelvi azonosító befolyásolja a szóelválasztást és a sortöréseket a megjelenítés során?**

Az Aspose.Slides-ben a[language ID](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) a lektorálásra szolgál. A szóelválasztás minősége és a sorok tördelése elsősorban a[megfelelő betűtípusok](/slides/hu/php-java/powerpoint-fonts/) és az írásrendszer elrendezési/sortörés beállításainak rendelkezésre állásán múlik. A helyes megjelenítés biztosításához tegye elérhetővé a szükséges betűtípusokat, állítsa be a[betűtípus helyettesítési szabályokat](/slides/hu/php-java/font-substitution/), és/vagy[ágyazza be a betűtípusokat](/slides/hu/php-java/embedded-font/) a prezentációba.

**Beállíthatok különböző nyelveket egyetlen bekezdésen belül?**

Igen. A[Language ID](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) a szövegrész szintjén kerül alkalmazásra, így egyetlen bekezdésben több nyelv vegyesen használható különálló lektorálási beállításokkal.