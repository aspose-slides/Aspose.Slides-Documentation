---
title: PHP-ben prezentációs alakzatok kezelése
linktitle: Alakzat manipuláció
type: docs
weight: 40
url: /hu/php-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérdezése
- alakzat alternatív szöveg
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-re
- alakzat igazítása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, szerkeszthet és optimalizálhat alakzatokat az Aspose.Slides for PHP via Java segítségével, és teljesítmény-orientált PowerPoint-prezentációkat szállíthat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk alakzatokkal a prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan találhatunk meg egy alakzatot egy dián, másolhatjuk azt, eltávolíthatjuk, elrejthetjük, módosíthatjuk a sorrendjét, lekérhetjük az Interop alakzatazonosítót, és beállíthatjuk az alternatív szöveget az azonosításhoz és a további feldolgozáshoz.

Emellett lefedi, hogyan érhetők el az alakzatok elrendezési formátumai, hogyan renderelhetünk egy alakzatot SVG-ként, hogyan igazíthatók az alakzatok egy dián, és hogyan használhatók a flip (tükrözés) tulajdonságok vízszintes és függőleges tükrözéshez. Továbbá a cikk egy rövid GYIK-ot tartalmaz az alakzatok kombinálásáról, a rétegezési sorrendről és az alakzatok zárolásáról.

## **Alakzat keresése egy dián**
Ez a téma egy egyszerű technikát ismertet, amely megkönnyíti a fejlesztők számára egy adott alakzat megtalálását egy dián anélkül, hogy a belső azonosítóját használnák. Fontos tudni, hogy a PowerPoint prezentációfájloknak nincs módja az alakzatok azonosítására egy dián, kivéve a belső egyedi azonosítót. Nehézséget jelent a fejlesztőknek egy alakzat megtalálása a belső egyedi azonosítóval. Az összes diára hozzáadott alakzat rendelkezik valamilyen alternatív szöveggel. Javasoljuk, hogy a fejlesztők az alternatív szöveget használják egy adott alakzat megtalálásához. Az MS PowerPoint segítségével definiálhatja az alternatív szöveget azokhoz az objektumokhoz, amelyeket a jövőben módosítani kíván.

Az alternatív szöveg beállítása után a kívánt alakzatra megnyithatja a prezentációt az Aspose.Slides for PHP via Java segítségével, és végigiterálhat az egy diára hozzáadott összes alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelő alternatív szöveggel rendelkező alakzat lesz a keresett alakzat. Ennek a technikának a jobb bemutatására létrehoztunk egy [findShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) metódust, amely megtalálja a specifikus alakzatot egy dián, és egyszerűen visszaadja azt.

```php
  # Hozzon létre egy Presentation osztályt, amely a prezentáció fájlt képviseli
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # A megtalálandó alakzat alternatív szövege
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Alakzat klónozása**
Alakzat klónozásához egy diára az Aspose.Slides for PHP via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia referenciaját az indexének használatával.
1. Hozzáférés a forrásdia alakzatgyűjteményéhez.
1. Új dia hozzáadása a prezentációhoz.
1. Alakzatok klónozása a forrásdia alakzatgyűjteményéből az új diába.
1. A módosított prezentáció mentése PPTX fájlként.

Az alábbi példa egy csoportos alakzatot ad hozzá egy diához.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX fájl mentése a lemezre
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat eltávolítása**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára bármely alakzat eltávolítását. Egy alakzat eltávolításához egy diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Keresse meg a megadott AlternativeText tulajdonságú alakzatot.
1. Távolítsa el az alakzatot.
1. Mentse a fájlt a lemezre.

```php
  # Presentation objektum létrehozása
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Négyszög típusú autoshape hozzáadása
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Prezentáció mentése a lemezre
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat elrejtése**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára bármely alakzat elrejtését. Egy alakzat elrejtéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Keresse meg a megadott AlternativeText tulajdonságú alakzatot.
1. Rejtse el az alakzatot.
1. Mentse a fájlt a lemezre.

```php
  # Presentation osztály példányosítása, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Négyszög típusú autoshape hozzáadása
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Prezentáció mentése a lemezre
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat sorrendjének módosítása**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára az alakzatok újrarendezését. Az újrarendezés meghatározza, melyik alakzat van elöl, és melyik hátul. Egy alakzat újrarendezéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá egy alakzatot.
1. Adjon szöveget az alakzat szövegdobozához.
1. Adjon hozzá egy másik alakzatot ugyanazzal a koordinátával.
1. Rendezze át az alakzatokat.
1. Mentse a fájlt a lemezre.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop alakzatazonosító lekérése**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára egy egyedi alakzatazonosító lekérését diára vonatkozóan, szemben a [getUniqueId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getuniqueid/) metódussal, amely a prezentáció szintjén ad egyedi azonosítót. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getofficeinteropshapeid/) metódust hozzáadták a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályhoz. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getofficeinteropshapeid/) metódus által visszaadott érték megfelel a Microsoft.Office.Interop.PowerPoint.Shape objektum Id értékének. Az alább egy példakód található.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Dia szintjén egyedi alakzatazonosító lekérése
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alternatív szöveg beállítása egy alakzathoz**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára bármely alakzat AlternateText (alternatív szöveg) beállítását.
A prezentációban lévő alakzatokat megkülönböztethetjük a `Alternative Text` vagy a [Shape Name](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setname/) metódus segítségével.
A [setAlternativeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setalternativetext/) és a [getAlternativeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getalternativetext/) metódusok olvashatók és beállíthatók az Aspose.Slides, valamint a Microsoft PowerPoint használatával.
Ezzel a módszerrel címkézhetünk egy alakzatot, és különböző műveleteket hajthatunk végre, például alakzat eltávolítása,
alakzat elrejtése vagy alakzatok átrendezése egy dián.
Egy alakzat AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá egy alakzatot a diához.
1. Végezzen el némi munkát az újonnan hozzáadott alakzattal.
1. Járja be az alakzatokat egy alakzat megtalálásához.
1. Állítsa be az AlternativeText-et.
1. Mentse a fájlt a lemezre.

```php
  # Presentation osztály példányosítása, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Négyszög típusú autoshape hozzáadása
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Prezentáció mentése a lemezre
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Elrendezési formátumok elérése egy alakzathoz**
Az Aspose.Slides for PHP via Java egyszerű API-t biztosít az alakzatok elrendezési formátumainak eléréséhez. Ez a cikk bemutatja, hogyan érheti el az elrendezési formátumokat.

Az alábbi példakód található.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat renderelése SVG-ként**
Az Aspose.Slides for PHP via Java most már támogatja egy alakzat SVG-ként történő renderelését. A [writeAsSvg](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) (és annak túlterhelése) metódus hozzá lett adva a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályhoz. Ez a metódus lehetővé teszi az alakzat tartalmának SVG fájlként történő mentését. Az alábbi kódrészlet megmutatja, hogyan exportálhatjuk egy dia alakzatát SVG fájlba.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat igazítása**
Az Aspose.Slides lehetővé teszi az alakzatok igazítását a dia margóihoz vagy egymáshoz viszonyítva. Ehhez hozzá lett adva a túlterhelt [SlidesUtil::alignShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/alignshapes/) metódus. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapesalignmenttype/) felsorolás meghatározza a lehetséges igazítási lehetőségeket.

**Példa 1**

Az alábbi forráskód a 1., 2. és 4. indexű alakzatokat a dia felső szélén igazítja.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Példa 2**

Az alábbi példa azt mutatja, hogyan igazítható a teljes alakzatgyűjtemény a gyűjtemény legalsó alakzatához viszonyítva.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tükrözés (Flip) tulajdonságok**
Az Aspose.Slides [ShapeFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/) osztálya lehetővé teszi a alakzatok vízszintes és függőleges tükrözésének vezérlését a `flipH` és `flipV` tulajdonságokon keresztül. Mindkét tulajdonság [NullableBool](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/) típusú, amely a `True` értékkel tükrözést, a `False` értékkel nincs tükrözést, vagy a `NotDefined` értékkel az alapértelmezett viselkedést jelenti. Ezek az értékek a alakzat [Frame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getFrame) tulajdonságán keresztül érhetők el.

A tükrözési beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/) példányt hozunk létre az alakzat aktuális pozíciója és mérete, a kívánt `flipH` és `flipV` értékek, valamint a forgási szög megadásával. Ennek a példánynak a shape [Frame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getFrame) tulajdonságához való hozzárendelése és a prezentáció mentése alkalmazza a tükrözési transzformációkat és elmenti azokat a kimeneti fájlba.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek első diája egyetlen, alapértelmezett tükrözési beállításokkal rendelkező alakzatot tartalmaz, ahogy az alább látható.

![The shape to be flipped](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri az alakzat aktuális flip tulajdonságait, és vízszintesen illetve függőlegesen is tükrözi azt.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Az alakzat vízszintes tükrözés tulajdonságának lekérdezése.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Az alakzat függőleges tükrözés tulajdonságának lekérdezése.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Vízszintesen tükröz.
    $flipV = NullableBool::True; // Vízszintesen tükröz.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The flipped shape](flipped_shape.png)

## **GYIK**

**Kombinálhatok-e alakzatokat (unió/kereszteződés/kivonás) egy dián, mint egy asztali szerkesztőben?**

Nincs beépített Boolean művelet API. A kívánt körvonalat saját maga építheti meg – például a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/) segítségével kiszámíthatja az eredményes geometriát, és létrehozhat egy új alakzatot ezzel a körvonallal, opcionálisan eltávolítva az eredetieket.

**Hogyan szabályozhatom a rétegsorrendet (z-sorrendet), hogy egy alakzat mindig „felül” maradjon?**

Módosítsa a beszúrási/áthelyezési sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getShapes) gyűjteményében. A kiszámítható eredmény érdekében a z-sorrendet a többi dia módosítása után állítsa be véglegesnek.

**„Zárolhat”‑e egy alakzatot, hogy a felhasználók ne szerkesszék PowerPointban?**

Igen. Állítson be alakzatszintű védelmi jelzőket (például kiválasztás, mozgatás, átméretezés, szövegszerkesztés zárolása). Szükség esetén korlátozza a mestert vagy az elrendezést. Vegye figyelembe, hogy ez UI‑szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, például [csak‑olvasásra vonatkozó javaslatok vagy jelszavak](/slides/hu/php-java/password-protected-presentation/).