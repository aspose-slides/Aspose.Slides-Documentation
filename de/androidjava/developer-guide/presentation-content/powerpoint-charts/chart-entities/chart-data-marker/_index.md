---
title: Diagramm Datenmarkierer
type: docs
url: /androidjava/chart-data-marker/
---

## **Diagramm Marker Optionen festlegen**
Die Marker können auf Datenpunkten von Diagrammen innerhalb bestimmter Serien festgelegt werden. Um die Diagramm-Marker-Optionen festzulegen, folgen Sie bitte den folgenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erstellen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagramm-Marker-Optionen auf Datenpunktebene festgelegt.

```java
// Erstellen einer leeren Präsentation
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Erstellen des Standarddiagramms
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Abrufen des Index des Standarddiagrammdaten-Arbeitsblatts
    int defaultWorksheetIndex = 0;
    
    // Abrufen des Diagrammdaten-Arbeitsblatts
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löschen der Demoserie
    chart.getChartData().getSeries().clear();
    
    // Hinzufügen neuer Serien
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.getType());

    // Bild 1 laden
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Bild 2 laden
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Nehmen Sie die erste Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Fügen Sie dort einen neuen Punkt (1:3) hinzu.
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