---
title: Diagrammachse
type: docs
url: /de/php-java/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, Java, Diagrammacht manipulieren, Diagrammdaten"
description: "Wie man die Diagrammachse in PowerPoint bearbeitet"
---

## **Ermitteln der Maximalwerte der vertikalen Achse in Diagrammen**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die minimalen und maximalen Werte auf einer vertikalen Achse zu ermitteln. Befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Holen Sie den tatsächlichen Maximalwert auf der Achse.
1. Holen Sie den tatsächlichen Minimalwert auf der Achse.
1. Holen Sie die tatsächliche Haupteinheit der Achse.
1. Holen Sie die tatsächliche Nebeneinheit der Achse.
1. Holen Sie den tatsächlichen Maßstab der Haupteinheit der Achse.
1. Holen Sie den tatsächlichen Maßstab der Nebeneinheit der Achse.

Dieser Beispielcode - eine Implementierung der oben genannten Schritte - zeigt Ihnen, wie Sie die erforderlichen Werte erhalten:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Speichert die Präsentation
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Daten zwischen Achsen swapen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen den Achsen schnell zu tauschen - die auf der vertikalen Achse (y-Achse) dargestellten Daten werden zur horizontalen Achse (x-Achse) und umgekehrt verschoben.

Dieser PHP-Code zeigt Ihnen, wie Sie die Datenwechselaufgabe zwischen den Achsen in einem Diagramm ausführen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Wechselt Zeilen und Spalten
    $chart->getChartData()->switchRowColumn();
    # Speichert die Präsentation
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Deaktivieren der vertikalen Achse für Liniendiagramme**

Dieser PHP-Code zeigt Ihnen, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

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

## **Deaktivieren der horizontalen Achse für Liniendiagramme**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

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

## **Ändern der Kategoriedachse**

Mit der **CategoryAxisType** Eigenschaft können Sie Ihren bevorzugten Typ der Kategoriedachse (**Datum** oder **Text**) festlegen. Dieser Code demonstriert den Vorgang:

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

## **Festlegen des Datumsformats für den Wert der Kategoriedachse**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, das Datumsformat für einen Wert der Kategoriedachse festzulegen. Der Vorgang wird in diesem PHP-Code demonstriert:

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

## **Festlegen des Drehwinkels für den Titel der Diagrammachse**
Aspose.Slides für PHP über Java erlaubt es Ihnen, den Drehwinkel für den Titel einer Diagrammachse festzulegen. Dieser PHP-Code demonstriert den Vorgang:

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

## **Festlegen der Position der Achse in einer Kategorie- oder Wertachse**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Position der Achse in einer Kategorie- oder Wertachse festzulegen. Dieser PHP-Code zeigt, wie Sie die Aufgabe ausführen:

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

## **Aktivieren des Anzeigewertetiketts auf der Wertachse des Diagramms**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass es ein Einheitslabel auf seiner Wertachse anzeigt. Dieser PHP-Code demonstriert den Vorgang:

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