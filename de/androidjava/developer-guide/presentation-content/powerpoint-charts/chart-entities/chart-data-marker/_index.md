---
title: Verwalten von Diagrammdaten-Markern in Präsentationen auf Android
linktitle: Datenmarker
type: docs
url: /de/androidjava/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergröße
- Fülltyp
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Passen Sie Diagrammdaten-Marker in Aspose.Slides für Android an und steigern Sie die Wirkung von Präsentationen in PPT- und PPTX-Formaten mit klaren Java-Codebeispielen."
---

## **Diagramm-Marker-Optionen festlegen**
Marker können an Diagrammdatenpunkten innerhalb bestimmter Serien festgelegt werden. Um Diagramm-Marker-Optionen zu setzen, folgen Sie bitte den unten genannten Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erstellen des Standarddiagramms.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagramm-Marker-Optionen auf Datenpunktebene festgelegt.
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
    
    // Das Diagrammdaten-Arbeitsblatt erhalten
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo-Serien löschen
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

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die [MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/) Klasse definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit einer Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Exportieren eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/androidjava/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.