---
title: Fehlerbalken
type: docs
url: /net/error-bar/
keywords: "Fehlerbalken, Fehlerbalkenwerte PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie Fehlerbalken zu PowerPoint-Präsentationen in C# oder .NET hinzu"
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**-Sammlung der Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammreihe zu und legen Sie das Format des Fehlerbalken X fest.
1. Greifen Sie auf die erste Diagrammreihe zu und legen Sie das Format des Fehlerbalken Y fest.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```c#
// Erstellen einer leeren Präsentation
using (Presentation presentation = new Presentation())
{
    // Erstellen eines Blasendiagramms
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen von Fehlerbalken und Festlegen des Formats
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
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung von benutzerdefinierten Fehlerbalkenwerten. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType**-Eigenschaft gleich **Custom** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**-Sammlung der Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammreihe zu und legen Sie das Format des Fehlerbalken X fest.
1. Greifen Sie auf die erste Diagrammreihe zu und legen Sie das Format des Fehlerbalken Y fest.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammreihe zu und legen Sie die Fehlerbalkenwerte für den einzelnen Datenpunkt der Serie fest.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```c#
// Erstellen einer leeren Präsentation
using (Presentation presentation = new Presentation())
{
    // Erstellen eines Blasendiagramms
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hinzufügen von benutzerdefinierten Fehlerbalken und Festlegen des Formats
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Zugriff auf die Datenpunkte der Diagrammreihe und Festlegen der Fehlerbalkenwerte für einzelne Punkte
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Festlegen der Fehlerbalken für die Punkte der Diagrammreihe
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