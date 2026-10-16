---
title: "Lägg till trendlinjer i presentationsdiagram i .NET"
linktitle: "Trendlinje"
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
## **Översikt**

Denna artikel förklarar hur man lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga en linjepolygon, och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjeprojektioner samt huruvida trendlinjer bevaras vid export till PDF eller SVG och när diagram ritas som bilder.

## **Lägg till en trendlinje**

Använd [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) för att lägga till en trendlinje i en diagramserie, och välj dess typ med [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Exemplet skapar ett stapeldiagram med klustrade kolumner med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R‑kvadrat‑värde via [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) och [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) för en anpassad etikett. Det glidande medelvärdet använder en [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) på tre datapoäng och ett anpassat [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Den polynomiska trendlinjen har ett [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) på tre och sträcker sig en kategori framåt via [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Den potensbaserade trendlinjen sträcker sig en kategori bakåt via [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

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

## **Ställ in trendlinjens intercept**

Använd [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) för att låsa en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Till exempel kan en produktionskostnadsmodell behöva starta med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktionsvolymer antyder en annan baslinje. För en linjär trendlinje begränsar fixering av interceptet ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningarna för axelöverskridning styr var diagramaxlarna möts, inte koefficienterna för den anpassade trendlinjen.

Följande exempel skapar ett spridningsdiagram (XY) med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardinställning för automatiskt intercept, sätter interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i interceptinställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

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

Med automatisk beräkning ger dessa data `y = 30x + 140`. Att sätta interceptet till 100 istället ger ungefär `y = 43.33x + 100`: det anpassade värdet vid noll matchar den kända baslinjen, medan linjen inte längre passerar genom varje datapunkt.

| Automatiskt intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med ett automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med ett fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axiell skala. Trendlinjerna sträcks tillbaka till X = 0 för att visa deras intercept.

Som standard innehåller egenskapen `double.NaN`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från data.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas över diagrammet snarare än en trendlinje beräknad från seriedata. Detta exempel använder [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) för att lägga till en horisontell linje på bilden ovanför diagrammet. Linjens position anges i bildkoordinater, mätta i punkter, så den börjar vid diagrammets vänstra kant och ligger halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) ger linjen en solid röd färg.

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

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt/bakåt: för spridningsdiagram (XY) — i axelenheter; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/net/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/net/create-shape-thumbnails/) själv.