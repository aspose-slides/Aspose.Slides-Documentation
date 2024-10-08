---
title: Tortendiagramm
type: docs
url: /de/java/pie-chart/
---

## **Zweite Diagrammoptionen für Tortendiagramm und Balkendiagramm**
Aspose.Slides für Java unterstützt nun zweite Diagrammoptionen für Tortendiagramm oder Balkendiagramm. In diesem Thema zeigen wir Ihnen, wie Sie diese Optionen mit Aspose.Slides angeben können. Um die Eigenschaften anzugeben, tun Sie Folgendes:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Geben Sie die zweiten Diagrammoptionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir verschiedene Eigenschaften des Tortendiagramms festgelegt.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Fügen Sie ein Diagramm auf der Folie hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Setzen Sie verschiedene Eigenschaften
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("ZweiteDiagrammoptionenfürDiagramme_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Automatische Farben für Tortendiagrammscheiben einstellen**
Aspose.Slides für Java bietet eine einfache API zum Einstellen automatscholler Farben für Tortendiagrammanscheiben. Der Beispielcode wendet das oben genannte Eigenschaften an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Titel des Diagramms.
1. Stellen Sie die erste Serie so ein, dass Werte angezeigt werden.
1. Setzen Sie den Index des Diagramm-Datenblatts.
1. Holen Sie sich das Arbeitsblatt für die Diagrammdaten.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Fügen Sie ein Diagramm mit Standarddaten hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Titel des Diagramms festlegen
    chart.getChartTitle().addTextFrameForOverriding("Beispieltitel");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Erste Serie so einstellen, dass Werte angezeigt werden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Setzen Sie den Index des Diagramm-Datenblatts
    int defaultWorksheetIndex = 0;

    // Holen Sie sich das Arbeitsblatt für die Diagrammdaten
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Löschen Sie die standardmäßig generierten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Hinzufügen neuer Kategorien
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Erstes Quartal"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Zweites Quartal"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Drittes Quartal"));

    // Hinzufügen neuer Serien
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Serie 1"), chart.getType());

    // Jetzt die Seriendaten ausfüllen
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Torte.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```