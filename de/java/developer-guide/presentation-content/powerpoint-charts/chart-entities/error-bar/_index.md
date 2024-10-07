---
title: Fehlerbalken
type: docs
url: /java/error-bar/
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode ist anwendbar, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) Sammlung von Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie ein Blasen-Diagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-X-Format fest.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-Y-Format fest.
1. Werte und Format der Balken einstellen.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasen-Diagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen von Fehlerbalken und Festlegen des Formats
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Präsentation speichern
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierten Fehlerbalkenwert hinzufügen**
Aspose.Slides für Java bietet eine einfache API zur Verwaltung von benutzerdefinierten Fehlerbalkenwerten. Der Beispielcode ist anwendbar, wenn die [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) Eigenschaft gleich **Benutzerdefiniert** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) Sammlung von Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie ein Blasen-Diagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-X-Format fest.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-Y-Format fest.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und legen Sie die Fehlerbalkenwerte für den einzelnen Datenpunkt der Serie fest.
1. Werte und Format der Balken einstellen.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasen-Diagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen benutzerdefinierter Fehlerbalken und Festlegen des Formats
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Greifen Sie auf den Datenpunkt der Diagrammserie zu und legen Sie die Fehlerbalkenwerte für
    // den einzelnen Punkt fest
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Fehlerbalken für die Punkte der Diagrammserie festlegen
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Präsentation speichern
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```