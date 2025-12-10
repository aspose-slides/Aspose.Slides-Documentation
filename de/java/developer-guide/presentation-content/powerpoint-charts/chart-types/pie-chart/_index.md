---
title: Kuchendiagramme in Präsentationen mit Java anpassen
linktitle: Kuchendiagramm
type: docs
url: /de/java/pie-chart/
keywords:
- Kuchendiagramm
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides in Java Kuchendiagramme erstellen und anpassen, exportierbar nach PowerPoint, und Ihre Datenpräsentation in Sekunden verbessern."
---

## **Optionen für das zweite Diagramm bei Pie of Pie- und Bar of Pie-Diagrammen**
Aspose.Slides for Java unterstützt jetzt Optionen für das sekundäre Diagramm bei Pie of Pie- oder Bar of Pie-Diagrammen. In diesem Abschnitt zeigen wir, wie Sie diese Optionen mit Aspose.Slides festlegen. So geben Sie die Eigenschaften an:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klassenobjekt.  
1. Fügen Sie dem Folie ein Diagramm hinzu.  
1. Geben Sie die Optionen für das sekundäre Diagramm des Diagramms an.  
1. Speichern Sie die Präsentation auf dem Datenträger.  

Im nachstehenden Beispiel haben wir verschiedene Eigenschaften des Pie of Pie-Diagramms festgelegt.  
```java
// Instanz der Presentation-Klasse erstellen
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


## **Automatische Farben für Pie‑Chart‑Scheiben festlegen**
Aspose.Slides for Java bietet eine einfache API zum Festlegen automatischer Farben für Pie‑Chart‑Folien. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Legen Sie den Diagrammtitel fest.  
1. Setzen Sie die erste Datenreihe auf 'Werte anzeigen'.  
1. Legen Sie den Index des Diagrammdatenblatts fest.  
1. Abrufen des Diagrammdaten‑Arbeitsblatts.  
1. Löschen Sie die standardmäßig generierten Reihen und Kategorien.  
1. Fügen Sie neue Kategorien hinzu.  
1. Fügen Sie neue Reihen hinzu.  

Speichern Sie die geänderte Präsentation in einer PPTX-Datei.  
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Diagramm mit Standarddaten hinzufügen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Diagrammtitel festlegen
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Erste Datenreihe auf Werte anzeigen setzen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Index des Diagrammdatensheets festlegen
    int defaultWorksheetIndex = 0;

    // Diagrammdatentabelle abrufen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Standardmäßig generierte Reihen und Kategorien löschen
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Neue Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Neue Reihe hinzufügen
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Jetzt Reihen-Daten füllen
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

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek unterstützt ein sekundäres Diagramm für Kuchendiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.  

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst als Bild (z. B. PNG) exportieren, ohne die gesamte Präsentation.