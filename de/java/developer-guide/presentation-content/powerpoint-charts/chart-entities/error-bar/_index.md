---
title: Fehlerbalken in Präsentationsdiagrammen mit Java anpassen
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java Fehlerbalken in Diagrammen hinzufügen und anpassen - optimieren Sie die Datenvisualisierung in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides for Java stellt eine einfache API zur Verwaltung von Fehlerbalkenwerten bereit. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalken‑Format.
4. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalken‑Format.
5. Setzen der Balkenwerte und des Formats.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstelle ein Blasendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Füge Fehlerbalken hinzu und setze das Format
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

    // Speichere die Präsentation
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Benutzerdefinierte Fehlerbalkenwerte hinzufügen**
Aspose.Slides for Java stellt eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte bereit. Der Beispielcode gilt, wenn die Eigenschaft [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalken‑Format.
4. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalken‑Format.
5. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für den jeweiligen Datenpunkt.
6. Setzen der Balkenwerte und des Formats.
7. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstelle ein Blasendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Füge benutzerdefinierte Fehlerbalken hinzu und setze das Format
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Zugriff auf den Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für
    // einzelnen Punkt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Setze Fehlerbalken für Datenpunkte der Diagrammserie
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Speichere die Präsentation
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Was passiert mit Fehlerbalken beim Exportieren einer Präsentation in PDF oder Bilder?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der übrigen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markierungen und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und mit Markierungen und Datenbeschriftungen kompatibel; überschneiden sich die Elemente, müssen Sie ggf. die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen zur Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).