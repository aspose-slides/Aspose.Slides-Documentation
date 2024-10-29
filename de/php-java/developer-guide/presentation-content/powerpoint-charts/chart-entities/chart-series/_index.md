---
title: Diagrammreihen
type: docs
url: /de/php-java/chart-series/
keywords: "Diagrammreihe, Reihenfarbe, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Diagrammreihen in PowerPoint-Präsentationen"
---

Eine Reihe ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammreihe Überlappung Festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) Eigenschaft können Sie angeben, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Reihen der übergeordneten Seriengruppe: Dies ist eine Projektion der entsprechenden Gruppen-Eigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die `ParentSeriesGroup.Overlap` Lese-/Schreib-Eigenschaft, um Ihren bevorzugten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Fügen Sie auf einer Folie ein gruppiertes Säulendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammreihe zu.
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammreihe zu und setzen Sie Ihren bevorzugten Überlappungswert für die Reihe.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammreihe festlegen:

```php
  $pres = new Presentation();
  try {
    # Fügt Diagramm hinzu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Setzt die Überlappung der Reihe
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

## **Reihenfarbe Ändern**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Farbe einer Reihe wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Reihe zu, deren Farbe Sie ändern möchten.
1. Setzen Sie Ihren bevorzugten Fülltyp und die Füllfarbe.
1. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie die Farbe einer Reihe ändern:

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

## **Farbe der Reihen-Kategorie Ändern**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Farbe einer Reihen-Kategorie wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Reihen-Kategorie zu, deren Farbe Sie ändern möchten.
1. Setzen Sie Ihren bevorzugten Fülltyp und die Füllfarbe.
1. Speichern Sie die modifizierte Präsentation.

Dieser Code zeigt Ihnen, wie Sie die Farbe einer Serien-Kategorie ändern:

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

## **Reihennamen Ändern**

Standardmäßig sind die Legenden-Namen für ein Diagramm der Inhalt der Zellen über jeder Spalte oder Zeile von Daten.

In unserem Beispiel (Beispielbild),

* die Spalten sind *Reihe 1, Reihe 2,* und *Reihe 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.*

Aspose.Slides für PHP über Java ermöglicht es Ihnen, einen Reihennamen in seinen Diagrammdaten und der Legende zu aktualisieren oder zu ändern.

Dieser PHP-Code zeigt Ihnen, wie Sie den Namen einer Reihe in den Diagrammdaten `ChartDataWorkbook` ändern:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("Neuer Name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieser PHP-Code zeigt Ihnen, wie Sie den Namen einer Reihe in ihrer Legende über `Series` ändern:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("Neuer Name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Diagrammreihe Füllfarbe Festlegen**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammreihen innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz auf die Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit standardisierten Daten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType::ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammreihe zu und setzen Sie die Füllfarbe auf Automatisch.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie die automatische Füllfarbe für eine Diagrammreihe festlegen:

```php
  $pres = new Presentation();
  try {
    # Erstellt ein gruppiertes Säulendiagramm
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Setzt das Füllformat der Reihe auf automatisch
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

## **Diagrammreihe Umkehrfüllfarben Festlegen**
Aspose.Slides ermöglicht es Ihnen, die Umkehrfüllfarbe für Diagrammreihen innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz auf die Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit standardisierten Daten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType::ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammreihe zu und setzen Sie die Füllfarbe auf Umkehr.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser PHP-Code demonstriert die Operation:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Fügt neue Reihen und Kategorien hinzu
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Reihe 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Kategorie 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Kategorie 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Kategorie 3"));
    # Nimmt die erste Diagrammreihe und befüllt deren Seriendaten.
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

## **Reihe Auf Invertieren Setzen, Wenn Wert Negativ Ist**
Aspose.Slides ermöglicht es Ihnen, Invertierungen über die `IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative` Eigenschaften zu setzen. Wenn eine Invertierung über die Eigenschaften gesetzt wird, invertiert der Datenpunkt seine Farben, wenn er einen negativen Wert erhält.

Dieser PHP-Code demonstriert die Operation:

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

## **Daten von Bestimmten Datenpunkten Löschen**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die `DataPoints` Daten für eine bestimmte Diagrammreihe wie folgt zu löschen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Erhalten Sie die Referenz eines Diagramms über seinen Index.
4. Iterieren Sie durch alle Diagramm `DataPoints` und setzen Sie `XValue` und `YValue` auf null.
5. Löschen Sie alle `DataPoints` für eine bestimmte Diagrammreihe.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser PHP-Code demonstriert die Operation:

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

## **Reihen-Gap Width Festlegen**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Gap Width einer Reihe über die **`GapWidth`** Eigenschaft wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Greifen Sie auf eine beliebige Diagrammreihe zu.
5. Setzen Sie die `GapWidth` Eigenschaft.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Code zeigt Ihnen, wie Sie die Gap Width einer Reihe festlegen:

```php
  # Erstellt eine leere Präsentation
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein Diagramm mit Standarddaten hinzu
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Setzt den Index des Diagramm-Datenblatts
    $defaultWorksheetIndex = 0;
    # Erhält das Diagramm-Datenarbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Fügt Reihen hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Reihe 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Reihe 2"), $chart->getType());
    # Fügt Kategorien hinzu
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Kategorie 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Kategorie 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Kategorie 3"));
    # Nimmt die zweite Diagrammreihe
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Befüllt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Setzt den GapWidth-Wert
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```