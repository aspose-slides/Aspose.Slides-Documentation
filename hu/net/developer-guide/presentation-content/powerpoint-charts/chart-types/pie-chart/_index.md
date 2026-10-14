---
title: Kördiagramok testreszabása prezentációkban .NET-ben
linktitle: Kördiagram
type: docs
url: /hu/net/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet színe
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kördiagramok létrehozása és testreszabása .NET-ben az Aspose.Slides használatával. Másodlagos ábrákat konfigurál, adatcímkéket jelenít meg, és automatikus szelet színeket alkalmaz a PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides alkalmazásban. Bemutatja, hogyan lehet konfigurálni a másodlagos ábrázolási beállításokat a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szelet‑színezés egy szabványos kördiagramon.

Az példák a diagram testreszabási feladatokra összpontosítanak, mint például diagram hozzáadása egy diára, sorozatok és címkék beállításainak módosítása, az alapértelmezett diagramadatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a módosított bemutató mentése.

## **Másodlagos ábra beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Aspose.Slides for .NET támogatja a Pie of Pie és Bar of Pie diagramok másodlagos ábrázolási beállításait. Ezek a beállítások szabályozzák a másodlagos ábra méretét és azt, hogy a adatpontok hogyan oszlanak meg a két ábra között.

Az alábbi példa egy Pie of Pie diagramot hoz létre egy új bemutatóban, és az adatpont értékeket címkeként jeleníti meg. A [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) tulajdonság a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) százalék‑alapú felosztást választ, és a [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) a küszöböt 53%-ra állítja.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Válassza ki a kategóriákat a másodlagos ábrához**

Használjon egyéni felosztást, ha bizonyos kategóriákat a másodlagos ábrában szeretne csoportosítani a százalékos értékük függetlenül. Például egy értékesítési jelentésben az Online és az Events csatornákat együtt jelenítheti meg, így az olvasók összehasonlíthatják ezt a két csatornát, még ha a teljes értékesítés 35%-át és 10%-át teszik ki is.

Állítsa a [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) értékét [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/)-ra, és válassza ki a pontokat a [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) segítségével. A gyűjtemény [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) metódusa vagy a sorozat nulla‑alapú indexét, vagy egy adatpont objektumot fogad el. Ebben a példában az 1‑es index az Online‑t választja, a 3‑as index az Events‑et. A Partners is ideiglenesen hozzá van adva, majd a [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) használatával kizárásra kerül.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Cserélje le az alapértelmezett adatokat a csatornák szerinti értékesítéssel.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Válassza ki az Online-ot a nulla alapú indexe szerint, és az Events-et az adatpont objektuma alapján.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Zárja ki a Partners-et a kijelölésből, anélkül hogy törölné a forrásadatait.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Az Online (35) és az Events (10) külön szeletekként jelenik meg a másodlagos ábrában. Az elsődleges ábrában egy közös szeletként, 45 értékkel képviseltetik őket, a Retail (40) és a Partners (15) mellett. A Partners eltávolítása az egyéni kiválasztásból az elsődleges ábrában marad; nem távolítja el a kategóriát vagy az értékét a diagram forrásadataiból.

A következő kép a mentett bemutatót mutatja PowerPointban:

![Pie of Pie diagram az Online és Events szeletekkel a másodlagos ábrában, és azok kombinált 45-ös értéke az elsődleges ábrában](pie_of_pie_custom.png)

## **Állítsa be az automatikus kördiagram szelet színeket**

Aspose.Slides for .NET képes automatikusan különböző színeket rendelni a kördiagram szeleteihez. Az alábbi példa egy középre igazított címmel rendelkező kördiagramot hoz létre, és az alapértelmezett adatokat három negyedéves kategóriával és azok értékeivel helyettesíti. A [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) tulajdonság a 20, 50 és 30 értékeket jeleníti meg címkeként, míg az [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) engedélyezi, hogy minden szeletnek eltérő színe legyen.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Add a centered chart title.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Replace the default data using the first worksheet.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Show values and assign different colors to the slices.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) egy másodlagos ábrát a kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a [exportálhatja a diagramot képként](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (például PNG) anélkül, hogy az egész bemutatót exportálná.