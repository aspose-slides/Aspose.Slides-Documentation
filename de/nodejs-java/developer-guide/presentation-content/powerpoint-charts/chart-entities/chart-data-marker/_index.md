---
title: Diagramm-Datenmarker
type: docs
url: /de/nodejs-java/chart-data-marker/
---

## **Diagramm-Marker-Optionen festlegen**

Die Marker können für Datenpunkte in bestimmten Diagrammserien festgelegt werden. Um Diagramm-Marker-Optionen zu setzen, befolgen Sie die unten aufgeführten Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagramm-Marker-Optionen auf Ebene der Datenpunkte festgelegt.
```javascript
// Erstellen einer leeren Präsentation
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Erstellen des Standarddiagramms
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Abrufen des Index des Standard-Chart-Daten-Arbeitsblatts
    var defaultWorksheetIndex = 0;
    // Abrufen des Chart-Daten-Arbeitsblatts
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demo-Serie löschen
    chart.getChartData().getSeries().clear();
    // Neue Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Bild 1 laden
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Bild 2 laden
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Erste Diagrammserie übernehmen
    var series = chart.getChartData().getSeries().get_Item(0);
    // Neuen Punkt (1:3) dort hinzufügen.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Ändern des Chart-Serien-Markers
    series.getMarker().setSize(15);
    // Präsentation mit Diagramm speichern
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Welche Markerformen sind standardmäßig verfügbar?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/) definiert. Wenn Sie eine nicht‑standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visuals zu emulieren.

**Werden Marker beim Export eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/nodejs-java/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.