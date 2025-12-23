---
title: Diagrammberechnungen für Präsentationen in PHP optimieren
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/php-java/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- Tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- Tatsächlicher Wert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für PHP via Java für PPT und PPTX, inklusive praktischer Codebeispiele."
---

## **Berechnen tatsächlicher Werte von Diagrammelementen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften des [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis)-Interface liefern Informationen über die tatsächliche Position des Achsendiagrammelements ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). Es ist erforderlich, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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


## **Berechnen der tatsächlichen Position von übergeordneten Diagrammelementen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften des [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout)-Interface liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). Es ist erforderlich, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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
Dieses Thema hilft Ihnen zu verstehen, wie Informationen im Diagramm ausgeblendet werden können. Mit Aspose.Slides für PHP via Java können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das nachstehende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.
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

**Unterstützen externe Excel-Arbeitsmappen eine Datenquelle, und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann eine externe Arbeitsmappe referenzieren: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad der [die externe Arbeitsmappe angeben](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/php-java/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.