---
title: Kreisdiagramm
type: docs
url: /de/nodejs-java/pie-chart/
---

## **Zweite Plotoptionen für Pie of Pie und Bar of Pie Diagramm**
Aspose.Slides für Node.js via Java unterstützt jetzt zweite Plotoptionen für Pie of Pie‑ oder Bar of Pie‑Diagramme. In diesem Thema zeigen wir Ihnen, wie Sie diese Optionen mit Aspose.Slides festlegen. So geben Sie die Eigenschaften an:

1. Instanziieren Sie das Klassenobjekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Fügen Sie dem Folie ein Diagramm hinzu.
3. Geben Sie die zweiten Plotoptionen des Diagramms an.
4. Schreiben Sie die Präsentation auf die Festplatte.

In dem unten stehenden Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.
```javascript
    // Erstelle eine Instanz der Presentation-Klasse
    var pres = new aspose.slides.Presentation();
    try {
        // Diagramm zur Folie hinzufügen
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
        // Verschiedene Eigenschaften festlegen
        chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
        chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
        chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
        chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
        // Präsentation auf Festplatte speichern
        pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Automatische Farben für Kuchen‑Diagramm‑Segmente festlegen**
Aspose.Slides für Node.js via Java bietet eine einfache API zum Festlegen automatischer Farben für Kuchen‑Diagramm‑Segmente. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Legen Sie den Diagrammtitel fest.
5. Setzen Sie die erste Datenreihe auf Werte anzeigen.
6. Legen Sie den Index des Diagrammdatenblatts fest.
7. Abrufen des Diagrammdaten‑Arbeitsblatts.
8. Löschen Sie die standardmäßig generierten Datenreihen und Kategorien.
9. Fügen Sie neue Kategorien hinzu.
10. Fügen Sie neue Datenreihen hinzu.

Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Diagramm mit Standarddaten hinzufügen
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Diagrammtitel festlegen
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Erste Datenreihe auf Werte anzeigen setzen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Index des Diagrammdatenblatts festlegen
    var defaultWorksheetIndex = 0;
    // Diagrammdaten-Arbeitsblatt abrufen
    var fact = chart.getChartData().getChartDataWorkbook();
    // Standardmäßig erzeugte Datenreihen und Kategorien löschen
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Neue Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Neue Datenreihe hinzufügen
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Jetzt Daten der Reihe füllen
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ein sekundäres Plot für Kreisdiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (z. B. PNG), ohne die gesamte Präsentation.