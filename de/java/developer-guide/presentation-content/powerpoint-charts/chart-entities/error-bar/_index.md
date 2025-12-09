---
title: Anpassen von Fehlerbalken in Präsentationsdiagrammen mit Java
linktitle: Fehlerbalken
type: docs
url: /de/java/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java Fehlerbalken in Diagrammen hinzufügen und anpassen – optimieren Sie Datenvisualisierungen in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides for Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X-Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y-Format des Fehlerbalkens.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Fehlerbalken hinzufügen und Format festlegen
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
Aspose.Slides for Java bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--)‑Eigenschaft auf **Custom** gesetzt ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X-Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y-Format des Fehlerbalkens.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für einzelne Datenpunkte.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Erstellen eines Blasendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Benutzerdefinierte Fehlerbalken hinzufügen und Format festlegen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Zugriff auf Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für
    // einzelnen Punkt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Fehlerbalken für Diagrammserienpunkte festlegen
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


## **FAQ**

**Was passiert mit Fehlerbalken, wenn eine Präsentation in PDF oder Bilder exportiert wird?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung beibehalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markierungen und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und kompatibel mit Markierungen und Datenbeschriftungen; wenn Elemente überlappen, müssen Sie ggf. die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen zur Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/)-Klasse und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).