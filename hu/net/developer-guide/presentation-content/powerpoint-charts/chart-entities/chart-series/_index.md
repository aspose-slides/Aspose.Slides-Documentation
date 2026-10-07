---
title: Diagram adat sorozatok kezelése prezentációkban .NET-ben
linktitle: Adat sorozatok
type: docs
url: /hu/net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzetcellákat, formázást, átfedést, hézagszélességet és negatív értékeket prezentációkban C#-val."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagramadat-munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozatban lévő minden [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenítési szövegként tárolódnak.

Tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)‑nek átadott munkalap-, sor- és oszlopindexek nullával kezdődnek. Ez a felépítés akkor hasznos, amikor egy diagramot alapértelmezett adatokkal hoz létre, de ne tételezze fel, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző szintet érintenek:

- Sorozat szintű beállítások, például az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) biztosítja az alapértelmezett megjelenést a sorozaton belül minden ponthoz.
- Adatpont szintű beállítások, például az [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) felülírja a sorozat megjelenését egy adott ponton.
- Csoport beállítások a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)‑on keresztül érheti el, ha például átfedés vagy hézagszélesség beállítására van szükség.

Ha nincs kifejezetten beállított pont- vagy sorozatkitöltés, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása élvez elsőbbséget az adott pontra.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) azt jelzi, hogy a 2D diagram oszlopai vagy sávjai mennyire fednek át egymást, -100 és 100 százalék között. Ez csak egy olvasható leképezése a szülő sorozatcsoport beállításának. Állítsa be az [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) értékét, hogy frissítse az összes kompatibilis sorozatot ebben a csoportban. Ez a lehetőség a csoportos oszlop- vagy sávdiagramokra vonatkozik; a kombinációs diagramokhoz nem kapcsolódó sorozatcsoportokat ez nem befolyásolja.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportban:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) használatával állítható be a teljes sorozatra vonatkozó alapértelmezett kitöltés. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott ponton.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy klaszterezett oszlopdiagramhoz jön létre, a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a felépítést:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Frissítheti azt a cellát is, amelyet már az [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) hivatkozik. Ez a megközelítés elkerüli a konkrét sor- és oszlopszám feltételezését egy meglévő diagram esetén:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The series name](series_name.png)

### **Sorozat létrehozása több cellából álló névvel**

Összetett sorozatnév akkor hasznos, ha egy termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` B1‑ben és a `2026` C1‑ben kombinálható egyetlen sorozatnévvé, miközben mindkét rész továbbra is hivatkozik a forráscellákra.

Használja a [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)‑nek. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák bele legyenek-e vonva: `true` kizárja őket, `false` pedig beleveszi. Ez a példa `false`‑t használ, hogy minden cellát felvegye a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét szolgáltatják; az A2:A3 a kategóriacímkéket, a B2:B3 a numerikus értékeket tartalmazza.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ez a két cella biztosítja a sorozat nevét.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között egy szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból származik:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozatkitöltőszín lekérdezése**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozatindex és a diagramstílus alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódushívás csak a kiszámított színt olvassa, nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

A alapértelmezett diagramstílusra vonatkozó minta kimenet:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagramstílustól és a témától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Oszlop-, sáv- és buborék-sorozatok esetén az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) használatával a negatív értékek másik kitöltéssel jeleníthetők meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa a diagram adatainak helyettesítésével egy sorozatot hoz létre. A munkalap 0. sora tartalmazza a sorozatnevét, az 0. oszlop a kategórianév, az 1. oszlop pedig az értékeket:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverziót egy adott pontra is beállíthatja az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑val. Az alábbi példában a sorozatnál inverzió ki van kapcsolva, csak a kiválasztott pontnál van engedélyezve. A pontot negatív értékkel is ellátjuk, hogy a hatás látható legyen:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Egy adott adatpont értékének törlése**

Egy pont kiürítéséhez a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)‑on keresztül érhető el. Az adatpont a ugyanazon kategória pozícióban marad, de a diagram a beállított üres-érték opciók szerint a pontot üresnek tekinti.

Az alábbi példa csak a második pontot törli az első sorozatban:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok emellett egy méretcellát is. Csak azt a cellát törölje, amely a ténylegesen eltávolítandó értéket tartalmazza. Ne hívja meg a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t, ha a többi pontot megtartja, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett, de értéket tartalmazó cellák külön esetet képeznek az üres celláktól. A rejtett munkalapsorok és oszlopok adatainak belefoglalásáról vagy kizárásáról lásd a [Include Data from Hidden Rows and Columns](/slides/hu/net/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzetcellát hiányzó adatként kezelünk; egy `0` értékű cella ismert numerikus értéket jelent. Állítsa a [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) értékét `null`‑ra, hogy a cella üres legyen. A numerikus nulla minden esetben null marad, függetlenül az üres cella beállítástól.

Használja az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)‑t annak kiválasztására, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik, és megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül hogy a munkafüzetcellát nullára vagy interpolált értékre töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módot elment a diagramra. Bemeneti fájlra nincs szükség. Az [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot használja a kategóriacímkéknek, az 1‑s oszlopot az értékeknek; a 0‑s sor a sorozatnevet tartalmazza. A végső adat: `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontját.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verzióra van szüksége, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus végrehajtása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típustól függ. Egy vonaldiagram jól összehasonlítható mindhárom módot. Oszlop- és sávdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem hoz létre összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy szórt diagram csak jelölőkkel nincs összekötő vonala. Ne várjon három különálló eredményt minden diagramtípusra; ellenőrizze a kimenetet az adott típusra vonatkozóan.

## **A sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszlopcsoportok közötti térköz, amely a sáv vagy oszlop szélességének százalékában van kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoport szintjén van, nem egyetlen sorozatnál. Állítsa be egyszer a [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) értékét a csoport számára. A nagyobb érték nagyobb távolságot hoz létre a csoportok között; a kisebb érték sűrűbb klasztereket eredményez.

Az alábbi példa módosítja a hézagszélességet, és csak a végső prezentációt menti el:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem mindegyiknek azonos értékstruktúrája vagy beállítása. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípusnak megfelelő adatpont létrehozási módszert. Az olyan opciók, mint az átfedés és a hézagszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül érinti a diagram minden sorozatát.

**Egy újonnan létrehozott diagram tartalmaz-e alapértelmezett adatokat?**

Igen. Alapértelmezés szerint az [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, a kategória címkék és az adatpont értékek az [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a megfelelő kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot anélkül, hogy az egész sorozatot törölném?**

Állítsa a releváns értékcellát `null`‑ra, hogy a pont kategóriahelye megmaradjon üres pontként. A [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t csak akkor használja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, minden sorozatot frissítenie kell, hogy értékeik továbbra is a kategória‑gyűjteménnyel legyenek összhangban.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik az üresekülött hézagokként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a prezentációjában a hiányzó adat jelentésének megfelelő beállítást. Tekintse meg az [Az üres cellák megjelenítésének szabályozása](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék‑sorozatok esetén engedélyezze az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)‑t, és állítsa be az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑t. Egy adott pont viselkedését felülírhatja az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑val. Ezek a tulajdonságok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás elsőbbséget élvez az adott pontra. A többi pont továbbra is a kifejezett sorozat‑formázást vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a hézagszélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van-e határ arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, rögzített sorozatszám‑korlátot. Gyakorlatilag a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg az ésszerű határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoport [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) értékét. Növelje az értéket a csoportok közötti térköz bővítéséhez, vagy csökkentse azt a csoportok közelebb hozásához.