---
title: Vonalalakzatok hozzáadása prezentációkhoz PHP-ben
linktitle: Vonal
type: docs
weight: 50
url: /hu/php-java/Line/
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
description: "Ismerje meg a vonalformázás manipulálását PowerPoint-prezentációkban az Aspose.Slides for PHP via Java segítségével. Fedezze fel a tulajdonságokat, módszereket és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi vonal alakzatok hozzáadását PowerPoint-diákhoz programozott módon. Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű vonalat, és hogyan testreszabhatunk egy vonalat, hogy nyílnak látszódjon.

Megtanulja, hogyan adjon vonal alakzatot egy diához, állítsa be a vizuális megjelenését, és mentse a frissített prezentációt. A példák gyakorlati vonal formázási beállításokra összpontosítanak, mint például a stílus, szélesség, szaggatott minta, nyílfej beállítások és kitöltőszín.

## **Egyszerű vonal létrehozása**

A prezentáció egy kiválasztott diájához egyszerű, sima vonal hozzáadásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását az Indexe használatával.
- Adjon hozzá egy AutoShape-et Vonal típusúként a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Írja a módosított prezentációt PPTX fájlként.

Az alábbi példában egy vonalat adtunk hozzá a prezentáció első diájához.

```php
  # Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
    # Szerezze meg az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Adjon hozzá egy AutoShape-et vonal típusúként
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Írja a PPTX-et a lemezre
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nyíl alakú vonal létrehozása**

Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy a vonal néhány tulajdonságát konfigurálják, így vonzóbbá téve azt. Próbáljunk meg néhány tulajdonságot beállítani, hogy a vonal nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását az Indexe használatával.
- Adjon hozzá egy AutoShape-et Vonal típusúként a [addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineStyle) egyik elérhető stílusra, amelyet az Aspose.Slides for PHP via Java kínál.
- Állítsa be a vonal szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineDashStyle) egyik elérhető stílusra, amelyet az Aspose.Slides for PHP via Java kínál.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadLength) értékét.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LineArrowheadLength) értékét.
- Írja a módosított prezentációt PPTX fájlként.

```php
  # Példányosítja a PresentationEx osztályt, ami a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape-et vonal típusúként
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Alkalmaz némi formázást a vonalon
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Kiírja a PPTX-et a lemezre
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Átalakíthatom-e a normál vonalat kapcsolóvá, hogy „rákapcsolódjon” az alakzatokra?**

Nem. Egy normál vonal (az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) típusú [Line](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/)) nem válik automatikusan kapcsolóvá. Ahhoz, hogy rákapcsolódjon az alakzatokra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/) típust és a [corresponding APIs](/slides/hu/php-java/connector/) kapcsolatépítéshez.

**Mit tegyek, ha egy vonal tulajdonságait a téma örökli, és nehéz meghatározni a végleges értékeket?**

Olvassa el a [Read the effective properties](/slides/hu/php-java/shape-effective-properties/) a `LineFormatEffectiveData`/`LineFillFormatEffectiveData` segítségével – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Lezárhatom-e a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/getautoshapelock/) biztosítanak, amelyekkel megtilthatja a szerkesztési műveleteket.