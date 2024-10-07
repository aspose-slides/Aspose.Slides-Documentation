---
title: Diagramm-Datenmarker
type: docs
url: /php-java/chart-data-marker/
---

## **Diagramm-Markeroptionen festlegen**
Die Marker können auf Datenpunkten von Diagrammen innerhalb bestimmter Serien festgelegt werden. Um die Diagramm-Markeroptionen festzulegen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Setzen Sie das Bild.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagramm-Markeroptionen auf Datenpunktebene festgelegt.

```php
  # Erstellen einer leeren Präsentation
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Erstellen des Standarddiagramms
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Abrufen des Index des Arbeitsblatts für die Standarddiagrammdaten
    $defaultWorksheetIndex = 0;
    # Abrufen des Arbeitsblatts für die Diagrammdaten
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo-Serie löschen
    $chart->getChartData()->getSeries()->clear();
    # Neue Serie hinzufügen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Serie 1"), $chart->getType());
    # Bild 1 laden
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Bild 2 laden
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Nehmen Sie die erste Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Neuen Punkt (1:3) hinzufügen.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Ändern des Diagrammserienmarkierungen
    $series->getMarker()->setSize(15);
    # Präsentation mit Diagramm speichern
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```