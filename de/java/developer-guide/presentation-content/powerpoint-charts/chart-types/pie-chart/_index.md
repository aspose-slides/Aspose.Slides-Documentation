---
title: Anpassen von Kreisdiagrammen in Präsentationen mit Java
linktitle: Kreisdiagramm
type: docs
url: /de/java/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Scheibenfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Kreisdiagramme in Java mit Aspose.Slides erstellen und anpassen, exportierbar nach PowerPoint, und so Ihre Datenpräsentation in Sekundenschnelle verbessern."
---

## **Zweite Diagrammoptionen für Kuchen-von-Kuchen und Balken-von-Kuchen Diagramme**
Aspose.Slides for Java unterstützt jetzt zweite Plot-Optionen für Kuchen-von-Kuchen- oder Balken-von-Kuchen-Diagramme. In diesem Thema zeigen wir, wie Sie diese Optionen mit Aspose.Slides festlegen. So geben Sie die Eigenschaften an:

1. Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Geben Sie die zweiten Plot-Optionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir verschiedene Eigenschaften des Kuchen-von-Kuchen-Diagramms gesetzt.
```java
// Erstelle eine Instanz der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Diagramm zur Folie hinzufügen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Unterschiedliche Eigenschaften festlegen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Präsentation auf die Festplatte schreiben
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Automatische Farben für Kuchen-Diagramm-Scheiben festlegen**
Aspose.Slides for Java bietet eine einfache API zum Festlegen automatischer Farben für Kuchen-Diagramm-Scheiben. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Setzen Sie den Diagrammtitel.
5. Stellen Sie die erste Serie so ein, dass Werte angezeigt werden.
6. Legen Sie den Index des Diagrammdatenblatts fest.
7. Holen Sie das Arbeitsblatt mit den Diagrammdaten.
8. Löschen Sie die standardmäßig erzeugten Serien und Kategorien.
9. Fügen Sie neue Kategorien hinzu.
10. Fügen Sie neue Serien hinzu.

Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Diagramm mit Standarddaten hinzufügen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Diagrammtitel festlegen
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Erste Serie auf Werte anzeigen setzen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Index des Diagrammdatenblatts festlegen
    int defaultWorksheetIndex = 0;

    // Diagrammdaten-Arbeitsblatt holen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Standardmäßig erzeugte Serien und Kategorien löschen
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Neue Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Neue Serie hinzufügen
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Jetzt die Seriendaten befüllen
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Werden die 'Kuchen-von-Kuchen' und 'Balken-von-Kuchen' Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ein sekundäres Plot für Kuchen-Diagramme, einschließlich der Typen 'Kuchen-von-Kuchen' und 'Balken-von-Kuchen'.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst [als Bild exportieren](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) (z. B. PNG), ohne die gesamte Präsentation.