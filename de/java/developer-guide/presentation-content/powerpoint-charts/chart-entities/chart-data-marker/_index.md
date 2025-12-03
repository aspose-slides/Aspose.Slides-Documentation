---
title: Diagrammdatenmarker in Präsentationen mit Java verwalten
linktitle: Datenmarker
type: docs
url: /de/java/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergöße
- Fülltyp
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenmarker in Aspose.Slides für Java anpassen und damit die Wirkung von Präsentationen in PPT‑ und PPTX‑Formaten mit klaren Java‑Codebeispielen steigern."
---

## **Diagramm-Marker-Optionen festlegen**
Die Marker können an den Datenpunkten eines Diagramms in bestimmten Serien festgelegt werden. Um Diagramm-Marker-Optionen zu setzen, folgen Sie bitte den untenstehenden Schritten:

- Instanzieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachfolgenden Beispiel haben wir die Diagramm-Marker-Optionen auf Datenpunktebene festgelegt.
```java
// Leere Präsentation erstellen
Presentation pres = new Presentation();
try {
    // Erste Folie zugreifen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Standarddiagramm erstellen
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Den Index des Standard-Diagrammdaten-Arbeitsblatts erhalten
    int defaultWorksheetIndex = 0;
    
    // Das Diagrammdaten-Arbeitsblatt abrufen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo-Serie löschen
    chart.getChartData().getSeries().clear();
    
    // Neue Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Bild 1 laden
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Bild 2 laden
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Erste Diagrammserie nehmen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Neuen Punkt (1:3) dort hinzufügen.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Diagrammserien-Marker ändern
    series.getMarker().setSize(15);
    
    // Präsentation mit Diagramm speichern
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welche Markerformen sind standardmäßig verfügbar?**
Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Klasse [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visualisierungen nachzuahmen.

**Werden Marker beim Export eines Diagramms in ein Bild oder SVG beibehalten?**
Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/java/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/java/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.