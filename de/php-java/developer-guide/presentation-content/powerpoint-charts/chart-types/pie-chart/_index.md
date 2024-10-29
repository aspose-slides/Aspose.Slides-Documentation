---
title: Kreisdiagramm
type: docs
url: /de/php-java/pie-chart/
---

## **Zweite Plottoptionen für Kreisdiagramm und Balkendiagramm**
Aspose.Slides für PHP über Java unterstützt jetzt zweite Plottoptionen für Kreisdiagramm oder Balkendiagramm. In diesem Thema zeigen wir Ihnen, wie Sie diese Optionen mit Aspose.Slides angeben können. Um die Eigenschaften anzugeben, tun Sie Folgendes:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Geben Sie die zweiten Plottoptionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir verschiedene Eigenschaften des Kreisdiagramms festgelegt.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Fügen Sie ein Diagramm zur Folie hinzu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Stellen Sie verschiedene Eigenschaften ein
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Automatische Farben für Kreisdiagrammscheiben festlegen**
Aspose.Slides für PHP über Java bietet eine einfache API zum Festlegen automatischer Farben für Kreisdiagrammscheiben. Der Beispielcode wendet das Festlegen der oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Titel des Diagramms.
1. Stellen Sie die erste Serie auf Werte anzeigen ein.
1. Stellen Sie den Index des Diagrammdatenblatts ein.
1. Holen Sie sich das Diagrammdatenarbeitsblatt.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Fügen Sie ein Diagramm mit Standarddaten hinzu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Setzen Sie den Titel des Diagramms
    $chart->getChartTitle()->addTextFrameForOverriding("Beispieltitel");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Stellen Sie die erste Serie auf Werte anzeigen ein
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Setzen Sie den Index des Diagrammdatenblatts
    $defaultWorksheetIndex = 0;
    # Holen Sie sich das Diagrammdatenarbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Löschen Sie die standardmäßig generierten Serien und Kategorien
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Neue Kategorien hinzufügen
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "Erstes Quartal"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "Zweites Quartal"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "Drittes Quartal"));
    # Neue Serien hinzufügen
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Serie 1"), $chart->getType());
    # Jetzt Daten für die Serie befüllen
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