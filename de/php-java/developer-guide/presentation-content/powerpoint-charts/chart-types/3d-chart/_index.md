---
title: 3D-Diagramm
type: docs
url: /de/php-java/3d-chart/
---

## **Setzen von RotationX, RotationY und DepthPercents Eigenschaften des 3D-Diagramms**
Aspose.Slides für PHP über Java bietet eine einfache API zum Setzen dieser Eigenschaften. Der folgende Artikel hilft Ihnen, verschiedene Eigenschaften wie **X, Y-Rotation, DepthPercents** usw. zu setzen. Der Beispielcode wendet das Setzen der oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D-Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```php
  $pres = new Presentation();
  try {
    # Auf die erste Folie zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # Diagramm mit Standarddaten hinzufügen
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Setzen des Index des Diagrammdatenblattes
    $defaultWorksheetIndex = 0;
    # Abrufen des Diagramm-Datenarbeitsblatts
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Serien hinzufügen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Serie 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Serie 2"), $chart->getType());
    # Kategorien hinzufügen
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Kategorie 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Kategorie 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Kategorie 3"));
    # Setzen der Rotation3D-Eigenschaften
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Zweite Diagrammserie nehmen
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Jetzt die Seriendaten füllen
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Überlappungswert setzen
    $series->getParentSeriesGroup()->setOverlap(100);
    # Präsentation auf die Festplatte schreiben
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```