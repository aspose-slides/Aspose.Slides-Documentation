---
title: PowerPoint előadás diagramok létrehozása vagy frissítése .NET-ben
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
- szórt diagram
- kör diagram
- vonal diagram
- fa térkép diagram
- részvény diagram
- doboz‑ és fészek diagram
- tölcsér diagram
- napfény diagram
- hisztogram diagram
- radar diagram
- több‑kategória diagram
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint előadásokban az Aspose.Slides for .NET segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati C# kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatók létre és testreszabhatók diagramok az Aspose.Slides for .NET segítségével. Megtanulhatja, hogyan adhat programozottan diagramot egy diára, hogyan töltheti fel adatokka­l, és hogyan alkalmazhat különféle formázási lehetőségeket a konkrét tervezési követelményeknek megfelelően. A cikkben részletes kódrészletek szemléltetik minden lépést, az előadás és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázat beállításáig. Az útmutató követésével alaposan megértheti, hogyan integrálhat dinamikus diagramgenerálást .NET-alkalmazásaiba, egyszerűsítve az adatalapú prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan vizualizálni az adatokat és felismerni azokat a meglátásokat, amelyek egy táblázatból vagy munkafüzetből nem azonnal nyilvánvalóak.

**Miért érdemes diagramokat létrehozni?**

Diagramok segítségével:

* nagy mennyiségű adatot aggregálhat, sűríthet vagy összefoglalhat egyetlen dián;
* felfedheti az adatmintákat és trendeket;
* meghatározhatja az adat irányát és lendületét időben vagy egy adott mérőegységhez viszonyítva;
* észlelheti a kiugró, rendellenes vagy hibás adatokat;
* összetett adatokat kommunikálhat vagy prezentálhat.

A PowerPointban a *Beszúrás* funkcióval hozhat létre diagramokat, amely számos sablont kínál a különböző diagramtípusok megtervezéséhez. Az Aspose.Slides segítségével szabályos diagramokat (népszerű típusok alapján) és egyedi diagramokat is létrehozhat.

{{% alert color="info" title="Megjegyzés" %}}
Használja a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolást a [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) névtérben. Ennek az enumerációnak az értékei a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportos oszlopdiagramok létrehozása**

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy csoportos oszlopdiagram létrehozásához, amely két sorozatot hasonlít össze három kategória mentén. A sorozatok piros és zöld kitöltéssel rendelkeznek, az egyes címkék a kategória nevét, a sorozat nevét és az értékeket mutatják. A 0‑s munkalap‑index az ágyazott diagram-munkafüzet első lapjára hivatkozik.

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

![A csoportos oszlopdiagram](clustered_column_chart.png)

### **Szórásdiagramok létrehozása**

A szórásdiagramok (más néven szórási ábrák vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórásdiagramot, ha:

* párhuzamos numerikus adatpárok állnak rendelkezésre;
* két változó jól párosítható egymással;
* meg akarja határozni, hogy a két változó összefügg-e;
* van egy független változó, amely több értéket tartalmaz egy függő változóhoz képest.

Ez a példa két x‑y értékkészletet ábrázol. Az első sorozat egyenes vonalakkal és csillag‑jelzőkkel, a második simított vonalakkal és kör‑jelzőkkel jelenik meg; mindkettő 10‑es [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) értékkel rendelkezik. A [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) tulajdonság a jelző alakját szabályozza.

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

![A szórásdiagram](scatter_chart.png)

### **Kördiagramok létrehozása**

A kördiagramok leginkább a rész‑egész viszony ábrázolására alkalmasak, különösen, ha a adat kategóriákhoz numerikus értékek tartoznak. Ha azonban sok rész vagy címke van, érdemesebb oszlopdiagramot használni.

Ez a példa három negyedéves értékkel ellátott kördiagramot hoz létre. Minden szelet egyedi kitöltéssel és szegéllyel rendelkezik, a címkék pedig különböző kombinációkban jelenítik meg az értékeket, százalékokat és a sorozatinformációkat. A [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) tulajdonság 180 fokra állítja az első szelet indulását.

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

A körön kívüli címkék olvashatóságának javításához tekintse meg a [Format Leader Lines](/slides/hu/net/chart-data-label/#format-leader-lines) példát, amely a címkék elhelyezését és a vonalak színét, szélességét, átlátszóságát és szaggatott stílusát testre szabja.

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonal‑grafikonok) leginkább olyan helyzetekben használandók, amikor az értékek időbeli változását kívánja bemutatni. Egy vonaldiagram segítségével egyszerre összehasonlíthat nagy mennyiségű adatot, nyomon követheti a változásokat és trendeket, kiemelheti a sorozatok anomáliáit, és még sok mást.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódust használja egy vonaldiagram létrehozásához az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Alapértelmezés szerint a vonaldiagram pontjait egyenes, folytonos vonalak kötik össze. Ha pontok helyett szaggatott vonalakat szeretne, állítsa a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) értékét a [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) valamelyikére:

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

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatok esetén hasznosak, amikor a kategóriák relatív méretét kívánja megjeleníteni, és gyorsan fel kívánja hívni a nagy hozzájáruló tételeket az egyes kategóriákon belül.

Ez a példa egy fa térképet hoz létre nyolc levéllel, amely négy törzs és két ág szerint csoportosul. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus az 1‑es csoportosítási szinthez a törzseket, a 2‑es szinthez pedig az ágakat rendeli. Az értékek határozzák meg a relatív téglalapméreteket, a kategóriacímkék és a felül‑eszköz címkék jelölik a hierarchiát.

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

![A fa térkép diagram](treemap_chart.png)

### **Vízpadló diagramok létrehozása**

A vízpadló diagram azt mutatja, hogy a pozitív és negatív változások hogyan járulnak hozzá egy végső értékhez. Például egy nyereségtörés elindul a bevétellel, levonja a költségeket, majd hozzáadja a többi jövedelmet. A változásoszlopok a korábbi és az új futó értékek között lebegnek, míg a teljes oszlopok a nullától a felhalmozott értékig húzódnak.

A következő példa ezrei amerikai dollárban megadott összegeket használ:

| Kategória | Munkafüzet‑érték | Oszlop‑típus |
| --- | ---: | --- |
| Bevétel | 1000 | Növekedés |
| Eladási költség | -400 | Csökkenés |
| Bruttó nyereség | 600 | Köztes összeg |
| Üzemeltetési költségek | -200 | Csökkenés |
| Egyéb jövedelem | 50 | Növekedés |
| Nettó nyereség | 450 | Végső összeg |

Köztes vagy végső összegként jelölni a pontot, állítsa be a [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) tulajdonságot **true**‑ra. A pont munkafüzet‑cellájába helyezze el a tényleges felhalmozott összeget: `600` a bruttó nyereséghez (`1000 - 400`) és `450` a nettó nyereséghez (`600 - 200 + 50`). A tulajdonság csak megjelöli az oszlopot összegként; nem számolja ki vagy töltja fel a cella értékét. Ne használjon nullát helyőrzőként, és ne adjon meg más változást egy összeg‑ponthoz. Egy összeg‑oszlop a felhalmozott értéket jeleníti meg anélkül, hogy újra hozzáadná a futó értékhez.

Ez a teljes C# példa a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) `Waterfall` elemével hoz létre diagramot, törli az alapértelmezett adatokat, és feltölti a beágyazott munkafüzetet. A 0‑s munkalap‑index a első munkalapot választja; az A oszlop a kategória‑neveket, a B oszlop az értékeket tartalmazza. Minden értékcella a [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) metódussal kerül hozzáadásra. A 0‑bázisú pontindexek `2` és `5` a köztes és a végső összeg‑pontokat azonosítják. A [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) bekapcsolása megjeleníti az összegeket az oszlopokon. Bemutató bemeneti fájl vagy munkafüzet nem szükséges.

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

// A harmadik és hatodik pont összegként jelenik meg, nem további változásként.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

A sorozatszintű [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) tulajdonság **true**‑ra állítása vonalakat jelenít meg egymást követő oszlopok között, megkönnyítve a futó érték nyomon követését. Ezeknek a vonalaknak a elrejtéséhez cserélje a példában a hozzárendelést `series.ShowConnectorLines = false;`‑re a mentés előtt. Ez csak a vonal láthatóságát változtatja, az adatot vagy összeg‑pontokat nem.

A mentett prezentáció a bruttó nyereséget 600, a nettó nyereséget 450 értékkel mutatja, mindkettő nulláról indul:

![Vízpadló diagram, amely a bevételt, költségeket, 600-as bruttó nyereséget és 450-es nettó nyereséget, valamint az értékcímkéket és a csatlakozó vonalakat jeleníti meg](waterfall_chart.png)

### **Részvénydiagramok létrehozása**

A részvénydiagramok pénzügyi adatokat ábrázolnak, például nyitó, legmagasabb, legalacsonyabb és záró árakat, elősegítve a piaci trendek és a volatilitás elemzését. Ezek alapvető betekintést nyújtanak a részvény‑teljesítménybe, segítve a befektetőket és elemzőket a megalapozott döntésekben.

Ez a példa egy nyitó‑magas‑alacsony‑záró (OHLC) diagramot hoz létre négy sorozattal ebben a sorrendben és három kategóriával. A [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) tulajdonság engedélyezi a fel/le‑oszlopokat, a [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) szabályozza a magas‑alacsony vonalakat, míg az egyedi sorozat‑vonalak és a kisebb vízszintes rácsvonalak el vannak rejtve.

Az [UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/) menedzser külön [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/) és [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/) objektumokat biztosít. Mindkét objektum [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/) és [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/) tulajdonságait használva állítható be a kitöltés és a körvonal függetlenül. A példa zöld oszlopokat sötét‑zöld körvonallal használ a emelkedő időintervallumokhoz, és narancssárga‑vörös oszlopokat sötét‑vörös körvonallal a csökkenő időintervallumokhoz.

Adjon meg numerikus értékeket a négy sorozat minden kategóriájához, a magas‑alacsony értékek a nyitó‑záró értékeket tartalmazzák. Az oszlopok a záró értéket hasonlítják a nyitóhoz **ugyanabban a kategóriában**, nem az előző kategóriához képest: A 72‑ről 25‑re csökken, míg B 25‑ről 38‑ra, C pedig 38‑ról 50‑re emelkedik. Azonos nyitó‑ és záró­értékek láthatatlan kitöltött intervallumot eredményeznek. A fel/le‑oszlopok a Nyitó‑Záró tartományt fedik le; a magas‑alacsony vonalak a Legalacsonyabb‑Legmagasabb tartományt. Ezek az oszlopok a sorozatcsoporthoz tartoznak, nem pedig a szokásos oszlopdiagram‑sorozatokhoz.

Ez a formázás más, legalább két sorozattal rendelkező [Line and LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) diagramokra is alkalmazható, ha mindegyik kategóriához megfelelő numerikus értékek tartoznak. Ezeknél a nem‑halmozott vonaldiagramoknál a fel/le‑oszlopok az első és az utolsó sorozatot hasonlítják össze: a magasabb utolsó érték fel‑oszlopot, az alacsonyabb visszafelé oszlopot eredményez. A sorozatok sorrendjének megfordítása a besorolást is megfordítja. Az alábbi példa a [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) diagramot használja; ne feltételezze, hogy más részvény, halmozott‑vonal vagy 3D változatok ugyanazt az adat‑elrendezést vagy intervallum‑értelmezést alkalmazzák.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

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

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Az eredmény, a PowerPointból exportálva:

![Részvénydiagram, amely narancssárga‑vörös csökkenő intervallumot mutat A‑nak, és zöld emelkedő intervallumokat B‑nek és C‑nek](stock_chart.png)

### **Doboz‑és‑fészek diagramok létrehozása**

A doboz‑és‑fészek diagramok az adat eloszlását jelenítik meg, összegző statisztikai mérőszámok (medián, kvartilis, esetleges kiugró értékek) segítségével. Különösen hasznosak felderítő adat‑elemzésekben és statisztikai tanulmányokban, hogy gyorsan megértsük az adatok variabilitását és az esetleges anomáliákat.

Ez a példa hat értékkel ellátott doboz‑és‑fészek diagramot hoz létre. A [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) tulajdonság az exkluzív kvartilis‑számítást választja. A példa továbbá engedélyezi az átlag‑vonalakat, átlag‑jelzőket, belső pontokat és kiugró pontokat.

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

### **Tölcsér diagramok létrehozása**

A tölcsér diagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adat‑mennyiség csökken a lépésről lépésre történő előrehaladás során. Különösen hasznosak a konverziós arányok elemzésében, a szűk keresztmetszetek azonosításában és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követésében.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódussal ad egy tölcsér diagramot a meglévő prezentáció első diájához. Lecseréli az alapértelmezett adatot hat kategóriára és 50‑tól 500‑ig terjedő értékekre, majd menti a frissített prezentációt. A bemeneti prezentációnak legalább egy diát kell tartalmaznia.

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

![A tölcsér diagram](funnel_chart.png)

### **Napfény diagramok létrehozása**

A napfény diagramok hierarchikus adatokat ábrázolnak, a szinteket koncentrikus gyűrűkkel jelenítik meg. Segítenek bemutatni a rész‑egész viszonyt, és ideálisak beágyazott kategóriák és alkategóriák tömör, áttekinthető formában történő ábrázolásához.

Ez a példa nyolc levéllel csoportosított napfény diagramot hoz létre, négy törzzsel és két ággal. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus 1‑es csoportosítási szinten a törzseket, 2‑es szinten pedig az ágakat rendeli. A kategóriacímkék az egyes szegmenseket jelölik, az értékek pedig a relatív méreteket határozzák meg.

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

![A napfény diagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok azt mutatják, hogy a numerikus értékek hogyan oszlanak el intervallumok (bin‑ek) szerint. Havonta jelentésben a rendelési feldolgozási időkre ugyanazt a bin‑szélességet és küszöböket használja, így az intervallumok konzisztensen maradnak, és az eloszlások könnyebben összehasonlíthatók.

Állítsa be a vízszintes tengely [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) értékét a [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/) valamelyikére. A [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) csak a `ByBinWidth` esetén érvényes; a [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) csak a `ByNumberOfBins` esetén. Az `Automatic` használatával a diagram maga választja a bin‑eket.

#### **Rögzített bin‑szélesség használata**

Ez a példa a feldolgozási időket 10 perces intervallumokra csoportosítja, külön bin‑ekkel a 10 percnél kevesebb vagy egyenlő, illetve a 40 percnél nagyobb értékekhez. Engedélyezze ezeket a bin‑eket a [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) és a [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/) használatával. Ha explicit [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) és [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) küszöböket ad meg, állítsa a [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) és a [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) értékét **false**‑ra.

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

A PowerPointban megjelenő prezentáció a bin‑számokat **3, 4, 4, 4, és 2** mutatja. Az alul‑bin tartalmazza a `5, 10, 10` értékeket, ezért a küszöb inkluzív. A felül‑bin csak a `41, 50` értékeket tartalmazza, így a küszöb exkluzív; a `40` értékek az előző intervallumban maradnak. A belső bin‑ek a határértéknél nagyobb, a felső határértéknél kisebb vagy egyenlő értékeket tartalmazzák.

![Hisztogram 10 perces bin‑ekkel és explicit alul‑ és felül‑bin küszöbökkel](histogram_bin_width.png)

#### **Bin‑szám megadása**

Rögzített részletességi szint helyett, kérje ki öt bin‑t ugyanarra az adatra. Ez a példa letiltja az alul‑ és felül‑bin‑eket. A diagram a szélességet az adat‑tartományból számolja, így a határok jelentések között változhatnak.

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

Az öt bin‑nek a száma **4, 4, 4, 4, és 1**. Hasonlítsa össze ezt az eloszlást a fenti rögzített‑szélesség eredményével: a bemeneti értékek azonosak, a határok azonban eltérnek.

![Hisztogram öt bin‑nel, amely ugyanazból az adathalmazból számítódik](histogram_bin_count.png)

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatot jelenítenek meg kétdimenziós formátumban, lehetővé téve több változó egyszerre történő könnyű összehasonlítását. Különösen hasznosak minták, erősségek és gyengeségek azonosításához több teljesítménymutató vagy attribútum esetén.

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

### **Több‑kategória diagramok létrehozása**

A több‑kategória diagramok olyan adatot jelenítenek meg, amely több kategóriacsoportot is tartalmaz, lehetővé téve az értékek több dimenzióban való egyszerre történő összehasonlítását. Különösen hasznosak, ha összetett, többrétegű adathalmazok trendjeit és összefüggéseit kell elemezni.

Ez a példa egy csoportos oszlopdiagramot hoz létre nyolc kategóriával, négy párban elrendezve. A [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) metódus minden párnak egy megosztott címkét ad az 1‑es csoportosítási szinten, így a kategóriatengely egyszerre tartalmaz egyéni és csoportcímkéket.

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

![A több‑kategória diagram](multi_category_chart.png)

#### **Negyedévi címke eltávolítása**

Töltse le a [quarters.pptx](quarters.pptx) fájlt, és helyezze a munkakönyvtárba. Diagramja kilenc hónapot és egyetlen eladási sorozatot mutat 10‑től 18‑ig terjedő értékekkel. A kategóriatengely három negyedévi címkét tartalmaz: Q1 (jan‑márcs), Q2 (ápr‑jún), Q3 (júl‑szept).

Az április a negyedik kategória, és arra a negyedévre (Q2) van explicit beállítva. Hívja meg a [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) metódust április [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/) gyűjteményén. A szint áprilishoz relatív: az 1‑es szint a negyedéve, a 0‑s szint maga a hónap. A metódus nem tudja eltávolítani a 0‑s szintű levél‑kategóriát.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

Az újra megnyitott diagram a kiinduló hónapokat (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) és az eladási értékeket (`10, 11, 12, 13, 14, 15, 16, 17, 18`) ugyanabban a sorrendben jeleníti meg. Nyissa meg a `quarters-updated.pptx` fájlt a PowerPointban a tengelycímkék összehasonlításához. A Q2 címke és az április előtti csoporthatár eltűnik, így Q1 januártól júniusig terjed. Q3 továbbra is júliusban kezdődik.

![Negyedévi címkék eltávolítása előtt és után. Bal oldalon Q2 áprilistól júniusig terjed; jobb oldalon Q1 januártól júniusig terjed.](quarter-label-comparison.png)

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatokat ábrázolnak úgy, hogy a információt konkrét helyekhez (országok, államok, városok) rendelik. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzésére, egyértelmű és vizuálisan vonzó módon.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódussal hoz létre egy térkép diagramot az alapértelmezett földrajzi adatokkal, és a PowerPointban való megtekintéshez menti.

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

{{% alert color="info" title="Megjegyzés" %}}
A fenti kép a PowerPointban megnyitott mentett prezentációt mutatja. Az Aspose.Slides helyesen írja a térkép diagramot és annak adatait, de magát a térkép diagramot nem rajzolja meg: amikor egy diát, amely ilyen diagramot tartalmaz, képpé renderel vagy PDF‑re vagy SVG‑re konvertál, a diagram területe üres lesz. A dián lévő egyéb alakzatok nem érintettek.
{{% /alert %}}

### **Kombináció diagramok létrehozása**

A kombináció diagram (vagy combo diagram) két vagy több diagramtípust egyesít egyetlen grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a két vagy több adathalmaz közötti különbségeket, ezáltal segítve a köztük lévő kapcsolatok felismerését.

![A kombináció diagram](combination_chart.png)

Ez a példa két csoportos oszlop sorozatot és egy vonal sorozatot kombinál négy kategórián. Az oszlopok az elsődleges függőleges tengelyt használják, míg a [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) a vonalat a jobb oldali másodlagos függőleges tengelyre helyezi. A segédfüggvények konfigurálják a címet, a jelmagyarázatot, a tengelycímkéket és a rácsvonalakat.

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

Az Aspose.Slides for .NET lehetővé teszi PowerPoint diagramok frissítését a diagram adatainak, formázásának és stílusának módosításával. Ez a funkció leegyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék az aktuális adatokat és vizuális szabványokat.

Ez a példa a meglévő prezentáció első diáján a „My chart” nevű diagramot frissíti. Két oszlop sorozatra van szükség, mindegyiknek három adatponttal, a kategóriacímkék az A oszlopban, a sorozatnevek az első sorban az első munkalapon. A példa a [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) metódust használja a munkafüzet‑cellák módosítására, frissíti a sorozat értékeket, hozzáad egy harmadik sorozatot, és a [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/) segítségével a diagramot csoportos hengerre változtatja.

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

## **Diagram adat‑tartomány beállítása**

A már meglévő diagram által használt tartomány megtekintéséhez tekintse meg a [Retrieve a Chart's Data Range](/slides/hu/net/chart-workbook/#retrieve-a-charts-data-range) oldalt.

Az Aspose.Slides for .NET rugalmasságot biztosít egy adott munkalap adat‑tartományának meghatározásához, mint a diagram adatforrását. Ez azt jelenti, hogy közvetlenül leképezhet egy munkalap‑részletet a diagramra, így ellenőrizheti, mely cellák járulnak hozzá a diagram sorozataihoz és kategóriáihoz. Ennek eredményeként egyszerűen frissítheti és szinkronizálhatja diagramjait a munkalap legújabb adatváltozásaival, biztosítva, hogy a PowerPoint prezentációk aktuális és pontos információt tükrözzenek.

Ez a példa a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) metódust használja a „My chart” nevű diagram adatforrásának beállításához az első dián egy meglévő prezentációban a `Sheet1!A1:B4` tartományra. A diagram munkafüzetnek tartalmaznia kell azt a munkalapot és egy kitöltött tartományt, ahol az első sorban a sorozatfejléc, az A oszlopban a kategória címkék, a B oszlopban három érték szerepel.

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

## **Alapértelmezett jelzők használata diagramokon**

Alapértelmezett jelzők használatakor a diagram minden sorozata automatikusan más‑más jelzőszimbólumot kap.

Ez a példa a [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) metódussal hoz létre egy diagramot két vonal sorozattal és egy jelmagyarázattal. A [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) beállítások megtartják a automatikusan hozzárendelt jelzőszimbólumokat. Az első sorozat negatív és hiányzó értéket tartalmaz (`null`), a második minden kategóriához értéket ad.

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

**Milyen diagramtípusokat támogat az Aspose.Slides for .NET?**

Az Aspose.Slides for .NET széles körű diagramtípusokat támogat, többek között oszlop, vonal, kör, terület, szórás, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy a legmegfelelőbb diagramtípust válassza adatmegjelenítési igényeihez.

**Hogyan adhatok új diagramot egy diához?**

Új diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típust és a kezdeti adatokat. Ez a folyamat közvetlenül a prezentációba integrálja a diagramot.

**Hogyan frissíthetem egy diagram megjelenített adatait?**

A diagram [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatok hozzáadásával frissítheti a diagramot, hogy a legújabb adatokat tükrözze.

**Lehet-e testre szabni a diagram megjelenését?**

Igen, az Aspose.Slides for .NET kiterjedt testreszabási lehetőségeket kínál. Színek, betűtípusok, címkék, jelmagyarázatok és egyéb formázási elemek módosításával a diagramot a saját tervezési követelményeihez igazíthatja.

Kapcsolódó funkció: [Create editable charts](/slides/hu/features/create-charts/).