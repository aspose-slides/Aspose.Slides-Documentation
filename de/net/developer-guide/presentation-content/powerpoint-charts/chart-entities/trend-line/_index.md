---
title: Trendlinie
type: docs
url: /net/trend-line/
keywords: "Trendlinie, benutzerdefinierte Linie PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Trendlinie und benutzerdefinierte Linie in PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## **Trendlinie hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie einen beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet ChartType.ClusteredColumn).
1. Hinzufügen der exponentiellen Trendlinie für Diagrammreihe 1.
1. Hinzufügen der linearen Trendlinie für Diagrammreihe 1.
1. Hinzufügen der logarithmischen Trendlinie für Diagrammreihe 2.
1. Hinzufügen der gleitenden Durchschnittstrendlinie für Diagrammreihe 2.
1. Hinzufügen der polynomialen Trendlinie für Diagrammreihe 3.
1. Hinzufügen der Potenztrendlinie für Diagrammreihe 3.
1. Schreiben Sie die bearbeitete Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```c#
// Erstellen einer leeren Präsentation
Präsentation pres = new Präsentation();

// Erstellen eines gruppierten Säulendiagramms
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Hinzufügen der exponentiellen Trendlinie für Diagrammreihe 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Hinzufügen der linearen Trendlinie für Diagrammreihe 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Hinzufügen der logarithmischen Trendlinie für Diagrammreihe 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("Neue logarithmische Trendlinie");

// Hinzufügen der gleitenden Durchschnittstrendlinie für Diagrammreihe 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "Neuer Trendlinienname";

// Hinzufügen der polynomialen Trendlinie für Diagrammreihe 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Hinzufügen der Potenztrendlinie für Diagrammreihe 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Speichern der Präsentation
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Um eine einfache Gerade zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Erstellen Sie ein neues Diagramm mit der AddChart-Methode des Shapes-Objekts
- Fügen Sie eine AutoShape vom Typ Linie mithilfe der AddAutoShape-Methode des Shapes-Objekts hinzu
- Setzen Sie die Farbe der Linienstreifen.
- Schreiben Sie die bearbeitete Präsentation als PPTX-Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

```c#
using (Präsentation pres = new Präsentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```