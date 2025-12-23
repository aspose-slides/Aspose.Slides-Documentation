---
title: Diagrammachsen in Präsentationen mit PHP anpassen
linktitle: Diagrammachse
type: docs
url: /de/php-java/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für PHP via Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Maximale Werte auf der vertikalen Achse von Diagrammen abrufen**
Aspose.Slides für PHP via Java ermöglicht das Abrufen der Mindest‑ und Höchstwerte einer vertikalen Achse. Befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Ermitteln Sie den tatsächlichen Maximalwert der Achse.  
5. Ermitteln Sie den tatsächlichen Minimalwert der Achse.  
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.  
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.  
8. Ermitteln Sie die tatsächliche Hauptskalierung der Achse.  
9. Ermitteln Sie die tatsächliche Nebenskala der Achse.  

Dieser Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie die erforderlichen Werte abrufen:
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


## **Daten zwischen Achsen austauschen**
Aspose.Slides ermöglicht es, die Daten zwischen den Achsen schnell zu vertauschen – die Daten der vertikalen Achse (y‑Achse) werden zur horizontalen Achse (x‑Achse) verschoben und umgekehrt.  

Dieser PHP‑Code zeigt, wie Sie den Datentausch zwischen Achsen in einem Diagramm durchführen:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Tauscht Zeilen und Spalten
    $chart->getChartData()->switchRowColumn();
    # Speichert die Präsentation
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Vertikale Achse bei Liniendiagrammen deaktivieren**
Dieser PHP‑Code zeigt, wie Sie die vertikale Achse eines Liniendiagramms ausblenden:
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


## **Horizontale Achse bei Liniendiagrammen deaktivieren**
Dieser Code zeigt, wie Sie die horizontale Achse eines Liniendiagramms ausblenden:
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


## **Kategorieachse ändern**
Mit der Eigenschaft **CategoryAxisType** können Sie den gewünschten Kategorieachsentyp (**date** oder **text**) festlegen. Dieser Code demonstriert die Vorgehensweise:
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


## **Datumsformat für Werte der Kategorieachse festlegen**
Aspose.Slides für PHP via Java ermöglicht das Festlegen des Datumsformats für einen Wert der Kategorieachse. Der Vorgang wird in diesem PHP‑Code demonstriert:
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


## **Drehwinkel für einen Diagrammachsentitel festlegen**
Aspose.Slides für PHP via Java ermöglicht das Festlegen des Drehwinkels für einen Diagrammachsentitel. Dieser PHP‑Code demonstriert den Vorgang:
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


## **Position der Achse auf einer Kategorie‑ oder Wertachse festlegen**
Aspose.Slides für PHP via Java ermöglicht das Festlegen der Achsenposition in einer Kategorie‑ oder Wertachse. Dieser PHP‑Code zeigt, wie die Aufgabe durchgeführt wird:
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


## **Anzeigeeinheits‑Label auf der Diagrammwertachse aktivieren**
Aspose.Slides für PHP via Java ermöglicht die Konfiguration eines Diagramms, ein Einheitsetikett auf seiner Wertachse anzuzeigen. Dieser PHP‑Code demonstriert den Vorgang:
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
**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**  
Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)-Option: Sie können wählen, bei null, beim maximalen Kategorie‑/Wert oder bei einem bestimmten numerischen Wert zu kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie zu betonen.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (nebeneinander, außerhalb, innen)?**  
Setzen Sie die [label position](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) auf „cross“, „outside“ oder „inside“. Dies beeinflusst die Lesbarkeit und spart Platz, insbesondere bei kleinen Diagrammen.