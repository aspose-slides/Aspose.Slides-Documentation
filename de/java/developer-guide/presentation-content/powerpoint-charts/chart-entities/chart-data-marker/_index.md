---
title: Diagrammdatenpunkt
type: docs
url: /de/java/chart-data-marker/
---

## **Diagrammmarker-Optionen festlegen**
Die Marker können auf Diagrammdatenpunkten innerhalb bestimmter Serien festgelegt werden. Um Diagrammmarker-Optionen festzulegen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Erstellen des Standarddiagramms.
- Bild festlegen.
- Erste Diagrammserie übernehmen.
- Neuen Datenpunkt hinzufügen.
- Präsentation auf die Festplatte schreiben.

Im folgenden Beispiel haben wir die Diagrammmarker-Optionen auf Datenpunktebene festgelegt.

```java
// Erstellen einer leeren Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Erstellen des Standarddiagramms
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Abrufen des Standarddiagrammdaten-Worksheet-Indexes
    int defaultWorksheetIndex = 0;
    
    // Abrufen des Diagrammdaten-WorkSheets
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löschen der Demoserie
    chart.getChartData().getSeries().clear();
    
    // Hinzufügen neuer Serien
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.getType());

    // Bild 1 laden
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Bild 2 laden
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Erste Diagrammserie übernehmen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Neuen Punkt (1:3) hinzufügen.
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
    
    // Ändern des Diagrammserienmarkers
    series.getMarker().setSize(15);
    
    // Präsentation mit Diagramm speichern
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```