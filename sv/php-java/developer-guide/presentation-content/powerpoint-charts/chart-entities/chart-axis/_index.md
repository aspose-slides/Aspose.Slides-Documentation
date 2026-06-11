---
title: Anpassa diagramaxlar i presentationer med PHP
linktitle: Diagramaxel
type: docs
url: /sv/php-java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelns egenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axelrubrik
- axelposition
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för PHP via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du hämtar faktiska axi värden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxelns typ, anger datumformatet för kategoriaxelvärden, roterar en axelrubrik, ställer in axelns position och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Aspose.Slides för PHP via Java låter dig hämta de minsta och största värdena på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximala värdet på axeln.
1. Hämta det faktiska minimala värdet på axeln.
1. Hämta den faktiska huvudvärdeenheten för axeln.
1. Hämta den faktiska underenheten för axeln.
1. Hämta den faktiska skalan för huvudvärdeenheten på axeln.
1. Hämta den faktiska skalan för underenheten på axeln.

Den här exempel koden — en implementation av stegen ovan — visar hur du hämtar de erforderliga värdena :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Sparar presentationen
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Byt data mellan axlar**

Aspose.Slides låter dig snabbt byta data mellan axlar — data som visas på den vertikala axeln (y-axeln) flyttas till den horisontella axeln (x-axeln) och vice versa.

Den här PHP-koden visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Byter rader och kolumner
    $chart->getChartData()->switchRowColumn();
    # Sparar presentationen
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Inaktivera den vertikala axeln för linjediagram**

Den här PHP-koden visar hur du döljer den vertikala axeln för ett linjediagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Inaktivera den horisontella axeln för linjediagram**

Den här koden visar hur du döljer den horisontella axeln för ett linjediagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra kategoriaxeln**

Med egenskapen **CategoryAxisType** kan du ange önskad kategoriaxeltyp (**date** eller **text**). Den här koden demonstrerar operationen:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ange datumformatet för kategoriaxelvärden**

Aspose.Slides för PHP via Java låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i denna PHP-kod:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Ange rotationsvinkeln för en diagramaxelrubrik**

Aspose.Slides för PHP via Java låter dig ange rotationsvinkeln för en diagramaxelrubrik. Denna PHP-kod demonstrerar operationen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange axelposition på en kategori- eller värdeaxel**

Aspose.Slides för PHP via Java låter dig ställa in axelns position i en kategori- eller värdeaxel. Denna PHP-kod visar hur du utför uppgiften:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aktivera visning av enhetsetikett på diagrammets värdeaxel**

Aspose.Slides för PHP via Java låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna PHP-kod demonstrerar operationen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hur ställer jag in värdet där en axel korsar den andra (axelkorsning)?**

Axlar erbjuder en [korsningsinställning](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/setcrosstype/): du kan välja att korsas vid noll, vid den maximala kategori-/värdet, eller vid ett specifikt numeriskt värde. Detta är användbart för att förflytta X-axeln upp eller ner eller för att framhäva en grundlinje.

**Hur kan jag placera tick-etiketterna i förhållande till axeln (intill, ute, inne)?**

Ange [etikettpositionen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/setmajortickmark/) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.