---
title: Fehlerbalken
type: docs
url: /de/androidjava/error-bar/
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für Android über Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt für die Verwendung eines benutzerdefinierten Wertetyps. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)-Kollektion der Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammreihe zu und setzen Sie das Fehlerbalken-X-Format.
1. Greifen Sie auf die erste Diagrammreihe zu und setzen Sie das Fehlerbalken-Y-Format.
1. Setzen Sie die Balkenwerte und das Format.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen von Fehlerbalken und Festlegen ihres Formats
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
Aspose.Slides für Android über Java bietet eine einfache API zur Verwaltung von benutzerdefinierten Fehlerbalkenwerten. Der Beispielcode gilt, wenn die [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) -Eigenschaft gleich **Custom** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)-Kollektion der Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammreihe zu und setzen Sie das Fehlerbalken-X-Format.
1. Greifen Sie auf die erste Diagrammreihe zu und setzen Sie das Fehlerbalken-Y-Format.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammreihe zu und setzen Sie die Fehlerbalkenwerte für den einzelnen Serien-Datenpunkt.
1. Setzen Sie die Balkenwerte und das Format.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen von benutzerdefinierten Fehlerbalken und Festlegen ihres Formats
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Zugriff auf die Datenpunkte der Diagrammreihe und Festlegen der Fehlerbalkenwerte für
    // den einzelnen Punkt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Festlegen der Fehlerbalken für die Datenpunktwerte der Diagrammreihe
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