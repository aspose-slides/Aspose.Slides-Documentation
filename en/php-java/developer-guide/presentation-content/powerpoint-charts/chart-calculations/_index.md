---
title: Optimize Chart Calculations for Presentations in PHP
linktitle: Chart Calculations
type: docs
weight: 50
url: /php-java/chart-calculations/
keywords:
- chart calculations
- chart elements
- element position
- actual position
- child element
- parent element
- chart values
- actual value
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Understand chart calculations, data updates, and precision control in Aspose.Slides for PHP via Java for PPT and PPTX, with practical code examples."
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for PHP via Java provides a simple API for getting these properties. Methods of the [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) class provide information about actual position of axis chart element ([getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)). It is necessary to call method [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) previously to fill properties with actual values.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for PHP via Java provides a simple API for getting these properties.Methods of the `ActualLayout` class provide information about actual position of parent chart element (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). It is necessary to call method [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) previously to fill properties with actual values.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hide Chart Elements**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for PHP via Java you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Hiding chart Title
    $chart->setTitle(false);
    # /Hiding Values axis
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Category Axis visibility
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Hiding Legend
    $chart->setLegend(false);
    # Hiding MajorGridLines
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Setting series line color
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Yes. A chart can reference an external workbook: when you connect or refresh the external source, formulas and values are taken from that workbook, and the chart reflects the updates during open/edit operations. The API lets you [specify the external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) path and manage the linked data.

**Can I compute and display trendlines without implementing regression myself?**

Yes. [Trendlines](/slides/php-java/trend-line/) (linear, exponential, and others) are added and updated by Aspose.Slides; their parameters are recalculated from the series data automatically, so you don’t need to implement your own calculations.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Yes. Each chart can point to its own [external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), or you can create/replace an external workbook per chart independently of the others.
