---
title: Hantera diagramdataetiketter i presentationer med PHP
linktitle: Dataetikett
type: docs
url: /sv/php-java/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettdistans
- etikettplacering
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för PHP via Java för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter på ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De gör det möjligt för läsare att snabbt identifiera dataserier och de gör även diagram enklare att förstå.

## **Ställ in dataprecision i diagrammets dataetiketter**

Den här PHP-koden visar hur du ställer in dataprecisionen i en diagramdataetikett:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Visa procentsats som etiketter**
Aspose.Slides för PHP via Java låter dig ange procentsatsetiketter på visade diagram. Den här PHP-koden demonstrerar operationen:

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Sparar presentationen som innehåller diagrammet
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange procentsymbolen i diagrammets dataetiketter**
Den här PHP-koden visar hur du anger procentsymbolen för en diagramdataetikett:

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämtar en bildreferens via dess index
    $slide = $pres->getSlides()->get_Item(0);
    # Skapar diagrammet PercentsStackedColumn på en bild
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Ställer in NumberFormatLinkedToSource till false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets databladsark
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Lägger till en ny serie
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Ställer in fyllningsfärgen för serien
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Ställer in egenskaperna för etikettformatet
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Lägger till en ny serie
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Ställer in fyllningstyp och färg
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Skriver presentationen till disk
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange etikettdistans från en axel**
Den här PHP-koden visar hur du anger etikettdistansen från en kategoribel när du arbetar med ett diagram som plottas från axlar:

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämtar en bildreferens
    $sld = $pres->getSlides()->get_Item(0);
    # Skapar ett diagram på bilden
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Ställer in etikettdistansen från en axel
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Skriver presentationen till disk
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Justera etikettens placering**

När du skapar ett diagram som inte förlitar sig på någon axel, till exempel ett cirkeldiagram, kan diagrammets dataetiketter hamna för nära kanten. I sådana fall måste du justera etikettens placering så att ledlinjerna visas tydligt.

Den här PHP-koden visar hur du justerar etikettens placering i ett cirkeldiagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Vanliga frågor**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, ledlinjer och minskad teckenstorlek; vid behov, dölja vissa fält (till exempel kategorin) eller bara visa etiketter för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en enhetlig etikettstil vid export till PDF/bilder?**

Ange explicit teckensnitt (familj, storlek) och verifiera att teckensnittet är tillgängligt på renderingssidan för att undvika återgång.