---
title: Trendlinie
type: docs
url: /de/net/trend-line/
keywords: "Trendlinie, benutzerdefinierte Linie PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Trendlinie und benutzerdefinierte Linie zu PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## **Trendlinie hinzufügen**
Aspose.Slides for .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Diagrammtyp hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Exponentielle Trendlinie für Diagramm-Serie 1 hinzufügen.
5. Lineare Trendlinie für Diagramm-Serie 1 hinzufügen.
6. Logarithmische Trendlinie für Diagramm-Serie 2 hinzufügen.
7. Gleitender Durchschnitt Trendlinie für Diagramm-Serie 2 hinzufügen.
8. Polynomiale Trendlinie für Diagramm-Serie 3 hinzufügen.
9. Power‑Trendlinie für Diagramm-Serie 3 hinzufügen.
10. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.

```c#
// Erstelle leere Präsentation
Presentation pres = new Presentation();

// Erstelle ein gruppiertes Säulendiagramm
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Füge exponentielle Trendlinie für Diagrammserie 1 hinzu
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Füge lineare Trendlinie für Diagrammserie 1 hinzu
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Füge logarithmische Trendlinie für Diagrammserie 2 hinzu
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Füge gleitende Durchschnitt Trendlinie für Diagrammserie 2 hinzu
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Füge polynomiale Trendlinie für Diagrammserie 3 hinzu
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Füge Potenz Trendlinie für Diagrammserie 3 hinzu
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Speichere Präsentation
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides for .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Holen Sie die Referenz einer Folie über ihren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode des Shapes‑Objekts
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape‑Methode des Shapes‑Objekts hinzu
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was bedeuten 'forward' und 'backward' bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die nach vorne bzw. nach hinten projiziert werden: Für Streudiagramme (XY) — in Achseneinheiten; für Nicht‑Streudiagramme — in Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/)/[SVG](/slides/de/net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Eine Methode ist ebenfalls verfügbar, um ein Bild des Diagramms selbst zu [ein Bild des Diagramms exportieren](/slides/de/net/create-shape-thumbnails/).