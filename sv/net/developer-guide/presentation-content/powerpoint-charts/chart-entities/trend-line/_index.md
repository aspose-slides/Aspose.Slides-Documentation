---
title: Lägg till trendlinjer i presentationsdiagram i .NET
linktitle: Trendlinje
type: docs
url: /sv/net/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärde trendlinje
- polynomisk trendlinje
- potens trendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för .NET — en praktisk guide för att engagera din publik."
---
## **Overview**

Denna artikel förklarar hur man lägger till trendlinjer i presentationsdiagram med Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer till diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga en linjeform, samt innehåller en kort FAQ om framåt‑ och bakåtriktade trendlinje‑projektioner samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Add a Trend Line**
Aspose.Slides for .NET provides a simple API for managing different chart Trend Lines:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en slids referens via dess index.
3. Lägg till ett diagram med standarddata samt någon av önskade typer (detta exempel använder ChartType.ClusteredColumn).
4. Lägg till en exponentiell trendlinje för diagramserie 1.
5. Lägg till en linjär trendlinje för diagramserie 1.
6. Lägg till en logaritmisk trendlinje för diagramserie 2.
7. Lägg till en glidande medelvärdestrendlinje för diagramserie 2.
8. Lägg till en polynomisk trendlinje för diagramserie 3.
9. Lägg till en potenstrendlinje för diagramserie 3.
10. Skriv den modifierade presentationen till en PPTX‑fil.

The following code is used to create a chart with Trend Lines.

```c#
// Skapar tom presentation
Presentation pres = new Presentation();

// Skapar ett diagram med grupperade kolumner
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Lägger till exponentiell trendlinje för diagramserie 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Lägger till linjär trendlinje för diagramserie 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Lägger till logaritmisk trendlinje för diagramserie 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Lägger till glidande medelvärde trendlinje för diagramserie 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Lägger till polynomisk trendlinje för diagramserie 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Lägger till potens trendlinje för diagramserie 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Sparar presentationen
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Add a Custom Line**
Aspose.Slides for .NET provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en slide genom att använda dess Index
- Skapa ett nytt diagram med metoden AddChart som erbjuds av objektet Shapes
- Lägg till en AutoShape av typ Linje med metoden AddAutoShape som erbjuds av objektet Shapes
- Ställ in färgen på formens linjer.
- Skriv den modifierade presentationen som en PPTX‑fil

The following code is used to create a chart with Custom Lines.

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

**What do 'forward' and 'backward' mean for a trendline?**

Vad betyder 'forward' och 'backward' för en trendlinje?

De är längderna på trendlinjen som projiceras framåt/bakåt: för spridningsdiagram (XY) — i enhetsvärden på axlarna; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Will the trendline be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Kommer trendlinjen att bevaras när presentationen exporteras till PDF eller SVG, eller när en slide renderas till en bild?

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/net/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exporta en bild av diagrammet](/slides/sv/net/create-shape-thumbnails/) själv.