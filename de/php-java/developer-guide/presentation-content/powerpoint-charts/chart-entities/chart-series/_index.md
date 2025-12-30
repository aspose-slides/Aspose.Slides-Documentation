---
title: Diagrammdatenreihen in Präsentationen mit PHP verwalten
linktitle: Datenreihen
type: docs
url: /de/php-java/chart-series/
keywords:
- Diagrammreihen
- Reihenüberlappung
- Reihenfarbe
- Kategoriefarbe
- Reihenname
- Datenpunkt
- Reihenlücke
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenreihen in PHP für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

Eine Reihe ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammreihen-Überlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)‑Eigenschaft können Sie festlegen, wie stark Balken und Säulen in einem 2‑D‑Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Reihen der übergeordneten Reihen­gruppe: Sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die Lese‑/Schreib‑Eigenschaft `ParentSeriesGroup.Overlap`, um Ihren gewünschten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Fügen Sie ein gruppiertes Säulendiagramm zu einer Folie hinzu.  
1. Greifen Sie auf die erste Diagrammreihe zu.  
1. Greifen Sie auf `ParentSeriesGroup` der Diagrammreihe zu und setzen Sie Ihren gewünschten Überlappungswert für die Reihe.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser PHP‑Code zeigt, wie Sie die Überlappung für eine Diagrammreihe festlegen:
```php
  $pres = new Presentation();
  try {
    # Fügt Diagramm hinzu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Setzt die Reihenüberlappung
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Schreibt die Präsentationsdatei auf die Festplatte
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Reihenfarbe ändern**

Aspose.Slides for PHP via Java ermöglicht das Ändern der Farbe einer Reihe wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Reihe zu, deren Farbe Sie ändern möchten.  
1. Setzen Sie den gewünschten Fülltyp und die Füllfarbe.  
1. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code zeigt, wie Sie die Farbe einer Reihe ändern:
```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Kategorienfarbe der Reihe ändern**

Aspose.Slides for PHP via Java ermöglicht das Ändern der Farbe einer Kategorienreihe wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Kategorienreihe zu, deren Farbe Sie ändern möchten.  
1. Setzen Sie den gewünschten Fülltyp und die Füllfarbe.  
1. Speichern Sie die geänderte Präsentation.  

Dieser Code zeigt, wie Sie die Farbe einer Kategorienreihe ändern:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Reihenname ändern**

Standardmäßig ergeben sich die Legendennamen eines Diagramms aus den Zellen über jeder Spalte bzw. Zeile der Daten.

In unserem Beispiel (Beispielabbildung):

* Die Spalten heißen *Series 1, Series 2* und *Series 3*;  
* Die Zeilen heißen *Category 1, Category 2, Category 3* und *Category 4*.  

Aspose.Slides for PHP via Java ermöglicht das Aktualisieren oder Ändern eines Reihen­namens in den Diagrammdaten und in der Legende.

Dieser PHP‑Code zeigt, wie Sie den Namen einer Reihe in den Diagrammdaten `ChartDataWorkbook` ändern:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Dieser PHP‑Code zeigt, wie Sie den Namen einer Reihe in der Legende über `Series` ändern:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Füllfarbe der Diagrammreihe festlegen**

Aspose.Slides for PHP via Java ermöglicht das Festlegen der automatischen Füllfarbe für Diagrammreihen im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Holen Sie sich die Referenz einer Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im Beispiel unten verwenden wir `ChartType::ClusteredColumn`).  
1. Greifen Sie auf die Diagrammreihe zu und setzen Sie die Füllfarbe auf Automatic.  
1. Speichern Sie die Präsentation in einer PPTX‑Datei.  

Dieser PHP‑Code zeigt, wie Sie die automatische Füllfarbe für eine Diagrammreihe festlegen:
```php
  $pres = new Presentation();
  try {
    # Erstellt ein gruppiertes Säulendiagramm
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Setzt das Füllformat der Serie auf automatisch
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Schreibt die Präsentationsdatei auf die Festplatte
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Invertierte Füllfarbe für eine Diagrammreihe festlegen**

Aspose.Slides ermöglicht das Festlegen einer invertierten Füllfarbe für Diagrammreihen im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Holen Sie sich die Referenz einer Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im Beispiel unten verwenden wir `ChartType::ClusteredColumn`).  
1. Greifen Sie auf die Diagrammreihe zu und setzen Sie die Füllfarbe auf invert.  
1. Speichern Sie die Präsentation in einer PPTX‑Datei.  

Dieser PHP‑Code demonstriert den Vorgang:
```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Fügt neue Reihen und Kategorien hinzu
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Nimmt die erste Diagrammreihe und füllt deren Daten.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Reihe invertieren, wenn der Wert negativ ist**

Aspose.Slides ermöglicht das Invertieren über die Eigenschaften `IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative`. Wenn ein Invertieren über diese Eigenschaften gesetzt wird, ändert der Datenpunkt seine Farben, sobald er einen negativen Wert erhält.

Dieser PHP‑Code demonstriert den Vorgang:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Spezifische Punktdaten löschen**

Aspose.Slides for PHP via Java ermöglicht das Löschen der `DataPoints`‑Daten für eine bestimmte Diagrammreihe wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Holen Sie sich die Referenz eines Diagramms über dessen Index.  
4. Durchlaufen Sie alle `DataPoints` des Diagramms und setzen Sie `XValue` und `YValue` auf null.  
5. Löschen Sie alle `DataPoints` für die gewünschte Diagrammreihe.  
6. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser PHP‑Code demonstriert den Vorgang:
```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Lückenbreite der Reihe festlegen**

Aspose.Slides for PHP via Java ermöglicht das Festlegen der Lückenbreite einer Reihe über die **`GapWidth`**‑Eigenschaft wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Greifen Sie auf eine beliebige Diagrammreihe zu.  
1. Setzen Sie die Eigenschaft `GapWidth`.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Code zeigt, wie Sie die Lückenbreite einer Reihe festlegen:
```php
  # Erstellt eine leere Präsentation
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein Diagramm mit Standarddaten hinzu
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Setzt den Index des Diagrammdatenblatts
    $defaultWorksheetIndex = 0;
    # Holt das Diagrammdaten-Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Fügt Serien hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Fügt Kategorien hinzu
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Nimmt die zweite Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Befüllt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Setzt den Wert für GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Gibt es eine Begrenzung, wie viele Reihen ein einzelnes Diagramm enthalten kann?**

Aspose.Slides setzt keine feste Obergrenze für die Anzahl der hinzuzufügenden Reihen. Praktisch begrenzt die Lesbarkeit des Diagramms sowie der verfügbare Speicher Ihrer Anwendung.

**Was tun, wenn die Säulen innerhalb eines Clusters zu nahe beieinander oder zu weit auseinander liegen?**

Passen Sie die Einstellung `GapWidth` für diese Reihe (oder deren übergeordnete Reihen­gruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Säulen, ein niedrigerer Wert verringert ihn.