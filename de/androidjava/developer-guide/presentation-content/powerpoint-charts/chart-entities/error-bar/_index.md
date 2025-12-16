---
title: Fehlerbalken in Präsentationsdiagrammen auf Android anpassen
linktitle: Fehlerbalken
type: docs
url: /de/androidjava/error-bar/
keywords:
- Fehlerbalken
- Benutzerdefinierter Wert
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fehlerbalken in Diagrammen mit Aspose.Slides für Android via Java hinzufügen und anpassen — optimieren Sie die Datenvisualisierung in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides for Android via Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Fügen Sie auf der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑X‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑Y‑Format.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Ein Blasendiagramm erstellen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Fehlerbalken hinzufügen und das Format festlegen
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


## **Benutzerdefinierte Fehlerbalkenwerte hinzufügen**
Aspose.Slides for Android via Java bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die Eigenschaft [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Fügen Sie auf der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑X‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑Y‑Format.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für die einzelnen Datenpunkte der Serie.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
// Eine Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    // Ein Blasendiagramm erstellen
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Benutzerdefinierte Fehlerbalken hinzufügen und das Format festlegen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Zugriff auf den Datenpunkt der Diagrammreihe und Festlegen der Fehlerbalkenwerte für
    // einzelnen Punkt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Fehlerbalken für Diagrammreihenpunkte festlegen
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

**Was passiert mit Fehlerbalken beim Exportieren einer Präsentation in PDF oder Bilder?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung beibehalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und kompatibel mit Markern und Datenbeschriftungen; überschneiden sich die Elemente, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarsformat/) und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarvaluetype/).