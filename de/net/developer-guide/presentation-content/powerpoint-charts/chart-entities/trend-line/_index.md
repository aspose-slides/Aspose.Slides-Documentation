---
title: Trendlinien zu Präsentationsdiagrammen in .NET hinzufügen
linktitle: Trendlinie
type: docs
url: /de/net/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- gleitende Mittelwerttrendlinie
- polynomiale Trendlinie
- Potenz‑Trendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für .NET schnell hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---

## **Trendlinie hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten sowie einem gewünschten Diagrammtyp hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Fügen Sie eine exponentielle Trendlinie für Diagrammreihe 1 hinzu.
5. Fügen Sie eine lineare Trendlinie für Diagrammreihe 1 hinzu.
6. Fügen Sie eine logarithmische Trendlinie für Diagrammreihe 2 hinzu.
7. Fügen Sie eine gleitende Mittelwert‑Trendlinie für Diagrammreihe 2 hinzu.
8. Fügen Sie eine polynomiale Trendlinie für Diagrammreihe 3 hinzu.
9. Fügen Sie eine Potenz‑Trendlinie für Diagrammreihe 3 hinzu.
10. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```c#
// Leere Präsentation erstellen
Presentation pres = new Presentation();

// Ein gruppiertes Säulendiagramm erstellen
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Exponentielle Trendlinie für Diagrammreihe 1 hinzufügen
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Lineare Trendlinie für Diagrammreihe 1 hinzufügen
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Gleitende Durchschnittstrendlinie für Diagrammreihe 2 hinzufügen
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Polynomiale Trendlinie für Diagrammreihe 3 hinzufügen
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Power-Trendlinie für Diagrammreihe 3 hinzufügen
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Präsentation speichern
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Holen Sie die Referenz einer Folie anhand ihres Index
- Erstellen Sie ein neues Diagramm mithilfe der AddChart‑Methode, die vom Shapes‑Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape‑Methode hinzu, die vom Shapes‑Objekt bereitgestellt wird
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.
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

Sie sind die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: Für Streudiagramme (XY) – in Achseneinheiten; für Nicht‑Streudiagramme – in Kategorienzahlen. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie in ein Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/net/convert-powerpoint-to-pdf/)/[SVG](/slides/de/net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien bleiben als Teil des Diagramms bei diesen Vorgängen erhalten. Außerdem steht eine Methode zur Verfügung, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/net/create-shape-thumbnails/).