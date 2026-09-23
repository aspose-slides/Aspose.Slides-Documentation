---
title: Diagram adatcímkék kezelése PowerPoint előadásokban .NET környezetben
linktitle: Adatcímke
type: docs
url: /hu/net/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint előadásokhoz az Aspose.Slides for .NET használatával, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék a diagram soraira és egyes adatpontokra vonatkozó információkat jelenítik meg, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatja az értékeket, jelenítheti meg a százalékokat, olvashatja el a címkeszöveget, állíthatja be a kategória tengely címkéinek távolságát, és helyezheti el a kördiagram címkéit.

## **Az adatcímkék pontosságának beállítása a diagramon**

Használja a [NumberFormatOfValues](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/numberformatofvalues/) függvényt a sorozatok értékeinek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozatra. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki az egyes értékeket a kategória összegének százalékaként, és rendelje hozzá a szöveget a [TextFrameForOverriding](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) elemhez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja a nullával való osztás elkerülése érdekében. Ha a diagram adatai megváltoznak, számolja újra az egyedi címkeszöveget.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Százalékjel beállítása diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [NumberFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabelformat/numberformat/) függvényt a százalékok megjelenítéséhez. Állítsa az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) értékét `false`-ra, hogy a címkeformátum függetlenül alkalmazható legyen a forráscelláktól.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum 0.30-at 30.0%-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Az adatcímkék tényleges szövegének lekérdezése**

Használja a [GetActualLabelText](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabel/getactuallabeltext/) függvényt az adatcímke beállításai által előállított szöveg lekérésére. Ez akkor hasznos, ha címkéket von ki jelentésekhez, a bemutató tartalmát keresik, vagy a generált diagramokat ellenőrzik. Az alábbi példában az alapértelmezett [adatcímke-formátum](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabelformat/) egyesíti a kategórianév, a sorozatnév és az érték minden egyes elemét. Egy pont az értékét százalékként formázza, egy másik a [TextFrameForOverriding](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) egyéni szövegét használja.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

A adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot jelenít a kategória és a sorozat nevével együtt. Az egyéni szöveg felülírja a generált címkét. A [GetActualLabelText](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabel/getactuallabeltext/) mindkét esetben visszaadja a kapott címkeszöveget. Ellenőrizze külön az [IsVisible](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabel/isvisible/) állapotot, ahogy fentebb látható, ha csak a látható címkéket szeretné kinyerni.

## **Címke távolságának beállítása a tengelytől**

A [LabelOffset](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/iaxis/labeloffset/) használatával szabályozhatja a kategória tengely címkéi és a tengely közti távolságot. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengely címkéire hat, nem pedig az egyes adatpontokhoz tartozó címkékre.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Címke helyének módosítása**

Egy kördiagramon módosítsa az adatcímkék pozícióját a térköz javítása és a vezető vonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülre helyezi, és beállítja az [X](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ilayoutable/y/) eltolásait. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Kördiagram az igazított adatcímke helyzettel](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan előzhetem meg az adatcímkék átfedését sűrű diagramokon?**

Használjon automatikus címkeelhelyezést, vezető vonalakat és kisebb betűméretet; szükség esetén rejtsen el egyes mezőket (például a kategóriát), vagy csak extrém értékekhez vagy kulcspontokhoz jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje ki az adatpontokat a címkék engedélyezése előtt, és a meghatározott szabály alapján kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékeknél.

**Hogyan biztosíthatom, hogy a címkék stílusa következetes legyen PDF/ képek exportálásakor?**

Állítsa be kifejezetten a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje a helyettesítő betűtípust.