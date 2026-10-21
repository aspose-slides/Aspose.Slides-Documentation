---
title: Diagram adatcímkék kezelése prezentációkban .NET-ben
linktitle: Adatcímke
type: docs
url: /hu/net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpont pontossága
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for .NET használatával a figyelemfelkeltőbb diákért."
---
## **Bevezetés**

Az adatelcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázzuk az értékeket, hogyan jelenítsünk meg százalékokat, hogyan olvassuk el a címke szövegét, hogyan szabályozzuk a címkéket a tengely maximumán túl, hogyan állítsuk be a kategóriatengely címkék közötti távolságot, és hogyan helyezzük el a kördiagram címkéit.

## **Diagram adatcímkék pontosságának beállítása**

Használja a [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) metódust a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat tábláját, és engedélyezi az értékcímkéket az első sorozatra. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

A diagram beágyazott munkafüzetének numerikus celláinak formázásához lásd a [Set Custom Number Formats for Workbook Cells](/slides/hu/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) című útmutatót. Ez a példa azt is bemutatja, hogy az értékcímkék követik a forráscellák formátumát, miközben megőrzik a tárolt numerikus értékeket.

## **Százalékok megjelenítése címkeként**

Halmozott oszlopdiagram esetén számítsa ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) objektumhoz. Ez a példa az alapértelmezett diagram adatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja a nullával való osztás elkerülése érdekében. Ha a diagram adatai változnak, számolja újra az egyedi címke szöveget.

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

## **Százalékjel beállítása a diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) metódust a százalékok megjelenítéséhez. Állítsa az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) értékét `false`-ra, hogy a címkeformátum független legyen a forráscelláktól.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum 0.30-at 30,0%-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Adatcímkék tényleges szövegének lekérdezése**

Használja a [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) metódust az adatcímke beállításai által előállított szöveg lekéréséhez. Ez hasznos jelentésekhez címkék kinyerésekor, a prezentáció tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) kombinálja a kategórianév, sorozatnév és az érték minden elemét. Az egyik pont az értékét százalékba formázza, a másik egyéni szöveget használ a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) segítségével.

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

Az adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot jelenít meg a kategória és sorozat nevével együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) mindkét esetben visszaadja a kapott címkeszöveget. Ellenőrizze külön a [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) értékét, ahogy fent látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék szabályozása a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) beállítást annak szabályozására, hogy a címkéik megjelenjenek-e. Ez a beállítás csak a címke láthatóságát változtatja; a tengely tartományát vagy a mögöttes adatértékeket nem módosítja.

Az alábbi példa egy 2D csoportos oszlopdiagramot hoz létre 60 és 120 értékekkel. A függőleges tengelyen az [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) értékét `false`-ra, a [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) értékét pedig 100-ra állítja. Az első dia a maximumon túli címkék megjelenítését engedélyezi; egy másolatban letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

Engedélyezze az értékcímkéket a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) segítségével. A diagram szintű beállítás önmagában nem kapcsolja be az érték megjelenítését, és nem ír felül egy egyedi címke letiltott értékmutatását. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) segítségével a címkéket az egyes oszlopok külső végébe helyezi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Az alábbi képek a Microsoft PowerPoint által megjelenített mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtett. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont **120** mindkét esetben.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint diagram, amely megjeleníti a 120 értékcímkét 100 tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét 100 tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ érték tengellyel. Az olyan diagramok, amelyeknek nincs érték tengelye, mint a kör- és gyűrűdiagramok, nem rendelkeznek tengely maximumtal, amit így lehetne korlátozni.
{{% /alert %}}

## **Címke távolságának beállítása egy tengelytől**

Használja a [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) beállítást a kategóriatengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportos oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéit érinti, nem pedig az egyes adatpontokhoz kapcsolódó címkéket.

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

## **Címke helyének igazítása**

Kördiagram esetén állítsa be az adatcímkék pozícióját a térköz javítása és a vezető vonalak számára való hely biztosítása érdekében.

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet külső részére helyezi, és a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolásokat állítja be. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva értendők.

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

![Kördiagram az igazított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Ha a kördiagram címkéi a szeleteiken kívül helyezkednek el, a vezető vonalak segítik az olvasókat az egyes értékek helyes szelethez rendelésében. A kontrasztos szín és egy kissé vastagabb vonal megkönnyíti a követést, míg az átlátszóság és a szaggatott stílus a vonalakat vizuálisan visszafogottá teszi.

Használja a [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) metódust a vezető vonalak formázásához a sorozat adatcímke-gyűjtemény szintjén. A `series.Labels.LeaderLinesFormat.Line` beállítások a gyűjteményre vonatkoznak, nem egyetlen címkére.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a szeleteken kívül jeleníti meg az értékeket, és engedélyezi a [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) funkciót. Két címkét távolabb helyez át a szeletektől a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolásokkal, amelyek a diagram szélességének és magasságának törtjelei. Nem szükséges bemeneti prezentáció.

A vonal [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) beállítása egy szilárd kék színt ad, alfa értéke 191 a 255-ből, ami körülbelül 25 % átlátszóságot eredményez. A [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) a vastagságot 2 pontra állítja, a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) pedig szaggatott vonallá alakítja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Mozgassa el a két címkét távolabb a szeleteiktől.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

A vezető vonalak engedélyezése nem garantálja, hogy minden címke esetén megjelenik vonal. A láthatóság a címke elhelyezésétől és a diagram elrendezésétől függ. Ebben a példában a két elmozdított címke látható vezető vonallal rendelkezik; a szeletekhez közel maradt címkéknek nincs szükségük rá.

Az alábbi kép a mentett `FormattedLeaderLines.pptx` fájlt mutatja, amelyet az Aspose.Slides jelenített meg:

![Kördiagram kék, félig áttetsző szaggatott vezető vonalakkal, amelyek két külső címkét összekötnek a szeleteikkel](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása egy oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, amelynek a rajzterület felett két sor adatcímkéje van. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Oszlopaikat a kitöltés és a keret eltávolításával rejtik el. A [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) tulajdonság a három sorozatot ugyanazon kategóriaközéppontokhoz igazítja.

A [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) beállítások helyet biztosítanak a címkesoroknak. A [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) az alapértelmezett pozíciókat kiszámítja, a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) megőrzi a vízszintes igazítást, és függőleges eltolásokat alkalmaz, hogy a címkéket két sorba rendezze. A számok adatcímkék maradnak, amelyek a sorozatértékekhez kapcsolódnak; csak a sorfejlécek külön szöveges alakzatok.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Rejtse el a B és C oszlopokat, de tartsa meg az adatcímkéket.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Align all three series with the same category centers.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Use fewer gridlines for this compact example.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserve space above the plot for two rows of data labels.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Tartsa meg az alapértelmezett vízszintes pozíciót. Az Y egy eltolás a
        // alapértelmezett címkepozíciótól, a diagrammagasság történt arányában.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Csak a sorfejléc egy külön szövegforma.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Oszlopdiagram két sor adatcímkével a rajzterület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan előzhetem meg az adatcímkék átfedését sűrű diagramokon?**  
Kombináljon automatikus címkeelhelyezést, vezető vonalakat és kisebb betűméretet; szükség esetén rejtsen el egyes mezőket (például a kategóriát), vagy csak extrém értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak nulla, negatív vagy üres értékek esetén?**  
Szűrje a adatpontokat a címkék engedélyezése előtt, és a megadott szabály szerint kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékeknél.

**Hogyan biztosíthatom a konzisztens címkestílust PDF/képek exportálásakor?**  
Állítsa be kifejezetten a betűtípust és a méretet, és ellenőrizze, hogy a betűtípus elérhető-e a megjelenítő környezetben, hogy elkerülje az automatikus helyettesítést.