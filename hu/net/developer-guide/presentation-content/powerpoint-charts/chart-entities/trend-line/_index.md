---
title: Trendvonalak hozzáadása a prezentáció diagramokhoz .NET-ben
linktitle: Trendvonal
type: docs
url: /hu/net/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Gyorsan adjon hozzá és testre szabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for .NET segítségével — egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat trendvonalakat a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhat létre diagramot, adhat trendvonalakat a diagram sorozataihoz, és hogyan dolgozhat többféle trendvonal típussal, többek között exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány.

Leírja továbbá, hogyan adhat egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-ot a trendvonalak előre és hátra projekciós értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e PDF vagy SVG exportálásakor, illetve a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**

Használja az [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) metódust egy trendvonal hozzáadásához egy diagram sorozatához, a típus kiválasztásához pedig a [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) használható. A példában egy csoportosított oszlopdiagramot hoz létre alapértelmezett adatokkal, és két trendvonalat ad hozzá mindhárom sorozatához.

Az exponenciális trendvonal elrejti egyenletét és az R‑négyzet értékét a [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) és a [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/)‑t használja egy egyéni címkéhez. A mozgó átlag a három adatpontból álló [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) értéket és egy egyéni [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/)‑t használ.

A polinomiális trendvonal [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) értéke három, és egy kategóriával előre nyúlik a [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) használatával. A hatvány trendvonal egy kategóriával hátra nyúlik a [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) segítségével.

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

## **Trendvonal metszéspont beállítása**

Használja az [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) metódust a trendvonal Y értékének X = 0‑nál rögzítéséhez. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalak esetén.

Például egy termelési költségmodellnek a 100 ismert rögzített költségnél kellene indulnia, még akkor is, ha a nemnulla termelési mennyiségek mérései más kiindulási értéket sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése a `y = ax + b` egyenletet `b = 100`‑ra korlátozza; a meredekség a korlátozás mellett illeszkedik az adatokhoz. Ez nem egyszerűen csak áthelyezi a már illesztett vonalat. A tengelykeresztezési beállítások szabályozzák, hol találkozik a diagram tengelye, nem pedig a trendvonal együtthatóit.

A következő példa egy szórás (XY) diagramot hoz létre 1‑től 4‑ig terjedő termelési mennyiségekkel és 170, 200, 230 és 260 költségekkel. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100‑ra, és egy második PPTX fájlt ment. A két fájl csak a metszéspont beállításában különbözik. A trendvonal megjeleníti egyenletét és visszanyúlik X = 0‑ig.

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

Automatikus számítás esetén ezek az adatok `y = 30x + 140`‑at adnak. A metszéspont 100‑ra állítása helyette körülbelül `y = 43.33x + 100`‑at eredményez: a nulla pontban illesztett érték megegyezik a ismert kiindulási értékkel, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | 100‑as rögzített metszéspont |
| --- | --- |
| ![Lineáris trendvonal automatikusan számított 140‑es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal 100‑as rögzített metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazt az adatot és tengelyskálát használja. A trendvonalak visszanyúlnak X = 0‑ig, hogy megmutassák metszéspontjaikat.

Alapértelmezés szerint a tulajdonság `double.NaN` értéket tartalmaz, amely nem meghatározott metszéspontot jelöl, nem pedig nullát. A metszéspont ezután automatikusan számítódik ki az adatokból.

## **Egyéni vonal hozzáadása**

Az egyéni vonal egy alakzat, amely a diagram felett kerül lerajzolásra, nem pedig a sorozat adataiból számított trendvonal. Ez a példa a [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) metódust használja egy vízszintes vonal hozzáadásához a diára a diagram felett. A vonal pozíciója a dia koordinátáiban van meghatározva, pontban mérve, így a diagram bal szélén kezdődik és a diagram felére lejjebb helyezkedik el. Szélessége megegyezik a diagram szélességével. A [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) szilárd piros színt ad a vonalnak.

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

## **GYIK**

**Mit jelentenek a 'forward' és a 'backward' egy trendvonal esetén?**

Ez a trendvonal előre/hátra projektált hosszát jelenti: szórás (XY) diagramok esetén – tengelyegységekben; nem‑szórás diagramok esetén – kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba való exportálásakor, vagy a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/net/convert-powerpoint-to-pdf/)‑re vagy [SVG](/slides/hu/net/render-a-slide-as-an-svg-image/)‑re konvertálja, és diagramokat képekké rendereli; a trendvonalak a diagram részeként ezek során megmaradnak. Egy metódus is elérhető a [a diagram képének exportálása](/slides/hu/net/create-shape-thumbnails/) számára.