---
title: Vonalalakzatok hozzáadása prezentációkhoz PHP-ben
linktitle: Vonal
type: docs
weight: 50
url: /hu/php-java/line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal konfigurálása
- vonal testreszabása
- szaggatott stílus
- nyílfej
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet manipulálni a vonalformázást PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével. Fedezze fel a tulajdonságokat, módszereket és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi vonal alakzatok hozzáadását a PowerPoint diákhoz programozott módon. Ez a cikk bemutatja, hogyan hozhatunk létre egy egyszerű vonalat, és hogyan testreszabhatjuk a vonalat úgy, hogy nyílnak nézzen ki.

Megtanulja, hogyan adjon vonal alakzatot egy diára, hogyan állítsa be a megjelenését, és hogyan mentse el a módosított prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, például stílus, szélesség, vonalperem minta, nyílfej beállítások és kitöltőszín.

## **Egyszerű vonal létrehozása**

Egy egyszerű, sima vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia referencia­ját az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon érhető el.
- Írja a módosított prezentációt PPTX fájlként.

Az alábbi példában a prezentáció első diájához adtunk hozzá egy vonalat.

```php
  # Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Adjon hozzá egy Line típusú AutoShape‑t
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Írja a PPTX‑et a lemezre
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nyíl alakú vonal létrehozása**

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy a vonal egyes tulajdonságait úgy konfigurálják, hogy vonzóbb legyen. Próbáljuk meg beállítani néhány tulajdonságot, hogy a vonal nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia referencia­ját az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon érhető el.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineStyle) értékét az Aspose.Slides for PHP via Java által kínált egyik stílusra.
- Állítsa be a vonal szélességét.
- Állítsa be a [Dash Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineDashStyle) értékét az Aspose.Slides for PHP via Java által kínált egyik stílusra.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadLength) értékét.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadLength) értékét.
- Írja a módosított prezentációt PPTX fájlként.

```php
  # Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Adjon hozzá egy Line típusú AutoShape‑t
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Alkalmazzon némi formázást a vonalon
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Írja a PPTX‑et a lemezre
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Átalakíthatom a szabályos vonalat csatlakozóvá, hogy „ráilleszkedjen” a formákhoz?**

Nem. Egy szabályos vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) a [Line](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/) típusból) nem válik automatikusan csatlakozóvá. Ahhoz, hogy ráilleszkedjen a formákra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/) típust és a [kapcsolódó API‑kat](/slides/hu/php-java/connector/) a csatlakozásokhoz.

**Mit tehetek, ha egy vonal tulajdonságait a téma örökíti, és nehéz meghatározni a végleges értékeket?**

Olvassa el a [hatékony tulajdonságokat](/slides/hu/php-java/shape-effective-properties/) a `LineFormatEffectiveData`/`LineFillFormatEffectiveData` segítségével – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objektumokat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/getautoshapelock/) biztosítanak, amelyek lehetővé teszik a szerkesztési műveletek letiltását.