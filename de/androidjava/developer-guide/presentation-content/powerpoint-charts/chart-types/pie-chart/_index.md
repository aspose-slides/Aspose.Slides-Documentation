---
title: "Kuchendiagramme in Präsentationen auf Android anpassen"
linktitle: "Kuchendiagramm"
type: docs
url: /de/androidjava/pie-chart/
keywords:
- "Kuchendiagramm"
- "Diagramm verwalten"
- "Diagramm anpassen"
- "Diagrammoptionen"
- "Diagrammeinstellungen"
- "Darstellungsoptionen"
- "Scheibenfarbe"
- "PowerPoint"
- "Präsentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Android in Java Kuchendiagramme erstellen und anpassen, exportierbar nach PowerPoint, und Ihre Datenpräsentation in Sekundenschnelle verbessern."
---

## **Optionen für sekundäre Diagramme bei Pie of Pie- und Bar of Pie-Diagrammen**
Aspose.Slides for Android via Java unterstützt jetzt Optionen für sekundäre Diagramme bei Pie of Pie‑ oder Bar of Pie‑Diagrammen. In diesem Thema zeigen wir, wie Sie diese Optionen mit Aspose.Slides festlegen können. So geben Sie die Eigenschaften an:

1. Instanziieren Sie das Objekt der Klasse [Presentation].
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Geben Sie die Optionen für das sekundäre Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im unten gegebenen Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Diagramm zur Folie hinzufügen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Verschiedene Eigenschaften festlegen
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


## **Automatische Farben für Kuchendiagramm‑Scheiben festlegen**
Aspose.Slides for Android via Java bietet eine einfache API zum Festlegen automatischer Farben für die Scheiben eines Kuchendiagramms. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse [Presentation].
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Legen Sie den Diagrammtitel fest.
1. Setzen Sie die erste Serie auf Werte anzeigen.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Abrufen des Diagrammdatenarbeitsblatts.
1. Löschen Sie die standardmäßig erzeugten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
// Eine Instanz der Presentation-Klasse erstellen
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

    // Diagrammdatenarbeitsblatt abrufen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Standardmäßig generierte Serien und Kategorien löschen
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Neue Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Neue Serie hinzufügen
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Jetzt werden die Serien-Daten befüllt
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

**Werden die 'Pie of Pie'‑ und 'Bar of Pie'‑Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ein sekundäres Diagramm für Kuchendiagramme, einschließlich der 'Pie of Pie'‑ und 'Bar of Pie'‑Typen.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können [das Diagramm selbst als Bild](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (z. B. PNG) ohne die gesamte Präsentation exportieren.