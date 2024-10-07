---
title: Diagramm Berechnungen
type: docs
weight: 50
url: /php-java/chart-calculations/
---

## **Berechnung der tatsächlichen Werte von Diagrammelementen**
Aspose.Slides für PHP über Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften des [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) Interfaces liefern Informationen über die tatsächliche Position des Achsendiagrammelements ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). Es ist notwendig, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.

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

## **Berechnung der tatsächlichen Position der übergeordneten Diagrammelemente**
Aspose.Slides für PHP über Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften des [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) Interfaces liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). Es ist notwendig, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.

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

## **Informationen aus dem Diagramm ausblenden**
Dieses Thema hilft Ihnen, zu verstehen, wie Sie Informationen aus dem Diagramm ausblenden können. Mit Aspose.Slides für PHP über Java können Sie **Titel, vertikale Achse, horizontale Achse** und **Gitternetzlinien** aus dem Diagramm ausblenden. Das folgende Codebeispiel zeigt, wie Sie diese Eigenschaften verwenden können.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Diagrammtitel ausblenden
    $chart->setTitle(false);
    # /Werteachse ausblenden
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Sichtbarkeit der Kategorienenachse
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Legende ausblenden
    $chart->setLegend(false);
    # Hauptgitternetzlinien ausblenden
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Linienfarbe der Serie festlegen
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