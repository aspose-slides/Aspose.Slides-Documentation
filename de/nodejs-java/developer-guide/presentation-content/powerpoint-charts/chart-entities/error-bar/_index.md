---
title: Fehlerbalken
type: docs
url: /de/nodejs-java/error-bar/
---

## **Fehlerbalken hinzufügen**

Aspose.Slides für Node.js über Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der Sammlung [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalken‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalken‑Format.
1. Setzen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Erstelle ein Blasendiagramm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Füge Fehlerbalken hinzu und setze dessen Format
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Speichere die Präsentation
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Benutzerdefinierten Fehlerbalkenwert hinzufügen**

Aspose.Slides für Node.js über Java bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die Eigenschaft [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der Sammlung [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalken‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalken‑Format.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für jeden Datenpunkt der Serie.
1. Setzen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Erstelle ein Blasendiagramm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Hinzufügen benutzerdefinierter Fehlerbalken und Festlegen des Formats
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Zugriff auf den Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für
    // einzelnen Punkt
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Festlegen der Fehlerbalken für Punkte der Diagrammserie
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Speichern der Präsentation
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was passiert mit Fehlerbalken beim Exportieren einer Präsentation in PDF oder Bilder?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und kompatibel mit Markern und Datenbeschriftungen; überschneiden sich die Elemente, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Aufzählungen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) und die zugehörigen Aufzählungen [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/).