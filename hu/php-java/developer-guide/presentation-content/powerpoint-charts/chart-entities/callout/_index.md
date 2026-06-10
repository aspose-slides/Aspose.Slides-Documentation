---
title: Feliratvonalak kezelése bemutató diagramokban PHP használatával
linktitle: Feliratvonal
type: docs
url: /hu/php-java/callout/
keywords:
- diagram feliratvonal
- feliratvonal használata
- adatcímke
- címkeformátum
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Hozzon létre és formázzon feliratvonalakat az Aspose.Slides for PHP via Java-ban rövid kódpéldákkal, PPT és PPTX kompatibilitással a bemutató munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram adatcímkéinek feliratvonalaival az Aspose.Slides-ban. Ismerteti, hogyan használható a `setShowLabelAsDataCallout` metódus a címkék feliratvonalakként való megjelenítéséhez, hogyan állíthatók be a feliratvonalakkal kapcsolatos címke beállítások egy gyűrűdiagram esetén, valamint megjegyzi, hogy a feliratvonalak és megjelenésük megmarad, amikor a prezentációkat PDF, HTML5, SVG és raszteres képformátumokba exportálják.

## **Feliratvonalak használata**

Új [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) és [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) metódusok lettek hozzáadva a [DataLabelFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabelformat) osztályhoz. Ezek a metódusok meghatározzák, hogy az adott diagram adatcímkéje adatfeliratvonalként vagy adatcímkeként jelenjen meg.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Feliratvonal beállítása gyűrűdiagramhoz**

Az Aspose.Slides for PHP via Java támogatja a sor adatcímkéjének feliratvonal alakjának beállítását egy gyűrűdiagramhoz. Az alábbi példa van bemutatva.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**A feliratvonalak megmaradnak a prezentáció PDF, HTML5, SVG vagy képek formátumba konvertálása során?**

Igen. A feliratvonalak a diagram renderelésének részét képezik, ezért amikor exportál a [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/php-java/export-to-html5/), [SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/php-java/convert-powerpoint-to-png/) formátumba, megmaradnak a dia formázásával együtt.

**A saját betűtípusok működnek a feliratvonalakban, és megőrizhető a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűk beágyazását](/slides/hu/php-java/embedded-font/) a prezentációba, és kezeli a betűk beágyazását az exportok során, például [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), biztosítva, hogy a feliratvonalak minden rendszerben ugyanúgy nézzenek ki.