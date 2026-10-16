---
title: Přidání čar trendu do grafů v prezentaci v .NET
linktitle: Čára trendu
type: docs
url: /cs/net/trend-line/
keywords:
- graf
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- čára trendu klouzavého průměru
- polynomická čára trendu
- mocninná čára trendu
- vlastní čára trendu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte čáry trendu v grafech PowerPointu pomocí Aspose.Slides pro .NET — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci čáry trendu. Ukazuje, jak vytvořit graf, přidat čáry trendu do sérií grafu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Dále popisuje, jak přidat do grafu vlastní čáru vložením tvaru čáry, a obsahuje stručné FAQ o hodnotách projekce čar trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání čáry trendu**

Použijte [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) k přidání čáry trendu do série grafu a vyberte její typ pomocí [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě čáry trendu ke každé ze tří sérií.

Exponenciální čára trendu skrývá svou rovnici a hodnotu R‑kvadrátu pomocí [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) a [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), zatímco lineární čára trendu je červená. Logaritmická čára trendu používá [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) pro vlastní popisek. Klouzavý průměr používá [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) se třemi datovými body a vlastní [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Polynomická čára trendu má [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) tři a prodlužuje o jednu kategorii dopředu pomocí [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Mocninná čára trendu prodlužuje o jednu kategorii dozadu pomocí [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

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

## **Nastavení průsečíku čáry trendu**

Použijte [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) k pevné hodnotě Y čáry trendu při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomické čáry trendu.

Například model výrobních nákladů může potřebovat začít u známých fixních nákladů 100, i když měření při nenulových objemech výroby naznačují jiný základ. Pro lineární čáru trendu pevné nastavení průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejedná se pouze o posunutí již navázané čáry. Nastavení průsečíku os řídí, kde se osy grafu setkávají, nikoli koeficienty přizpůsobené čáry trendu.

Následující příklad vytvoří bodový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečíkem, nastaví průsečík na 100 a uloží druhý soubor PPTX. Tyto dva soubory se liší pouze nastavením průsečíku. Čára trendu zobrazuje svou rovnici a prodlužuje se zpět na X = 0.

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

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavení průsečíku na 100 místo toho dává přibližně `y = 43.33x + 100`: přizpůsobená hodnota při nule odpovídá známému základu, zatímco čára již neprochází každým datovým bodem.

| Automatický průsečík | Pevný průsečík 100 |
| --- | --- |
| ![Lineární čára trendu s automaticky vypočteným průsečíkem 140](intercept-automatic.png) | ![Lineární čára trendu s pevným průsečíkem 100](intercept-fixed.png) |

Obě obrázky používají stejná data a měřítka os. Čáry trendu jsou prodlouženy zpět na X = 0, aby ukázaly své průsečíky.

Ve výchozím nastavení vlastnost obsahuje `double.NaN`, což představuje neurčený průsečík místo nuly. Průsečík je pak automaticky vypočten z dat.

## **Přidání vlastní čáry**

Vlastní čára je tvar nakreslený přes graf, nikoli čára trendu vypočtená z dat série. Tento příklad používá [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) k přidání horizontální čáry do snímku nad grafem. Pozice čáry je zadána v souřadnicích snímku, měřených v bodech, takže začíná na levém okraji grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) dává čáře plnou červenou barvu.

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

**Co znamená ‚forward‘ a ‚backward‘ u čáry trendu?**

Jedná se o délky čáry trendu projekcí dopředu/dozadu: u bodových (XY) grafů — v jednotkách os; u ne‑bodových grafů — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace na [PDF](/slides/cs/net/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) a vykresluje grafy jako obrázky; čáry trendu jako součást grafu jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/net/create-shape-thumbnails/).