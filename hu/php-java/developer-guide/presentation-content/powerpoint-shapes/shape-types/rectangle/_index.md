---
title: Téglalapok hozzáadása bemutatókhoz PHP-ben
linktitle: Téglalap
type: docs
weight: 80
url: /hu/php-java/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Emelje PowerPoint bemutatóit téglalapok hozzáadásával az Aspose.Slides for PHP via Java segítségével — egyszerűen tervezzen és módosítson alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk hozzá téglalap alakzatokat a PowerPoint diákhoz az Aspose.Slides használatával. Lefedi egy egyszerű téglalap létrehozását, egy formázott téglalap létrehozását, és a módosított bemutató PPTX fájlként történő mentését.

Meg fogja látni, hogyan alkalmazhat alapvető téglalap formázást, például egyszínű kitöltést, vonalszínt és vonalszélességet. Emellett a cikk GYIK-ja kapcsolódó téglalap feladatokra mutat, többek között lekerekített sarkokra, képkitöltésekre, vizuális hatásokra, hiperhivatkozásokra, alakzatforma zárolásokra, exportálási lehetőségekre és hatékony tulajdonságokra.

## **Téglalap hozzáadása egy diára**
Egy egyszerű téglalap hozzáadásához a bemutató kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) típusú Rectangle alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alább bemutatott példában egy egyszerű téglalapot adtunk hozzá a bemutató első diájához.

```php
  # Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape hozzáadása ellipszis típusban
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Írja a PPTX fájlt a lemezre
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formázott téglalap hozzáadása egy diára**
Formázott téglalap hozzáadásához egy diára, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) típusú Rectangle alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Állítsa a téglalap [Fill Type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FillType) értékét Solid-ra.
- Állítsa be a téglalap színét a [ColorFormat::setColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorformat/#setColor) metódussal, amely a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) objektumon keresztül, a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumhoz kapcsolódik.
- Állítsa be a téglalap vonalainak színét.
- Állítsa be a téglalap vonalainak szélességét.
- Írja ki a módosított bemutatót PPTX fájlként.

A fenti lépések az alább bemutatott példában vannak megvalósítva.

```php
  # Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape hozzáadása ellipszis típusban
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Alkalmazzon formázást az ellipszis alakzatra
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Alkalmazzon formázást az ellipszis vonalára
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Írja a PPTX fájlt a lemezre
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hogyan adhatok hozzá egy lekerekített sarkú téglalapot?**

Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/) típust, és állítsa be a sarkok sugárát az alakzat tulajdonságaiban; a lekerekítést egyenként a sarkoknál is alkalmazhatja geometriai beállításokkal.

**Hogyan tölthetem ki a téglalapot egy kép (textúra) segítségével?**

Válassza a kép [fill type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) típust, adja meg a kép forrását, és állítsa be a [stretching/tiling modes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillmode/) módokat.

**Lehet-e egy téglalapnak árnyéka és ragyogása?**

Igen. Az [Outer/inner shadow, glow, and soft edges](/slides/hu/php-java/shape-effect/) elérhetők állítható paraméterekkel.

**Átalakíthatom-e a téglalapot gombbal és hiperhivatkozással?**

Igen. Hozzárendelhet [Assign a hyperlink](/slides/hu/php-java/manage-hyperlinks/) a forma kattintásához (ugrás egy diához, fájlhoz, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosításoktól?**

Használjon alakzatzárolásokat: megtilthatja a mozgatást, átméretezést, kijelölést vagy a szövegszerkesztést a elrendezés megőrzéséhez.

**Átalakíthatom-e a téglalapot raszterképpé vagy SVG‑vé?**

Igen. A [render the shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) metódussal leképezheti az alakzatot egy képbe megadott mérettel/skálával, vagy [export it as SVG](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) módon vektoros felhasználásra.

**Hogyan szerezhetem meg gyorsan egy téglalap tényleges (hatékony) tulajdonságait a téma és az öröklődés figyelembe vételével?**

Használja az alakzat [effective properties](/slides/hu/php-java/shape-effective-properties/) funkcióját: az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, az elrendezést és a helyi beállításokat, ezáltal egyszerűsítve a formázás elemzését.