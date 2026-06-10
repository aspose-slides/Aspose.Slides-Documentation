---
title: Kördiagramok testreszabása prezentációkban PHP-val
linktitle: Kördiagram
type: docs
url: /hu/php-java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet színe
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhasson kördiagramokat az Aspose.Slides for PHP via Java segítségével, amelyek exportálhatók PowerPointba, és másodpercek alatt fokozzák az adatmesélését."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ban. Bemutatja, hogyan konfigurálhatók a másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szeletszínezés egy szabványos kördiagramon.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, például diagram hozzáadására egy diára, sorozat- és címkebeállítások módosítására, az alapértelmezett diagramadatok helyettesítésére egyéni kategóriákkal és értékekkel, valamint a frissített bemutató mentésére.

## **Másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz**
Aspose.Slides for PHP via Java most támogatja a másodlagos diagrambeállításokat a Pie of Pie vagy Bar of Pie diagramokhoz. Ebben a témában megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. A tulajdonságok megadásához tegye a következőt:

1. Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályobjektumot.
1. Adjon hozzá diagramot a diára.
1. Adja meg a diagram másodlagos diagrambeállításait.
1. Írja a bemutatót a lemezre.

Az alább bemutatott példában különböző tulajdonságokat állítottunk be a Pie of Pie diagramon.

```php
  # Hozzon létre egy Presentation osztálypéldányt
  $pres = new Presentation();
  try {
    # Adjon hozzá diagramot a diára
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Állítson be különböző tulajdonságokat
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Mentse a prezentációt lemezre
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Automatikus kördiagram-szelet színek beállítása**
Az Aspose.Slides for PHP via Java egyszerű API-t biztosít az automatikus kördiagram-szelet színek beállításához. A mintakód alkalmazza a fent említett beállításokat.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztály példányt.
1. Érje el az első diát.
1. Adjon hozzá diagramot az alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa be az első sorozatot, hogy értékeket mutasson.
1. Állítsa be a diagram adatlap indexét.
1. A diagram adatlapjának lekérése.
1. Törölje az alapértelmezett generált sorozatokat és kategóriákat.
1. Adjon hozzá új kategóriákat.
1. Adjon hozzá új sorozatot.

Írja a módosított bemutatót egy PPTX fájlba.

```php
  # Hozzon létre egy Presentation osztálypéldányt
  $pres = new Presentation();
  try {
    # Adjon hozzá diagramot alapértelmezett adatokkal
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Diagram címének beállítása
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Állítsa be az első sorozatot, hogy értékeket mutasson
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # A diagram adatlap indexének beállítása
    $defaultWorksheetIndex = 0;
    # A diagram adatlapjának lekérése
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Alapértelmezett generált sorozatok és kategóriák törlése
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Új kategóriák hozzáadása
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Új sorozat hozzáadása
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Most a sorozat adatait töltjük fel
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Támogatottak a 'Pie of Pie' és a 'Bar of Pie' változatok?**

Igen, a könyvtár támogat egy másodlagos diagramot a kördiagramokhoz, beleértve a 'Pie of Pie' és a 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, exportálhatja a diagramot önmagát képként (például PNG) a teljes bemutató nélkül.