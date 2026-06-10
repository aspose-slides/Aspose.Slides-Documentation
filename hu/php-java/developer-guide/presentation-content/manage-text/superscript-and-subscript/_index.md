---
title: Kezelje a felső- és alsóindexet prezentációkban PHP használatával
linktitle: Felső- és alsóindex
type: docs
weight: 80
url: /hu/php-java/superscript-and-subscript/
keywords:
- felsőindex
- alsóindex
- felsőindex hozzáadása
- alsóindex hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Mesteri módon kezelje a felső- és alsóindexet az Aspose.Slides for PHP via Java segítségével, és emelje prezentációit professzionális szövegformázással a maximális hatásért."
---
## **Áttekintés**

Az Aspose.Slides olyan funkciókat biztosít, amelyekkel felső‑ és alsóindexű szöveget integrálhat PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációiba. Akár kémiai képleteket, matematikai egyenleteket kell kiemelnie, akár lábjegyzetekkel szeretné megjegyzéseit ellátni, ezek a speciális formázási lehetőségek segítenek a tisztaság és a pontosság megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazzon zökkenőmentesen felső‑ és alsóindex stílusokat, és hogyan érjen el professzionális eredményt minden dián.

## **Felső és alsó index szöveg kezelése**
Felső‑ vagy alsóindexű szöveget bármely bekezdés‑részben hozzáadhat. Az Aspose.Slides szövegkeretben a felső‑ vagy alsóindex szöveg hozzáadásához a [**setEscapement**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setEscapement) metódust kell használni a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PortionFormat) osztályban.

Ez a tulajdonság a felső‑ vagy alsóindex szöveget adja vissza vagy állítja be (érték -100 % (alsóindex) és 100 % (felsőindex) között). Például:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon a diára egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) [Rectangle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeType#Rectangle) típusú elemet.
- Hozzáférés a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumhoz, amely a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-hez tartozik.
- Törölje a meglévő bekezdéseket.
- Hozzon létre egy új bekezdés‑objektumot a felsőindex szöveg tárolásához, és adja hozzá az [IParagraphs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParagraphs) gyűjteményhez a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-ben.
- Hozzon létre egy új portion objektumot.
- Állítsa be az Escapement tulajdonságot a részre 0‑tól 100‑ig a felsőindex hozzáadásához. (0 = nincs felső index)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Portion) számára, majd adja hozzá a bekezdés portion gyűjteményéhez.
- Hozzon létre egy új bekezdés‑objektumot az alsóindex szöveg tárolásához, és adja hozzá az IParagraphs gyűjteményhez az ITextFrame‑ben.
- Hozzon létre egy új portion objektumot.
- Állítsa be az Escapement tulajdonságot a részre 0‑tól -100‑ig az alsóindex hozzáadásához. (0 = nincs alsó index)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Portion) számára, majd adja hozzá a bekezdés portion gyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább látható.

```php
  # Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
  $pres = new Presentation();
  try {
    # Diát lekér
    $slide = $pres->getSlides()->get_Item(0);
    # Szövegdoboz létrehozása
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Bekezdés létrehozása felsőindex szöveghez
    $superPar = new Paragraph();
    # Rész létrehozása szokásos szöveggel
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Rész létrehozása felsőindex szöveggel
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Bekezdés létrehozása alsóindex szöveghez
    $paragraph2 = new Paragraph();
    # Rész létrehozása szokásos szöveggel
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Rész létrehozása alsóindex szöveggel
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Bekezdések hozzáadása a szövegdobozhoz
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Megmarad a felső és alsó index formázás PDF vagy más formátumba exportáláskor?**

Igen, az Aspose.Slides megfelelően megőrzi a felső‑ és alsóindex formázást a prezentációk PDF, PPT/PPTX, képek és egyéb támogatott formátumokba történő exportálásakor. A speciális formázás minden kimeneti fájlban érintetlen marad.

**Kombinálható a felső‑ vagy alsóindex más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**

Igen, az Aspose.Slides lehetővé teszi, hogy különböző szövegstílusokat kombináljon egyetlen szövegrészben. Bekapcsolhatja a félkövér, dőlt, aláhúzott stílusokat, és egyidejűleg alkalmazhatja a felső vagy alsó indexet a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) megfelelő tulajdonságainak beállításával.

**Működik a felső‑ és alsóindex formázás táblázatokban, diagramokban vagy SmartArt‑ban lévő szövegre is?**

Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és diagram elemeket. SmartArt használatakor hozzá kell férnie a megfelelő elemekhez (például a [SmartArtNode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnode/)) és azok szövegkonténereihez, majd hasonló módon konfigurálni kell a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) tulajdonságait.