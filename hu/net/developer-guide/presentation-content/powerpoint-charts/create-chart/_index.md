---
title: PowerPoint prezentációdiagramok létrehozása vagy frissítése .NET-ben
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/net/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szétszórt diagram
- kör diagram
- vonal diagram
- fájda diagram
- részvény diagram
- doboz és szakábra diagram
- tölcsér diagram
- napfény diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for .NET használatával. Diagramok hozzáadása, formázása és szerkesztése gyakorlati C# kódtárgyalásokkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides for .NET segítségével. Megtanulhatja, hogyan lehet programozott módon diagramot hozzáadni egy diára, adatokat feltölteni, és különféle formázási beállításokat alkalmazni a specifikus tervezési követelményeknek megfelelően. A cikk során részletes kódtárgyalások mutatják be az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Ennek az útmutatónak a követésével szilárd megértést szerez a dinamikus diagramgenerálás .NET‑alkalmazásokba való integrálásáról, megkönnyítve az adat‑vezérelt előadások létrehozását.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat, és olyan betekintéseket nyerni, amelyek egy táblázatból vagy munkalapból nem azonnal láthatóak.

**Miért érdemes diagramokat létrehozni?**

Diagramok használatával:

* nagy mennyiségű adatot lehet összegyűjteni, sűríteni vagy összefoglalni egyetlen dián egy prezentációban;
* mintákat és trendeket lehet feltárni az adatokban;
* meghatározható az adat iránya és lendülete az idő függvényében vagy egy adott mértékegységhez viszonyítva;
* kiemelhetők a kiugró értékek, eltérések, hibák és értelmetlen adatok;
* összetett adatokat lehet közvetíteni vagy bemutatni.

PowerPointban a *Beszúrás* funkcióval hozhatók létre diagramok, amely számos sablont biztosít a különböző diagramtípusok tervezéséhez. Az Aspose.Slides segítségével mind szabványos, mind egyedi diagramok hozhatók létre.

{{% alert color="info" title="Note" %}}
Használja a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolást a [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) névtérben. Ennek a felsorolásnak az értékei a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy csoportosított oszlopdiagram létrehozásához, amely két sorozatot hasonlít össze három kategóriában. A sorozatok piros és zöld kitöltést kapnak, az egyedi címkék pedig a kategória neveket, sorozat neveket és értékeket jelenítik meg. A 0‑s munkalap index az beágyazott diagram munkafüzetének első lapjára mutat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A csoportosított oszlopdiagram](clustered_column_chart.png)

### **Szétszórt diagramok létrehozása**

A szétszórt diagramok (más néven pontdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szétszórt diagramot, ha:

* párosított numerikus adatai vannak;
* két változó jól párosítható egymással;
* meg szeretné határozni, hogy a két változó kapcsolatban áll‑e;
* egy független változó több értékkel rendelkezik egy függő változóhoz képest.

Ez a példa két x‑y értékkészletet ábrázol. Az első sorozat egyenes vonalakkal és csillagmarkerekkel jelenik meg, míg a második sima vonalakkal és körmarkerekkel; mindkettő 10‑es [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) mérettel rendelkezik. A [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) tulajdonság vezérli a marker alakját.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szétszórt diagram](scatter_chart.png)

### **Kördiagramok létrehozása**

A kördiagramok leginkább a részek‑a‑teljes egész arányának bemutatására alkalmasak, különösen akkor, ha az adatok kategóriákat numerikus értékekkel párosítanak. Ha az adatok sok részt vagy címkét tartalmaznak, érdemes sávdiagramot használni.

Ez a példa három negyedévi értékkel ellátott kördiagramot hoz létre. Minden szelet egyedi kitöltést és keretet kap, a címkék különböző kombinációkban jelenítik meg az értékeket, százalékokat és sorozatinformációkat. A [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) tulajdonság az első szeletet 180 fokra állítja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A kördiagram](pie_chart.png)

A körön belüli címkék olvashatóságának javításához tekintse meg a [Formázás vezetővonalak](/slides/hu/net/chart-data-label/#format-leader-lines) példát, amely a címkék pozicionálását és a vonalak színét, szélességét, átlátszóságát és szaggatott stílusát mutatja be.

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használandók, ahol az értékek időbeli változását szeretné bemutatni. Egy vonaldiagram segítségével nagy mennyiségű adatot lehet egyszerre összehasonlítani, nyomon követni az időbeli változásokat és trendeket, kiemelni az anomáliákat az adatsorokban, és még sok mást.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy vonaldiagram létrehozásához az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX formátumban menti a prezentációt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folyamatos vonallal vannak összekötve. Ha a pontokat szaggatott vonallal szeretné összekötni, állítsa a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) értékét a [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) egyikére:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Az eredmény:

![A vonaldiagram](line_chart.png)

### **Fájfa diagramok (Tree Map) létrehozása**

A fájda diagramok leginkább értékesítési adatok esetén használandók, amikor a felhasználónak a kategóriák relatív méretét kell megjeleníteni, és gyorsan fel kell hívni a figyelmet az egyes kategóriákban nagy hozzájáruló elemekre.

Ez a példa egy fájda diagramot hoz létre nyolc levéllel, amely négy szárra és két ágra van csoportosítva. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus az 1‑es csoportosítási szinthez rendeli a szárakat, a 2‑es szinthez pedig az ágakat. Az értékek határozzák meg a relatív téglalapméreteket, míg a kategória‑címkék és a szülőcímkék jelzik a hierarchiát.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ág 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Ág 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A fájda diagram](treemap_chart.png)

### **Vízesés diagramok (Waterfall) létrehozása**

A vízesés diagram azt mutatja, hogy a pozitív és negatív változások hogyan járulnak hozzá a végső értékhez. Például egy nyereséggörbe a bevételtől indul, levonja a költségeket, és hozzáad egyéb jövedelmeket. A változási oszlopok az előző és az új futó értékek között lebegnek, míg az összesítő oszlopok a nullától az akkumulált értékig terjednek.

Az alábbi példa ezer amerikai dollárban megadott összegeket használ:

| Kategória | Munkafüzet érték | Oszlop típusa |
| --- | ---: | --- |
| Bevétel | 1000 | Növekedés |
| Eladási költség | -400 | Csökkenés |
| Bruttó nyereség | 600 | Köztes összeg |
| Működési költség | -200 | Csökkenés |
| Egyéb jövedelem | 50 | Növekedés |
| Nettó nyereség | 450 | Végső összeg |

Az adott pont köztes vagy végső összegnek jelöléséhez állítsa be a [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) tulajdonságát **true**‑ra. Adja meg a tényleges akkumulált összeget a pont munkafüzetcellájában: `600` a bruttó nyereséghez (`1000 - 400`) és `450` a nettó nyereséghez (`600 - 200 + 50`). A tulajdonság csak megjelöli az oszlopot összegként; nem számolja ki vagy tölti ki a cellaértéket. Ne használjon nullát helyőrzőként, és ne adjon meg más változást egy összegponthoz. Egy összegoszlop az akkumulált értéket mutatja, anélkül, hogy újra hozzáadná a futó értékhez.

Ez a teljes C# példa a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) `Waterfall` tagját használja, törli az alapértelmezett adatokat, és feltölti a beágyazott munkafüzetet. A `0`‑s munkalap index a első munkalapot választja; az A oszlop a kategórianév, a B oszlop az értékek. Minden értékcellát a [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) metódussal adunk hozzá. A nullával kezdődő pontindexek `2` és `5` jelölik a köztes és a végső összegpontokat. A [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezése megjeleníti az összegeket az oszlopokon. Bemutató fájl vagy munkafüzet nem szükséges.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// A harmadik és a hatodik pont összegként jelenik meg, nem további változásként.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Állítsa be a sorozatszintű [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) tulajdonságot **true**‑ra, hogy megjelenjenek a szomszédos oszlopok közti összekötő vonalak, és könnyebben nyomon követhető legyen a futó érték. Ezeknek a vonalaknak a elrejtéséhez cserélje ki a példában a példányosítást a `series.ShowConnectorLines = false;` kódsorra a mentés előtt. Ez csak a vonalak láthatóságát változtatja, az adatokat vagy összegértékeket nem.

Az elmentett prezentáció a 600-as bruttó nyereséget és a 450-es nettó nyereséget mutatja, mindkét összeg nulláról indul:

![A vízesés diagram, amely a bevételt, költségeket, 600-as bruttó nyereséget és 450-as nettó nyereséget mutatja, értékcímkékkel és összekötő vonalakkal](waterfall_chart.png)

### **Részvénydiagramok (Stock) létrehozása**

A részvénydiagramok a nyitó, legmagasabb, legalacsonyabb és záró árak megjelenítésére szolgálnak, segítve a piaci trendek és volatilitás elemzését. Lényeges betekintést nyújtanak a részvény teljesítményébe, támogatva a befektetőket és elemzőket a megalapozott döntések meghozatalában.

Ez a példa egy nyitó‑magas‑alacsony‑záró (OHLC) diagramot hoz létre négy sorozattal ebben a sorrendben és három kategóriával. A [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) tulajdonság engedélyezi a fel/le sávokat, a [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) szabályozza a magas‑alacsony vonalakat, míg az egyes sorozatvonalak és a kisebb vízszintes rácsvonalak rejtve maradnak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A részvénydiagram](stock_chart.png)

### **Doboz‑ és szakábrák (Box and Whisker) létrehozása**

A doboz‑ és szakábrák az adateloszlás megjelenítésére szolgálnak, összefoglalva a kulcsfontosságú statisztikai mutatókat, például a mediánt, kvartiliseket és a lehetséges kiugró értékeket. Különösen hasznosak feltáró adat‑elemzésnél és statisztikai tanulmányokban, hogy gyorsan megértsük az adatok variabilitását és azonosítsuk az anomáliákat.

Ez a példa hat értékkel készült doboz‑ és szakábrát hoz létre. A [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) tulajdonság a kizárólagos kvartilis‑számítást választja. A példa engedélyezi a középérték‑vonalakat, középérték‑marker‑eket, belső pontokat és kiugró pontokat is.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Tölcsérdiagramok (Funnel) létrehozása**

A tölcsérdiagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adatmennyiség csökken a lépésről lépésre. Különösen hasznosak a konverziós arányok elemzéséhez, a szűk keresztmetszetek azonosításához és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követéséhez.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódussal ad egy tölcsérdiagramot egy létező prezentáció első diájához. Lecseréli az alapértelmezett adatokat hat kategóriára és 50‑tól 500‑ig terjedő értékekre, majd elmenti a frissített prezentációt. A bemeneti prezentációnak legalább egy diát kell tartalmaznia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A tölcsérdiagram](funnel_chart.png)

### **Napfénydiagramok (Sunburst) létrehozása**

A napfénydiagramok a hierarchikus adatok vizualizálására szolgálnak, a szinteket koncentrikus gyűringszerűen ábrázolva. Segítenek a rész‑a‑teljes egész kapcsolatok szemléltetésében, és ideálisak a beágyazott kategóriák és alkategóriák tiszta, kompakt megjelenítéséhez.

Ez a példa nyolc levélből álló napfénydiagramot hoz létre, amely négy szárra és két ágra van csoportosítva. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus az 1‑es szinthez rendeli a szárakat, a 2‑es szinthez pedig az ágakat. A kategória‑címkék az egyes szegmenseket azonosítják, az értékek pedig a relatív méreteket határozzák meg.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ág 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Ág 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A napfénydiagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok azt mutatják, hogyan oszlanak el a numerikus értékek intervallumok (tömbök) között. Havi jelentések esetén a megrendelés feldolgozási időinek összehasonlításához használjon azonos sávszélességet és küszöbértékeket, hogy az intervallumok konzisztensnek maradjanak és a megoszlások könnyebben összehasonlíthatóak legyenek.

Állítsa a vízszintes tengely [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) tulajdonságát a [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/) egyik módjára. A [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) csak a `ByBinWidth` esetén érvényes, a [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) csak a `ByNumberOfBins` esetén. Az `Automatic` használatával a diagram automatikusan választja a sávokat.

#### **Fix sávszélesség használata**

Ez a példa a feldolgozási időket 10 perces intervallumokra csoportosítja, külön sávokkal a 10 perc vagy annál kevesebb, illetve a 40 perc feletti értékekhez. Engedélyezze ezeket a sávokat a [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) és a [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/) beállításával. Amikor explicit [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) és [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) küszöböket ad meg, állítsa az [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) és az [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) értékét **false**‑ra.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

A PowerPoint‑ban megjelenő prezentáció a **3, 4, 4, 4 és 2** sávszámot mutatja. Az alulfolyó sáv tartalmazza a `5, 10, 10` értékeket, ezért a küszöb befogadó. A felülfolyó sáv csak a `41, 50` értékeket tartalmazza, ezért kizáró; a `40` érték mindkét esetben az előző intervallumba kerül. A belső sávok az alsó határnál nagyobb, a felső határnál kisebb vagy egyenlő értékeket tartalmazzák.

![Hisztogram 10 perces sávszélességgel és explicit alul‑ és felülfolyó küszöbökkel](histogram_bin_width.png)

#### **A sávok számának megadása**

Rögzített részletességi szint helyett a fix intervallumok helyett kérjen öt sávot ugyanarra az adatra. Ez a példa letiltja az alul‑ és felülfolyó sávokat. A diagram a szélességet az adat‑tartományból számolja, így a határok a jelentések között változhatnak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Az öt sáv **4, 4, 4, 4 és 1** darab elemet tartalmaz. Hasonlítsa össze ezt az eloszlást a fenti fix‑szélességű eredménnyel: a bemeneti értékek azonosak, csak a határok különböznek.

![Hisztogram öt sávval, amely ugyanabból az adathalmazból számolták ki](histogram_bin_count.png)

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatokat jelenítenek meg kétdimenziós formátumban, lehetővé téve több változó egyszerre történő könnyű összehasonlítását. Különösen hasznosak minták, erősségek és gyengeségek felderítésére több teljesítménymutató vagy attribútum esetén.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy radar diagram létrehozásához az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Többkategóriás diagramok létrehozása**

A többkategóriás diagramok olyan adatokat jelenítenek meg, amelyek egy vagy több kategóriacsoportot tartalmaznak, lehetővé téve az értékek több dimenzióban történő egyszerre történő összehasonlítását. Különösen hasznosak összetett, több rétegből álló adathalmazok trendjeinek és kapcsolataiknak elemzésénél.

Ez a példa egy csoportosított oszlopdiagramot hoz létre nyolc kategóriával, négy párban rendezve. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus minden párnak közös címkét ad az 1‑es csoportosítási szinten, így a tengely mind egyedi, mind csoportcímkéket tartalmaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A többkategóriás diagram](multi_category_chart.png)

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatok vizualizálására szolgálnak, az információkat konkrét helyekhez (országok, államok, városok) rendelve. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzésére, egyértelmű és vizuálisan vonzó módon.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódussal hoz létre egy alapértelmezett földrajzi adatokkal rendelkező térkép diagramot, és PowerPointban megtekinthető formában menti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A térkép diagram](map_chart.png)

{{% alert color="info" title="Note" %}}
A fenti kép a mentett prezentációt mutatja megnyitva PowerPointban. Az Aspose.Slides helyesen írja a térképdiagramot és annak adatait, de maga a diagram nem kerül megrajzolásra: amikor egy diát, amely ilyen diagramot tartalmaz, képre renderelnek, vagy PDF‑re vagy SVG‑re konvertálnak, a diagramterület üres marad. A dián lévő egyéb alakzatok nem érintettek.
{{% /alert %}}

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a két vagy több adathalmaz közötti különbségeket, segítve a köztük lévő kapcsolatok azonosítását.

![A kombinációs diagram](combination_chart.png)

Ez a példa két csoportosított oszlop sorozatot kombinál egy vonal sorozattal négy kategórián keresztül. Az oszlopok az elsődleges függőleges tengelyt használják, míg a [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) a vonalat a jobb oldali másodlagos függőleges tengelyre helyezi. A segédfüggvények konfigurálják a címet, a jelmagyarázatot, a tengelycímkéket és a rácsvonalakat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Diagramok frissítése**

Az Aspose.Slides for .NET lehetővé teszi a PowerPoint diagramok frissítését a diagramadatok, formázás és stílus módosításával. Ez a funkció egyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék a jelenlegi adatokat és vizuális szabványokat.

Ez a példa frissíti a "My chart" nevű diagramot az első dián egy meglévő prezentációban. Két oszlopos sorozatra van szükség, mindegyik három adatponttal, a kategória‑címkékkel az A oszlopban és a sorozatnevekkel az első munkalap első sorában. A [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) segítségével módosítja a munkafüzetcellákat, frissíti a sorozatértékeket, hozzáad egy harmadik sorozatot, és a [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/) segítségével klaszterezett hengerekké alakítja a diagramot.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Adattartomány beállítása egy diagramhoz**

A már meglévő diagram által használt tartomány megtekintéséhez lásd a [Diagram adat‑tartományának lekérése](/slides/hu/net/chart-workbook/#retrieve-a-charts-data-range) fejezetet.

Az Aspose.Slides for .NET rugalmasságot biztosít, hogy egy munkalap meghatározott adat‑tartományát használja a diagram adatforrásaként. Ez azt jelenti, hogy közvetlenül leképezhet egy munkalap egy részét a diagramra, ezáltal szabályozva, mely cellák járulnak hozzá a diagram sorozataihoz és kategóriáihoz. Ennek eredményeként könnyen frissítheti és szinkronizálhatja diagramjait a legújabb munkalap‑adatokkal, biztosítva, hogy a PowerPoint‑prezentációk naprakész és pontos információkat tükrözzenek.

Ez a példa a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) metódust használja a "My chart" nevű diagram adatforrásának beállításához az első dián egy meglévő prezentációban `Sheet1!A1:B4`‑re. A diagram munkafüzetének tartalmaznia kell azt a munkalapot, és egy feltöltött tartományt, amely első sorban sorozat‑címke, az A oszlopban kategória‑címke, a B oszlopban három érték található.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használatakor minden diagram sorozata automatikusan más‑más alapértelmezett jelölőszimbólumot kap.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy két vonalas sorozatot és egy jelmagyarázatot tartalmazó diagram létrehozásához. A [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) beállítások megtartják a automatikusan hozzárendelt jelölőszimbólumokat. Az első sorozat negatív és hiányzó (`null`) értéket tartalmaz, a második minden kategóriához értéket ad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Milyen diagramtípusok támogatottak az Aspose.Slides for .NET‑ben?**

Az Aspose.Slides for .NET számos diagramtípust támogat, többek között oszlop, vonal, kör, terület, szétszórt, hisztogram, radar és még sok mást. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeknek leginkább megfelelő diagramtípust válassza.

**Hogyan adhatok új diagramot egy diához?**

Diagram hozzáadásához először egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) példányt hoz létre, lekéri a kívánt diát az indexe alapján, majd meghívja a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül a diagramot integrálja a prezentációba.

**Hogyan frissíthetem egy diagram megjelenített adatait?**

Frissítheti egy diagram adatát a [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) elérésével, törölheti az alapértelmezett sorozatokat és kategóriákat, majd hozzáadhatja saját egyedi adatait. Ez lehetővé teszi, hogy programozottan a legújabb adatokat jelenítse meg a diagramon.

**Lehet-e testreszabni a diagram megjelenését?**

Igen, az Aspose.Slides for .NET kiterjedt testreszabási lehetőségeket biztosít. Módosíthat színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb formázási elemeket, hogy a diagram megjelenését az Ön specifikus tervezési követelményeihez igazítsa.