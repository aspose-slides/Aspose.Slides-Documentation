---
title: Diagram adatcímkék kezelése prezentációkban .NET-ben
linktitle: Adatcímke
type: docs
url: /hu/net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for .NET használatával, hogy lebilincselőbb diák jöjjenek létre."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk elmagyarázza, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható a címke szövege, hogyan vezérelhetők a címsorok a tengely maximumán túl, hogyan állítható be a kategória tengely címke távolsága, és hogyan helyezhetők el a kördiagram címkék.

## **Megjelenő adatcímkék száma**

Használja a [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) metódust annak ellenőrzésére, hogy hány adatcímke van engedélyezve a megjelenítésre a prezentáció közzététele előtt. Az [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) metódustól eltérően, amely a gyűjteményben lévő címkék teljes számát adja vissza, ez figyelembe veszi a sorozat alapértelmezéseit és az egyes címkék beállításait.

Ez a példa egy oszlopdiagramot hoz létre egy sorozattal és három adatponttal. Eléri a sorozat [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) gyűjteményét, és kiírja a látható címkék számát a beállítások változása közben: **0, 3, 2, 3**. A teljes szám **3** marad.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Összesen: 3; látható: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 3
```

A sorozat [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) adja meg az alapértelmezett beállításokat. Az [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezése ott minden három címke értékét megjeleníti. `false` értékre állítása egy címke [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) révén felülírja ezt a beállítást a kiválasztott címkénél. Az [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) engedélyezése ismét láthatóvá teszi azt a címkét, még ha az értéke rejtve is marad.

A látható számláló a láthatósági beállításokat tükrözi. Nem méri, hogy a címkék átfedik-e egymást, levágottak-e, vagy olvashatóak-e a megjelenített diagramon.

## **Adatcímkék pontosságának beállítása a diagramon**

Használja a [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) metódust a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozat számára. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

A diagram beágyazott munkafüzetének numerikus celláinak formázásához tekintse meg a [Egyéni számformátumok beállítása a munkafüzet celláira](/slides/hu/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) útmutatót. Az a példa azt is bemutatja, hogy az értékcímkék követik a forráscellák formátumát, miközben megőrzik a tárolt numerikus értékeket.

## **Százalék megjelenítése címkékben**

Egy halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) elemhez. Ez a példa az alapértelmezett diagramadatokat használja, és százalékos értékeket jelenít meg két tizedesjeggyel, 8 pontos betűmérettel. A nulla összegű kategóriákat kihagyja a nullával való osztás elkerülése érdekében. Számolja újra az egyéni címkeszöveget, ha a diagram adatai változnak.

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

Ha az értékek tört számként vannak tárolva, használja a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) metódust a százalékok megjelenítéséhez. Állítsa az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) értékét `false`-ra, hogy a címke formátumát a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum a 0.30-at 30,0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Az adatcímkék tényleges szövegének olvasása**

Használja a [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) metódust az adatcímke beállításai által előállított szöveg lekéréséhez. Ez akkor hasznos, amikor címkéket kell kinyerni jelentésekhez, a prezentáció tartalmát keresni, vagy a generált diagramokat validálni. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) egyesíti a kategória nevét, a sorozat nevét és az értéket. Egy pont a értékét százalékos formátumban jeleníti meg, egy másik egyedi szöveget használ a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) elemből.

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

Az adatpontban tárolt szám `0,75` marad, még ha a címkéje `75%`-ot mutat a kategória és a sorozat neveivel együtt. Az egyedi szöveg felülírja a generált címkeszöveget. A [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) a kapott címkesztringet adja vissza mindkét esetben. Ellenőrizze külön az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) beállítást, ahogyan fent látható, ha csak a látható címkéket szeretné kinyerni.

## **Az adatcímkék vezérlése a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, előfordulhat, hogy egyes adatpontok meghaladják a maximumot. Használja a [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) metódust annak szabályozására, hogy a címkék megjelenjenek-e. Ez a beállítás a címke láthatóságát változtatja; a tengely tartományát vagy a mögöttes adatértékeket nem módosítja.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. A függőleges tengelyen a [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) értékét `false`, a [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) értékét pedig 100-ra állítja. Az első dián a maksimumot meghaladó címkék engedélyezve vannak; a másolat letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlban van mentve.

Az értékcímkéket a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) segítségével engedélyezheti. A diagram szintű beállítás önmagában nem engedélyezi az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékkijelzését. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) segítségével a címkéket minden oszlop külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtve marad. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont **120** marad mindkét esetben.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint diagram, amely megjeleníti a 120 értékcímkét a 100 tengelymaximumtal](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét a 100 tengelymaximumtal](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, például a kör- és a galambfalka-diagramok, nem rendelkeznek olyan tengelymaximumtal, amelyet így korlátozni lehetne.
{{% /alert %}}

## **Címke távolságának beállítása egy tengelytől**

Használja a [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) metódust a kategória tengelycímkék és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengelycímkékre hat, nem az egyes adatpontokhoz csatolt címkékre.

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

Kördiagram esetén a adatcímkék pozíciójának módosításával javítható a távolság és helyet biztosíthat vezető vonalaknak.

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet kívülére helyezi, és módosítja a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolásait. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

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

![Kördiagram, amelynek adatcímkéje módosított pozícióban van](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Ha a kördiagram címkéi a szeletek kívül helyezkednek el, a vezető vonalak segítik az olvasót, hogy az egyes értékeket a megfelelő szelethez társítsa. Egy kontrasztos szín és egy kissé vastagabb vonal könnyebbé teheti ezeket a kapcsolatokat, míg az átlátszóság és a szaggatott stílus vizuálisan visszafogottá teszi a vonalakat.

Használja a [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) elemet a sorozat adatcímke-gyűjtemény szintjén történő vezető vonalak formázásához. A `series.Labels.LeaderLinesFormat.Line` beállítások a gyűjteményre vonatkoznak, nem egyedi címkére.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, a szeletek kívül jeleníti meg az értékeket, és engedélyezi a [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) opciót. Két címkét távolabb helyez a szeletektől a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolások segítségével, amelyek a diagram szélességének és magasságának törtjei. Bemeneti prezentáció nem szükséges.

A vonal [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) egy szilárd kék színt állít be 191/255 alfa értékkel, amely körülbelül 25 % átlátszóságot eredményez. A [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) a vastagságot 2 pontra állítja, a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) pedig szaggatottá teszi a vonalat.

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

A vezető vonalak engedélyezése nem garantálja, hogy minden címkéhez megjelenik vonal. A láthatóság a címke elhelyezésétől és a diagram elrendezési viselkedésétől függ. Ebben a példában a két eltolódott címkénél látható a vezető vonal; a szeletekhez közel maradt címkékre nincs szükség.

Az alábbi kép a mentett `FormattedLeaderLines.pptx` Aspose.Slides segítségével renderelt változatát mutatja:

![Kördiagram kék, félig átlátszó szaggatott vezető vonalakkal, amelyek két külső címkét összekötnek a szeletekkel](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása egy oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, amely a ábrázolási terület felett két sor adatcímkét helyez el. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Oszlopaik el vannak rejtve a kitöltés és a körvonal eltávolításával. Az [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) tulajdonság mindhárom sorozatot ugyanazon kategória középpontokkal illeszti.

A [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) beállítások helyet tartanak fenn a címkesorok számára. A [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) kiszámítja az alapértelmezett pozíciókat, a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) megőrzik a vízszintes igazítást és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok adatcímkék maradnak, amelyek a sorozat értékeihez vannak kapcsolva; csak a sorcímek külön szöveges alakzatok.

```csharp
using System.Drawing;
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
        // Rejtse el a B és C oszlopokat, de tartsa meg az adatcímkéiket.
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

// Igazítsa az összes három sorozatot azonos kategória középpontokkal.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Használjon kevesebb rácsvonalat ebben a kompakt példában.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Foglaljon helyet a ábra felett két sor adatcímkének.
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
        // Tartsa meg az alapértelmezett vízszintes pozíciót. Y egy eltolás a
        // alapértelmezett címke pozíciótól, a diagram magasságának törtjeként kifejezve.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Csak a sorfejléc egy külön szöveges alakzat.
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

![Oszlopdiagram, amely két sor adatcímkét helyez el az ábrázolási terület felett](multiple-rows-of-labels.png)

## **Az adatcímkék alakjának módosítása**

Az Aspose.Slides for .NET 26.11 verziója hozzáadja az [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) beállítást egy címkéhez, valamint a [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) beállítást a sorozat összes aktuális címkéjéhez. Ezek a címke alakját változtatják, nem a pontjelzőt. A különálló felirat beállításhoz lásd a [Adatcímke feliratok](/slides/hu/net/callout/).

A gyűjtemény hozzárendelése frissíti a meglévő címkéket, ezért egyéni felülírásokat **a** gyűjtemény beállítása **után** kell alkalmazni. Ez a teljes példa a [Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11 vagy újabb verzióját igényli. Látható értékcímkéket hoz létre, ellipsziseket választ az első sorozathoz, majd az első címkét téglalap alakúra változtatja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// Visszaállítja az összes jelenlegi címkére vonatkozó explicit alakválasztásokat.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

A gyűjtemény alakjának újbóli hozzárendelése szintén felülírja az előző egyéni alakválasztásokat. A [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) törli a kifejezett alakválasztást; nem rejti el a címkéket, vagy törli a többi formázást. A kívánt alakokat a sorozat feltöltése után állítsa be, ahelyett, hogy feltételezné, hogy a később hozzáadott pontok öröklik a korábbi hozzárendelést. Itt a Rectangle és az Ellipse használatos; vizsgálja meg a renderelt eredményt, ha más alaktípusokat választ.

## **GYIK**

**Hogyan előzhetem meg az adatcímkék átfedését sűrű diagramokon?**  
Használjon automatikus címkeelhelyezést, vezető vonalakat és kisebb betűméretet; szükség esetén rejtsen el bizonyos mezőket (például a kategóriát), vagy csak extrém értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**  
Szűrje a adatpontokat a címkék engedélyezése előtt, és egy meghatározott szabály szerint kapcsolja ki a megjelenítést a 0, a negatív vagy a hiányzó értékeknél.

**Hogyan biztosíthatom a konzisztens címkestílust PDF-/képek exportálásakor?**  
Állítsa be kifejezetten a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelő környezetben, hogy elkerülje az alternatív betűtípus használatát.