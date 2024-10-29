---
title: 3D Diagramm
type: docs
url: /de/androidjava/3d-chart/
---

## **Setzen der Eigenschaften RotationX, RotationY und DepthPercents des 3D Diagramms**
Aspose.Slides für Android über Java bietet eine einfache API zum Setzen dieser Eigenschaften. Der folgende Artikel hilft Ihnen dabei, wie Sie verschiedene Eigenschaften wie **X, Y Rotation, DepthPercents** usw. festlegen können. Der Beispielcode zeigt das Setzen der oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Zugriff auf die erste Folie.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D-Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie ein Diagramm mit Standarddaten hinzu
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Festlegen des Index des Diagramm-Datenblattes
    int defaultWorksheetIndex = 0;
    
    // Abrufen des Diagramm-Datenarbeitsbuchs
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Serien hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.getType());
    
    // Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));
    
    // Setzen der Rotation3D-Eigenschaften
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Nehmen Sie die zweite Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Jetzt Datenpunkte für die Serie hinzufügen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzen des OverLap-Werts
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Präsentation auf die Festplatte schreiben
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```