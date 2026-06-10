---
title: Diagram adatjelzők kezelése előadásokban PHP használatával
linktitle: Adatjelző
type: docs
url: /hu/php-java/chart-data-marker/
keywords:
- diagram
- adatpont
- jelző
- jelző beállítások
- jelző méret
- kitöltés típusa
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diagram adatjelzőket az Aspose.Slides PHP verziójában, ezáltal növelve a prezentáció hatását PPT és PPTX formátumokban, világos kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram adatjelzőkkel dolgozni az Aspose.Slides-ban. Megmutatja, hogyan hozhatunk létre diagramot, hogyan érhetünk el egy sorozatot és annak adatpontjait, hogyan alkalmazhatunk képkitöltést a jelzőkre adatpont szinten, hogyan állíthatjuk be a jelző méretét, és hogyan menthetjük a frissített bemutatót. Továbbá megjegyzi, hogy a szabványos jelzőalakok a `MarkerStyleType` felsoroláson keresztül érhetők el, és a jelző megjelenése megmarad a diagramok raster formátumokra vagy SVG-re exportálásakor.

## **Diagram jelző beállításainak megadása**
Az egyes sorozatok adatpontjain a jelzők beállíthatók. A diagram jelző beállításához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályt.
- Az alapértelmezett diagram létrehozása.
- A kép beállítása.
- Az első diagram sorozat kivétele.
- Új adatpont hozzáadása.
- A bemutató írása lemezre.

Az alább megadott példában a diagram jelző beállításait adatpont szinten állítottuk be.

```php
  # Üres prezentáció létrehozása
  $pres = new Presentation();
  try {
    # Első dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Alapértelmezett diagram létrehozása
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Az alapértelmezett diagram adatlap indexének lekérése
    $defaultWorksheetIndex = 0;
    # Diagram adatlap lekérése
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo sorozat törlése
    $chart->getChartData()->getSeries()->clear();
    # Új sorozat hozzáadása
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # 1. kép betöltése
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # 2. kép betöltése
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Első diagram sorozat kivétele
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Új pont (1:3) hozzáadása ott.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # A diagram sorozat jelzőjének módosítása
    $series->getMarker()->setSize(15);
    # Prezentáció mentése diagrammal
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Milyen jelzőalakok érhetők el alapból?**

A szabványos alakok elérhetők (kör, négyzet, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markerstyletype/) osztály által van definiálva. Ha nem szabványos alakra van szüksége, használjon képkitöltéses jelzőt a egyéni megjelenés szimulálásához.

**Megmaradnak a jelzők a diagram képbe vagy SVG-be exportálásakor?**

Igen. A diagramok [raszteres formátumokba](/slides/hu/php-java/convert-powerpoint-to-png/) történő renderelésekor vagy a [alakzatok SVGként](/slides/hu/php-java/render-a-slide-as-an-svg-image/) történő mentésekor a jelzők megőrzik megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.