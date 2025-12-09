---
title: Fehlerbalken in Präsentationsdiagrammen in .NET anpassen
linktitle: Fehlerbalken
type: docs
url: /de/net/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fehlerbalken in Diagrammen mit Aspose.Slides für .NET hinzufügen und anpassen — optimieren Sie Datenvisualisierungen in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Festlegen von Balkenwerten und -format.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```c#
// Leere Präsentation erstellen
using (Presentation presentation = new Presentation())
{
    // Ein Blasendiagramm erstellen
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Fehlerbalken hinzufügen und deren Format festlegen
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Präsentation speichern
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **Benutzerdefinierten Fehlerbalkenwert hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType**‑Eigenschaft den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für den jeweiligen Datenpunkt der Serie.
1. Festlegen von Balkenwerten und -format.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```c#
// Leere Präsentation erstellen
using (Presentation presentation = new Presentation())
{
    // Ein Blasendiagramm erstellen
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Benutzerdefinierte Fehlerbalken hinzufügen und ihr Format festlegen
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Zugriff auf Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für einzelnen Punkt
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Fehlerbalken für Punkte der Diagrammserie festlegen
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Präsentation speichern
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was passiert mit Fehlerbalken, wenn eine Präsentation in PDF oder Bilder exportiert wird?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der übrigen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein kompatibler Renderer verwendet.

**Können Fehlerbalken mit Markierungen und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und mit Markierungen und Datenbeschriftungen kompatibel; überschneiden sich die Elemente, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Aufzählungen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) und die zugehörigen Aufzählungen [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).