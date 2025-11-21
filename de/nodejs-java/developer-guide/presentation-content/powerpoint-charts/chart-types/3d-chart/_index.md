---
title: 3D-Diagramm
type: docs
url: /de/nodejs-java/3d-chart/
---

## **Festlegen der Eigenschaften RotationX, RotationY und DepthPercents eines 3D-Diagramms**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Festlegen dieser Eigenschaften. Der nachfolgende Artikel zeigt, wie Sie verschiedene Eigenschaften wie **X,Y Rotation, DepthPercents** usw. einstellen können. Der Beispielcode demonstriert das Setzen der oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D‑Eigenschaften.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Diagramm mit Standarddaten hinzufügen
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Festlegen des Indexes des Diagrammdatenblatts
    var defaultWorksheetIndex = 0;
    // Abrufen des Diagrammdaten-Arbeitsblatts
    var fact = chart.getChartData().getChartDataWorkbook();
    // Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Rotation3D-Eigenschaften festlegen
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Zweite Diagrammserie übernehmen
    var series = chart.getChartData().getSeries().get_Item(1);
    // Jetzt werden die Seriendaten befüllt
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Überlappungswert festlegen
    series.getParentSeriesGroup().setOverlap(100);
    // Präsentation auf die Festplatte schreiben
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100% Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder der [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) oder die gesamte Folie [render the entire slide](/slides/de/nodejs-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG exportieren. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt von Datenvolumen und visueller Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen die Anzahl der Datenpunkte pro Serie nach Möglichkeit und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die den Zielanzeige‑ oder Druckanforderungen entspricht.