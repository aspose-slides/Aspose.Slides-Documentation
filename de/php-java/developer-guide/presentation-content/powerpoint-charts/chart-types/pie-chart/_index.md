---
title: Anpassen von Kreisdiagrammen in Präsentationen mit PHP
linktitle: Kreisdiagramm
type: docs
url: /de/php-java/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Kreisdiagramme mit Aspose.Slides für PHP via Java erstellen und anpassen, exportierbar nach PowerPoint, und damit Ihre Datenpräsentation in Sekunden verbessern."
---

## **Zweite Plot-Optionen für Kreis‑in‑Kreis‑ und Balken‑in‑Kreis‑Diagramme**
Aspose.Slides for PHP via Java unterstützt jetzt Zweit‑Plot‑Optionen für Kreis‑in‑Kreis‑ oder Balken‑in‑Kreis‑Diagramme. In diesem Thema zeigen wir Ihnen, wie Sie diese Optionen mit Aspose.Slides festlegen. So geben Sie die Eigenschaften an:

1. Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Geben Sie die Zweit‑Plot‑Optionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir verschiedene Eigenschaften des Kreis‑in‑Kreis‑Diagramms festgelegt.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Diagramm zur Folie hinzufügen
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Unterschiedliche Eigenschaften festlegen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Präsentation auf die Festplatte schreiben
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Automatische Farben für Kuchen‑Diagramm‑Segmente festlegen**
Aspose.Slides for PHP via Java bietet eine einfache API zum automatischen Festlegen von Farben für Kuchen‑Diagramm‑Segmente. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Stellen Sie die erste Serie so ein, dass Werte angezeigt werden.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Abrufen des Arbeitsblatts mit Diagrammdaten.
1. Löschen Sie die standardmäßig erzeugten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Diagramm mit Standarddaten hinzufügen
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Diagrammtitel festlegen
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Erste Serie so einstellen, dass Werte angezeigt werden
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Den Index des Diagrammdatenblatts festlegen
    $defaultWorksheetIndex = 0;
    # Das Diagrammdatenarbeitsblatt abrufen
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Standardmäßig erzeugte Serien und Kategorien löschen
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Neue Kategorien hinzufügen
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Neue Serie hinzufügen
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Jetzt die Seriendaten befüllen
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **FAQ**

**Werden die Varianten 'Kreis‑in‑Kreis' und 'Balken‑in‑Kreis' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) einen sekundären Plot für Kreisdiagramme, einschließlich der Typen 'Kreis‑in‑Kreis' und 'Balken‑in‑Kreis'.

**Kann ich nur das Diagramm als Bild exportieren (z. B. PNG)?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (z. B. PNG), ohne die gesamte Präsentation.