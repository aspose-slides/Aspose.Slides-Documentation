---
title: Anpassen von 3D-Diagrammen in Präsentationen mit PHP
linktitle: 3D-Diagramm
type: docs
url: /de/php-java/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3-D-Diagramme in Aspose.Slides für PHP via Java erstellen und anpassen, mit Unterstützung für PPT- und PPTX-Dateien — verbessern Sie noch heute Ihre Präsentationen."
---

## **RotationX-, RotationY- und DepthPercents-Eigenschaften eines 3D-Diagramms festlegen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel zeigt, wie Sie verschiedene Eigenschaften wie **X,Y-Rotation, DepthPercents** usw. setzen können. Der Beispielcode demonstriert das Festlegen der genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Setzen Sie die Rotation3D‑Eigenschaften.
5. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```php
  $pres = new Presentation();
  try {
    # Erste Folie zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # Diagramm mit Standarddaten hinzufügen
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Index des Diagrammdatenblatts festlegen
    $defaultWorksheetIndex = 0;
    # Diagrammdaten-Arbeitsblatt abrufen
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Serie hinzufügen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Kategorien hinzufügen
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Rotation3D-Eigenschaften festlegen
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Zweite Diagrammserie übernehmen
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Serie mit Daten füllen
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Überlappungswert festlegen
    $series->getParentSeriesGroup()->setOverlap(100);
    # Präsentation auf Festplatte schreiben
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)-Klasse bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [Diagramm‑API](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) in ein Bild exportieren oder die gesamte Folie mit [die gesamte Folie rendern](/slides/de/php-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Das ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für beste Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen Sie die Anzahl der Datenpunkte pro Serie, wenn möglich, und rendern Sie in einer angemessen großen Ausgabe (Auflösung und Abmessungen), die den Ziel‑Display‑ oder Druckanforderungen entspricht.