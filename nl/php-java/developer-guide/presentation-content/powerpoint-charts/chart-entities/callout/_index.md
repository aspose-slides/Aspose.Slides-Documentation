---
title: Beheer callouts in presentatiediagrammen met PHP
linktitle: Callout
type: docs
url: /nl/php-java/callout/
keywords:
- diagram callout
- callout gebruiken
- dataticket
- labelopmaak
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en stijl callouts in Aspose.Slides voor PHP via Java met beknopte code‑voorbeelden, compatibel met PPT en PPTX om presentatiewerkstromen te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe je callouts voor diagramdatatiekens kunt gebruiken in Aspose.Slides. Het laat zien hoe je de `setShowLabelAsDataCallout`‑methode gebruikt om etiketten als callouts weer te geven, hoe je callout‑gerelateerde etiketinstellingen voor een doughnut‑diagram configureert, en vermeldt dat callouts en hun uiterlijk behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en rasterafbeeldingsformaten.

## **Gebruik van callouts**
Nieuwe methoden [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) en [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) zijn toegevoegd aan de [DataLabelFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat)‑klasse. Deze methoden bepalen of het opgegeven diagramdataticket wordt weergegeven als data‑callout of als dataticket.

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

## **Callout instellen voor een doughnut‑diagram**
Aspose.Slides for PHP via Java biedt ondersteuning voor het instellen van de serie‑dataticket‑callout‑vorm voor een doughnut‑diagram. Hieronder staat een voorbeeld gegeven.

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

## **Veelgestelde vragen**

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de diagramrendering, dus wanneer je exporteert naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/php-java/export-to-html5/), [SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/) of [rasterafbeeldingen](/slides/nl/php-java/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun uiterlijk behouden blijven bij export?**

Ja. Aspose.Slides ondersteunt [lettertypen insluiten](/slides/nl/php-java/embedded-font/) in de presentatie en regelt het insluiten van lettertypen tijdens exporten zoals [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), zodat de callouts er op verschillende systemen hetzelfde uitzien.