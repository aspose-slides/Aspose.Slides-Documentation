---
title: Callouts in Präsentationsdiagrammen mit PHP verwalten
linktitle: Callout
type: docs
url: /de/php-java/callout/
keywords:
- Diagramm-Callout
- Callout verwenden
- Datenbeschriftung
- Beschriftungsformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und formatieren Sie Callouts in Aspose.Slides für PHP via Java mit prägnanten Codebeispielen, kompatibel mit PPT und PPTX, um Präsentations‑Workflows zu automatisieren."
---

## **Verwendung von Callouts**
Neue Methoden [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) und [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) wurden der Klasse [DataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat) hinzugefügt. Diese Methoden bestimmen, ob das Datenbeschriftungselement des angegebenen Diagramms als Daten‑Callout oder als Datenbeschriftung angezeigt wird.
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


## **Ein Callout für ein Doughnut‑Diagramm festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen der Callout‑Form der Serien‑Datenbeschriftung für ein Doughnut‑Diagramm. Nachfolgend ein Beispiel.
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


## **FAQ**

**Werden Callouts beim Konvertieren einer Präsentation in PDF, HTML5, SVG oder Bilder erhalten?**

Ja. Callouts sind Teil der Diagrammdarstellung, sodass sie beim Export in [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/de/php-java/export-to-html5/), [SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/) oder [Rasterbilder](/slides/de/php-java/convert-powerpoint-to-png/) zusammen mit der Folienformatierung erhalten bleiben.

**Funktionieren benutzerdefinierte Schriftarten in Callouts, und kann ihr Aussehen beim Export beibehalten werden?**

Ja. Aspose.Slides unterstützt das [Einbetten von Schriften](/slides/de/php-java/embedded-font/) in die Präsentation und steuert das Einbetten von Schriften während Exports wie [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), sodass die Callouts in unterschiedlichen Systemen gleich aussehen.