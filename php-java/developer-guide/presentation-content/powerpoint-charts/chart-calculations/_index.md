---
title: Chart Calculations
type: docs
weight: 50
url: /php-java/chart-calculations/
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for PHP via Java provides a simple API for getting these properties. Properties of [IAxis](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis) interface provide information about actual position of axis chart element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/com.aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType->Area, 100, 100, 500, 350);
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
Aspose.Slides for PHP via Java provides a simple API for getting these properties. Properties of [IActualLayout](https://reference.aspose.com/slides/php-java/com.aspose.slides/IActualLayout) interface provide information about actual position of parent chart element ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/com.aspose.slides/IActualLayout#getActualHeight--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/com.aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType->ClusteredColumn, 100, 100, 500, 350);
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

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for PHP via Java you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType->LineWithMarkers, 140, 118, 320, 370);
    // Hiding chart Title
    $chart->setTitle(false);
    // /Hiding Values axis
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    // Category Axis visibility
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    // Hiding Legend
    $chart->setLegend(false);
    // Hiding MajorGridLines
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType->NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType->Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    // Setting series line color
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType->Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```
