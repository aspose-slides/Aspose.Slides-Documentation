---
title: Optimieren von Diagrammberechnungen für Präsentationen in PHP
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/php-java/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- tatsächlicher Wert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für PHP via Java für PPT und PPTX, mit praktischen Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides für PHP via Java stellt eine einfache API zum Abrufen dieser Eigenschaften bereit. Methoden der [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) Klasse liefern Informationen über die tatsächliche Position des Achsendiagrammelements ([getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)). Es ist erforderlich, vorher die Methode [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.
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


## **Tatsächliche Position von übergeordneten Diagrammelementen berechnen**
Aspose.Slides für PHP via Java stellt eine einfache API zum Abrufen dieser Eigenschaften bereit. Methoden der `ActualLayout`‑Klasse liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Es ist erforderlich, vorher die Methode [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.
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


## **Diagrammelemente ausblenden**
Dieses Thema unterstützt Sie dabei zu verstehen, wie Informationen im Diagramm ausgeblendet werden können. Mit Aspose.Slides für PHP via Java können Sie **Titel, vertikale Achse, horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das folgende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Diagrammtitel ausblenden
    $chart->setTitle(false);
    # /Ausblenden der Werteachse
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Sichtbarkeit der Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Legende ausblenden
    $chart->setLegend(false);
    # Hauptgitterlinien ausblenden
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Festlegen der Linienfarbe der Serie
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

**Funktionieren externe Excel-Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad zur [externen Arbeitsmappe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlines](/slides/de/php-java/trend-line/) (linear, exponentiell und andere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Serien‑Daten neu berechnet, sodass Sie eigene Berechnungen nicht implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.