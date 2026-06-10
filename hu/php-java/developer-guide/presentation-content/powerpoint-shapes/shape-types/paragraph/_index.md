---
title: Bekezdés határainak lekérése a bemutatókban PHP használatával
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/php-java/paragraph/
keywords:
- bekezdés határ
- szövegrész határ
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés és szövegrész határait az Aspose.Slides for PHP via Java-ban, a szöveg elhelyezésének optimalizálásához PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések és szövegrészek határát, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet a bekezdés téglalapját egy `TextFrame`-ben a `getRect()` használatával lekérni, hogyan lehet a bekezdés és a rész koordinátáit egy táblázatcellás szövegkeretben megszerezni, és kiemeli a fontos részleteket, mint például a mértékegységek, a szöveg tördelésének hatása a határokra, a pixel átalakítás, valamint a hatékony bekezdésformázási értékek.

## **Bekezdés és szakasz koordináták lekérése egy TextFrame-ben**
Aspose.Slides for PHP via Java használatával a fejlesztők most már lekérhetik a bekezdés téglalap koordinátáit a TextFrame bekezdéggyűjteményén belül. Emellett lehetővé teszi a [the coordinates of portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getCoordinates) lekérését egy bekezdés szakaszgyűjteményén belül. Ebben a témában egy példával bemutatjuk, hogyan lehet a bekezdés téglalap koordinátáit és a szakasz pozícióját a bekezdésen belül lekérni.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Bekezdés téglalap koordinátáinak lekérése**
A [**getRect()**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getRect) metódus használatával a fejlesztők lekérhetik a bekezdés határát alkotó téglalapot.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A bekezdés és szakasz méretének lekérése egy táblázatcellás TextFrame-ben**

A [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Portion) vagy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretben használhatja a [Portion::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getRect) és a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getRect) metódusokat.

Ez a példakód bemutatja a leírt műveletet:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Milyen egységben adják vissza a bekezdés és szövegrészek koordinátáit?**

Pontban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre érvényes a dián.

**A szóeltörés befolyásolja a bekezdés határait?**

Igen. Ha a [wrapping](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setwraptext/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-ben, a szöveg a terület szélességéhez igazodik, ami módosítja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők képpontokra az exportált képen?**

Igen. A pontokat a következőképpen konvertálja képpontokra: pixels = points × (DPI / 72). Az eredmény a renderelés/exportálás során kiválasztott DPI-től függ.

**Hogyan szerezhetem meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**

Használja a [effective paragraph formatting data structure](/slides/hu/php-java/shape-effective-properties/); ez visszaadja a végső, egyesített értékeket a behúzásokra, távolságokra, tördelésre, RTL-re és egyéb beállításokra vonatkozóan.