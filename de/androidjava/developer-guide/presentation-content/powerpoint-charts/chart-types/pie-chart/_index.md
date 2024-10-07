---
title: Kreisdiagramm
type: docs
url: /androidjava/pie-chart/
---

## **Zweite Plot-Optionen für Kreis- und Balkendiagramm**
Aspose.Slides für Android über Java unterstützt jetzt zweite Plot-Optionen für Kreis- oder Balkendiagramme. In diesem Thema zeigen wir Ihnen, wie Sie diese Optionen mit Aspose.Slides angeben. Um die Eigenschaften anzugeben, tun Sie Folgendes:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Geben Sie die zweiten Plot-Optionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir verschiedene Eigenschaften des Kreisdiagramms festgelegt.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Fügen Sie das Diagramm zur Folie hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Verschiedene Eigenschaften festlegen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Automatische Farben für die Schnittflächen des Kreisdiagramms festlegen**
Aspose.Slides für Android über Java bietet eine einfache API zum Festlegen automatischer Farben für die Schnittflächen des Kreisdiagramms. Der Beispielcode beschreibt die oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Titel des Diagramms.
1. Setzen Sie die erste Reihe auf Werte anzeigen.
1. Setzen Sie den Index des Diagrammdatenblatts.
1. Aufrufen des Diagrammdatenarbeitsblatts.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Fügen Sie das Diagramm mit Standarddaten hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Setzen des Titels des Diagramms
    chart.getChartTitle().addTextFrameForOverriding("Beispieltitel");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Setzen der ersten Reihe auf Werte anzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Festlegen des Index des Diagrammdatenblatts
    int defaultWorksheetIndex = 0;

    // Erhalten des Diagrammdatenarbeitsblatts
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Löschen der standardmäßig generierten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Hinzufügen neuer Kategorien
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Erstes Quartal"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2. Quartal"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3. Quartal"));

    // Hinzufügen neuer Serien
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Serie 1"), chart.getType());

    // Jetzt Daten für die Serien hinzufügen
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Kreis.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```