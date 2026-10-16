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

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over de waarden voor vooruit‑ en achterwaartse projectie van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**

Gebruik [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) om een trendlijn toe te voegen aan een diagramreeks, waarbij u het type selecteert met [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Het voorbeeld maakt een gegroepeerd kolomdiagram met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie reeksen.

De exponentiële trendlijn verbergt zijn vergelijking en R‑kwadraat‑waarde via [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) en [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) voor een aangepast label. Het voortschrijdend gemiddelde gebruikt een [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) van drie gegevenspunten en een aangepaste [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

De polynomiale trendlijn heeft een [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) van drie en strekt één categorie vooruit via [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). De machts trendlijn strekt één categorie achteruit via [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Intercept van een trendlijn instellen**

Gebruik [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) om de Y‑waarde van een trendlijn vast te zetten op X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een productiekostmodel moet mogelijk starten met bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productiewolumes een andere basislijn suggereren. Voor een lineaire trendlijn beperkt het vastzetten van de intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan aangepast aan de gegevens onder die beperking. Het verplaatst niet simpelweg een reeds aangepaste lijn. De instellingen voor het kruisen van assen bepalen waar de assen van het diagram elkaar ontmoeten, niet de coëfficiënten van de aangepaste trendlijn.

Het volgende voorbeeld maakt een spreidingsdiagram (XY) met productiewolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat het diagram op met de standaard automatische intercept, stelt de intercept in op 100, en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de interceptinstelling. De trendlijn toont zijn vergelijking en strekt zich terug uit tot X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Bij automatische berekening leveren deze gegevens `y = 30x + 140`. Het instellen van de intercept op 100 levert in plaats daarvan ongeveer `y = 43.33x + 100`: de aangepaste waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk gegevenspunt gaat.

| Automatische intercept | Vaste intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekende intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vaste intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en as‑schaal. De trendlijnen worden teruggestrekt tot X = 0 om hun intercepts te tonen.

Standaard bevat de eigenschap `double.NaN`, wat een niet‑gespecificeerde intercept betekent in plaats van nul. De intercept wordt vervolgens automatisch berekend uit de gegevens.

## **Aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over het diagram getekend wordt in plaats van een trendlijn die berekend wordt uit reeksen. Dit voorbeeld gebruikt [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) om een horizontale lijn aan de dia boven het diagram toe te voegen. De positie van de lijn wordt gespecificeerd in dia‑coördinaten, gemeten in punten, zodat deze begint bij de linkerrand van het diagram en halverwege het diagram ligt. De breedte komt overeen met de breedte van het diagram. De [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) geeft de lijn een solide rode kleur.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/achteruit geprojecteerd worden: voor spreidingsdiagrammen (XY) — in as‑eenheden; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/net/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, worden behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [een afbeelding van het diagram exporteren](/slides/nl/net/create-shape-thumbnails/).