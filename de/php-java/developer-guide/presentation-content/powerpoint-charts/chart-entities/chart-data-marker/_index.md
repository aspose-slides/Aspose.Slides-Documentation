---
title: Diagrammdaten-Marker in Präsentationen mit PHP verwalten
linktitle: Datenmarker
type: docs
url: /de/php-java/chart-data-marker/
keywords:
- diagramm
- datenpunkt
- marker
- markeroptionen
- markergröße
- fülltyp
- PowerPoint
- präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdaten-Marker in Aspose.Slides für PHP anpassen können, um die Wirkung von Präsentationen in PPT- und PPTX-Formaten mit klaren Codebeispielen zu steigern."
---

## **Diagramm-Markeroptionen festlegen**
Die Marker können auf Diagrammdatenpunkten innerhalb bestimmter Serien festgelegt werden. Um Diagramm-Markeroptionen zu setzen, befolgen Sie bitte die nachstehenden Schritte:

- Instanzieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Speichern Sie die Präsentation auf dem Datenträger.

Im nachstehenden Beispiel haben wir die Diagrammmarkeroptionen auf Datenpunktebene festgelegt.
```php
  # Leere Präsentation erstellen
  $pres = new Presentation();
  try {
    # Ersten Folie zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # Standarddiagramm erstellen
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Standard-Diagrammdaten-Worksheet-Index abrufen
    $defaultWorksheetIndex = 0;
    # Diagrammdaten-Worksheet abrufen
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo-Serie löschen
    $chart->getChartData()->getSeries()->clear();
    # Neue Serie hinzufügen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Bild 1 laden
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Bild 2 laden
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Erste Diagrammserie holen
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Neuen Punkt (1:3) dort hinzufügen.
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
    # Diagrammserien-Marker ändern
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


## **FAQ**

**Welche Markerformen stehen standardmäßig zur Verfügung?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Klasse [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Exportieren eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/php-java/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.