---
title: Diagrammbeschriftungen in Präsentationen mit PHP verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/php-java/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---

Datenbeschriftungen in einem Diagramm zeigen Details zur Diagrammdatenreihe oder zu einzelnen Datenpunkten. Sie ermöglichen es den Lesern, Datenreihen schnell zu identifizieren, und machen Diagramme leichter verständlich.

## **Datenpräzision in Diagrammbeschriftungen festlegen**

Dieser PHP‑Code zeigt, wie man die Datenpräzision in einer Diagrammbeschriftung festlegt:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Prozentsatz als Beschriftungen anzeigen**

Aspose.Slides für PHP via Java ermöglicht das Festlegen von Prozentbeschriftungen in angezeigten Diagrammen. Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Speichert die Präsentation mit dem Diagramm
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Prozentzeichen in Diagrammbeschriftungen festlegen**

Dieser PHP‑Code zeigt, wie man das Prozentzeichen für eine Diagrammbeschriftung festlegt:
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Holt die Referenz einer Folie über ihren Index
    $slide = $pres->getSlides()->get_Item(0);
    # Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Setzt NumberFormatLinkedToSource auf false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Holt das Arbeitsblatt der Diagrammdaten
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Fügt eine neue Serie hinzu
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Setzt die Füllfarbe der Serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Setzt die Eigenschaften des LabelFormats
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Fügt eine neue Serie hinzu
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Setzt Fülltyp und -farbe
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Beschriftungsabstand von einer Achse festlegen**

Dieser PHP‑Code zeigt, wie man den Abstand der Beschriftung von einer Kategorienachse einstellt, wenn man ein Diagramm mit Achsen erstellt:
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Holt die Referenz einer Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellt ein Diagramm auf der Folie
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Setzt den Beschriftungsabstand von einer Achse
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achse verwendet, beispielsweise ein Kreisdiagramm, können die Datenbeschriftungen des Diagramms zu nahe am Rand liegen. In einem solchen Fall müssen Sie die Position der Datenbeschriftung anpassen, damit die Führungs‑Linien klar dargestellt werden.

Dieser PHP‑Code zeigt, wie man die Beschriftungsposition in einem Kreisdiagramm anpasst:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungs‑Linien und reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme bzw. wichtige Punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und deaktivieren Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie Schriftarten (Familie, Größe) explizit und prüfen Sie, ob die Schriftart auf der Rendering‑Seite verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.