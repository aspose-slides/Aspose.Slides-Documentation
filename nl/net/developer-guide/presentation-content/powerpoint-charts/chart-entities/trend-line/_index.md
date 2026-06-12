---
title: Trendlijnen toevoegen aan presentatiediagrammen in .NET
linktitle: Trendlijn
type: docs
url: /nl/net/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-diagrammen met Aspose.Slides voor .NET — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe je trendlijnen aan presentatiediagrammen kunt toevoegen met Aspose.Slides. Het laat zien hoe je een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe je een aangepaste lijn aan een diagram toevoegt door een lijnvorm in te voegen, en bevat een korte FAQ over de waarden voor voorwaartse en achterwaartse projectie van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Een trendlijn toevoegen**
Aspose.Slides for .NET biedt een eenvoudige API voor het beheren van verschillende diagram‑trendlijnen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType.ClusteredColumn gebruikt).
1. Voeg een exponentiële trendlijn toe voor diagramreeks 1.
1. Voeg een lineaire trendlijn toe voor diagramreeks 1.
1. Voeg een logaritmische trendlijn toe voor diagramreeks 2.
1. Voeg een voortschrijdende‑gemiddelde‑trendlijn toe voor diagramreeks 2.
1. Voeg een polynomiale trendlijn toe voor diagramreeks 3.
1. Voeg een machts‑trendlijn toe voor diagramreeks 3.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De volgende code wordt gebruikt om een diagram met trendlijnen te maken.

```c#
// Lege presentatie maken
Presentation pres = new Presentation();

// Een gegroepeerde kolomdiagram maken
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Exponentiële trendlijn toevoegen voor diagramreeks 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Lineaire trendlijn toevoegen voor diagramreeks 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Logaritmische trendlijn toevoegen voor diagramreeks 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Voortschrijdend gemiddelde trendlijn toevoegen voor diagramreeks 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Polynomiale trendlijn toevoegen voor diagramreeks 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Machts trendlijn toevoegen voor diagramreeks 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Presentatie opslaan
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Een aangepaste lijn toevoegen**
Aspose.Slides for .NET biedt een eenvoudige API om aangepaste lijnen in een diagram toe te voegen. Volg de onderstaande stappen om een eenvoudige rechte lijn aan een geselecteerde dia van de presentatie toe te voegen:

- Maak een instantie van de Presentation‑klasse
- Verkrijg de referentie van een dia met behulp van de Index
- Maak een nieuw diagram met de AddChart‑methode van het Shapes‑object
- Voeg een AutoShape van het type Line toe met de AddAutoShape‑methode van het Shapes‑object
- Stel de kleur van de vormlijnen in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

De volgende code wordt gebruikt om een diagram met aangepaste lijnen te maken.

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

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die respectievelijk naar voren en naar achteren geprojecteerd worden: voor spreidings‑(XY‑)diagrammen — in as‑eenheden; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/net/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze operaties. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/net/create-shape-thumbnails/).