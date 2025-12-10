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
- Gleitende Durchschnittstrendlinie
- polynomiale Trendlinie
- Potenztrendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien zu PowerPoint-Diagrammen mit Aspose.Slides für .NET hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---

## **Trendlinie hinzufügen**
Aspose.Slides für .NET stellt eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien bereit:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten sowie einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Hinzufügen einer exponentiellen Trendlinie für Diagrammserie 1.
5. Hinzufügen einer linearen Trendlinie für Diagrammserie 1.
6. Hinzufügen einer logarithmischen Trendlinie für Diagrammserie 2.
7. Hinzufügen einer gleitenden Mittelwert‑Trendlinie für Diagrammserie 2.
8. Hinzufügen einer polynomialen Trendlinie für Diagrammserie 3.
9. Hinzufügen einer Potenz‑Trendlinie für Diagrammserie 3.
10. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```c#
// Leere Präsentation erstellen
Presentation pres = new Presentation();

// Erstellen eines gruppierten Säulendiagramms
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Hinzufügen einer exponentiellen Trendlinie für Diagrammserie 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Hinzufügen einer linearen Trendlinie für Diagrammserie 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Hinzufügen einer logarithmischen Trendlinie für Diagrammserie 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Hinzufügen einer gleitenden Mittelwert-Trendlinie für Diagrammserie 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Hinzufügen einer polynomialen Trendlinie für Diagrammserie 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Hinzufügen einer Potenz-Trendlinie für Diagrammserie 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Präsentation speichern
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Erhalten Sie die Referenz einer Folie über ihren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode, die vom Shapes‑Objekt bereitgestellt wird
- Fügen Sie mit der AddAutoShape‑Methode, die vom Shapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Linie hinzu
- Legen Sie die Farbe der Formlinien fest.
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

**Was bedeuten ‘forward’ und ‘backward’ bei einer Trendlinie?**

Sie geben die Länge der Trendlinie an, die nach vorne bzw. nach hinten projiziert wird: Für Streudiagramme (XY) in Achsen­einheiten; für Nicht‑Streudiagramme in der Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/)/[SVG](/slides/de/net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien werden als Teil des Diagramms bei diesen Vorgängen beibehalten. Außerdem steht eine Methode zum [Exportieren eines Bildes des Diagramms](/slides/de/net/create-shape-thumbnails/) zur Verfügung.