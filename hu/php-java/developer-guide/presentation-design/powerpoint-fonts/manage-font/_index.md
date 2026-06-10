---
title: Betűtípusok kezelése prezentációkban PHP használatával
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/php-java/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus tulajdonságok
- bekezdés
- szövegformázás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "A betűtípusok vezérlése PHP-ben az Aspose.Slides segítségével: beágyazás, helyettesítés és egyedi betűtípusok betöltése a PPT, PPTX és ODP prezentációk tiszta, márkahű és konzisztens megjelenéséért."
---
## **Betűtípushoz kapcsolódó tulajdonságok kezelése**
{{% alert color="primary" %}} 

A prezentációk általában szöveget és képeket egyaránt tartalmaznak. A szöveget különféle módokon lehet formázni, akár egyes részek és szavak kiemelésére, akár a vállalati stílusoknak megfelelően. A szövegformázás lehetővé teszi a felhasználók számára a prezentáció tartalmának megjelenésének változtatását. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for PHP via Java a diákon lévő bekezdések betűtulajdonságainak konfigurálásához.

{{% /alert %}} 

A betűtulajdonságok kezeléséhez egy bekezdésben az Aspose.Slides for PHP via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Érje el a [Placeholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/) alakzatokat a dián, és castolja őket [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-re.
4. Szerezze be a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) elemet a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-ből, amelyet a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) biztosít.
5. Igazítsa be a bekezdést (justify).
6. Érje el egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) szövegének [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) részét.
7. Definiálja a betűtípust a [FontData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontdata/) segítségével, és állítsa be a **Font** attribútumot a szöveg [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) számára.
   1. Állítsa a betűtípust félkövérre.
   2. Állítsa a betűtípust dőltre.
8. Állítsa be a betűszínét a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) segítségével, amely a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumon keresztül érhető el.
9. Mentse a módosított prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább látható. Egy egyszerű prezentációt vesz alapul, és formázza a betűket az egyik dián. Az alábbi képernyőképek mutatják a bemeneti fájlt és a kódrészletek által elvégzett módosításokat. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A bemeneti fájl szövege**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```php
  # Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Diát ér el a pozíciója alapján
    $slide = $pres->getSlides()->get_Item(0);
    # A dián az első és második helyőrzőt eléri, és AutoShape típusra konvertálja
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Az első bekezdést érjük el
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # A bekezdést igazítja
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Az első szakaszt érjük el
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Új betűtípusok definiálása
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Új betűtípusok hozzárendelése a szakaszhoz
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Betűtípus beállítása félközrré
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Betűtípus beállítása dőltre
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Betűtípus színének beállítása
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # A PPTX mentése a lemezre
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szöveg betűtípus tulajdonságainak beállítása**
{{% alert color="primary" %}} 

A **Betűtípushoz kapcsolódó tulajdonságok kezelése** részben említettük, hogy egy [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) használatos a hasonló formázású szöveg egy bekezdésben való tárolására. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for PHP via Java egy szövegdoboz létrehozásához, benne szöveggel, majd egy adott betűtípus és a betűcsalád egyéb tulajdonságainak meghatározásához.

{{% /alert %}} 

Egy szövegdoboz létrehozásához és a benne lévő szöveg betűtulajdonságainak beállításához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Adjon a diára egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t.
4. Távolítsa el a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-hez tartozó kitöltési stílust.
5. Érje el a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)- **TextFrame**-jét.
6. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-hez.
7. Szerezze meg a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumot, amely a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-hez tartozik.
8. Definiálja a betűtípust, amelyet a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/)-ban használni kíván.
9. Állítsa be a további betűtulajdonságokat, mint félkövér, dőlt, aláhúzott, szín és magasság, a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságokkal.
10. Írja ki a módosított prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább található.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtulajdonsággal, amelyet az Aspose.Slides for PHP via Java állított be**|

```php
  # Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Hozzáad egy Rectangle típusú AutoShape-et
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eltávolít minden kitöltési stílust, amely a AutoShape-hez tartozik
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Eléri a AutoShape-hez társított TextFrame-et
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Beállítja a betűtípust a Portion számára
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # A betűtípus félkövér tulajdonságának beállítása
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # A betűtípus dőlt tulajdonságának beállítása
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # A betűtípus aláhúzás tulajdonságának beállítása
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # A betűtípus magasságának beállítása
    $port->getPortionFormat()->setFontHeight(25);
    # A betűtípus színének beállítása
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # A prezentáció mentése a lemezre
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```