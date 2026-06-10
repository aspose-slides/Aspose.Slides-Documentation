---
title: Ellipszisek hozzáadása prezentációkhoz PHP-ben
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/php-java/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és manipulálhat ellipszis alakzatokat az Aspose.Slides for PHP via Java segítségével PPT és PPTX prezentációkban — kódrészletek is szerepelnek."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet ellipszis alakzatokat hozzáadni PowerPoint diákhoz az Aspose.Slides használatával. Lefedi egy egyszerű ellipszis létrehozását, egy formázott ellipszis létrehozását, és a módosított prezentáció mentését PPTX fájlként. Emellett érinti a kapcsolódó kérdéseket, például az ellipszis pozíciójával és méretével való munkát, a rétegezési sorrend vezérlését és az animációs hatások alkalmazását.

## **Ellipszis létrehozása**
A prezentáció kiválasztott diájához egy egyszerű ellipszis hozzáadásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
- Szerezze meg egy dia hivatkozását az Index használatával.  
- Adjon hozzá egy Ellipse típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) módszerrel, amelyet a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektum biztosít.  
- Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy ellipszist adtunk hozzá az első diára

```php
  # PPTX-et képviselő Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Ellipszis típusú AutoShape hozzáadása
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # A PPTX fájl írása a lemezre
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formázott ellipszis létrehozása**
Egy jobban formázott ellipszis hozzáadásához egy diára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
- Szerezze meg egy dia hivatkozását az Index használatával.  
- Adjon hozzá egy Ellipse típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) módszerrel, amelyet a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektum biztosít.  
- Állítsa be az ellipszis kitöltési típusát Szilárdra.  
- Állítsa be az ellipszis színét a `SolidFillColor::setColor` metódussal, amelyet a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) objektum biztosít a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumhoz kapcsolódóan.  
- Állítsa be az ellipszis vonalai színét.  
- Állítsa be az ellipszis vonalai vastagságát.  
- Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a prezentáció első diájához.

```php
  # PPTX-et képviselő Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Az első dia lekérése
    $sld = $pres->getSlides()->get_Item(0);
    # Ellipszis típusú AutoShape hozzáadása
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Néhány formázás alkalmazása az ellipszis alakzatra
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Néhány formázás alkalmazása az ellipszis vonalára
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # A PPTX fájl írása a lemezre
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a dia egységeihez képest?**

A koordinátákat és méreteket általában **pontban** adják meg. A kiszámítható eredmények érdekében alapozza számításait a dia méretére, és a szükséges millimétereket vagy hüvelykeket konvertálja pontokra, mielőtt értékeket adna meg.

**Hogyan helyezhetem el az ellipszist más objektumok fölé vagy alá (a rétegezési sorrend vezérlése)?**

A objektum rajzolási sorrendjét állítsa előre hozva vagy hátulra küldve. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot vagy felfedje az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyát?**

[Apply](/slides/hu/php-java/shape-animation/) belépő, hangsúly vagy kilépő hatásokat alkalmazza a shape elemre, és konfigurálja a trigger-eket és az időzítést, hogy meghatározza, mikor és hogyan játszódik le az animáció.