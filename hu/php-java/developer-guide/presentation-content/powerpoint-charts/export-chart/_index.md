---
title: Prezentációs diagramok exportálása PHP-ben
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/php-java/export-chart/
keywords:
- diagram
- diagram képpé
- diagram képként
- diagram kép kinyerése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for PHP via Java segítségével, PPT és PPTX formátumok támogatásával, és egyszerűsítheti a jelentéstételt bármilyen munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan lehet képet kapni egy diagramról, és elmenteni azt, ami hasznos, ha a diagram vizuális elemeit a PowerPoint bemutatón kívül szeretné újra felhasználni.

## **Diagramkép lekérése**
Az Aspose.Slides for PHP via Java támogatja egy adott diagram képének kinyerését. Az alábbi példakód van megadva.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Exportálhatok egy diagramot vektorként (SVG) a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalma SVG-ként menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) használatával.

**Hogyan állíthatom be az exportált diagram pontos méretét pixelben?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy a méretezés megadását – a könyvtár támogatja az objektumok renderelését megadott méretekkel/méretezéssel.

**Mit tegyek, ha a címkék és a jelmagyarázat betűtípusai helytelenül jelennek meg exportálás után?**

[Töltse be a szükséges betűtípusokat](/slides/hu/php-java/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Az exportálás tiszteletben tartja a PowerPoint témát, stílusokat és effektusokat?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túl elérhető renderelési/exportálási lehetőségek?**

Tekintse meg az [API](https://reference.aspose.com/slides/hu/php-java/aspose.slides/)/[dokumentációt](/slides/hu/php-java/convert-powerpoint/) a kimeneti célokhoz ([PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/php-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/php-java/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállításokat.