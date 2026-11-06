---
title: Diagram adatcímkék kezelése bemutatókban .NET-ben
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
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint bemutatókban az Aspose.Slides for .NET segítségével, hogy lebilincselőbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyedi adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatók az értékek, jeleníthetők meg a százalékok, olvasható a címke szövege, szabályozhatók a tengely legmagasabb értékén túl eső címkék, állítható a kategóriatengely címkéinek távolsága, valamint hogyan helyezhetők el a kördiagram címkéi.

## **Megjelenített adatcímkék száma**

Az [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) használatával ellenőrizhető, hány adatcímke van engedélyezve a megjelenítéshez, mielőtt a bemutatót közzétennénk. A [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) módszerrel, amely a gyűjteményben lévő címkék teljes számát adja vissza, ellentétben, ez figyelembe veszi a sorozat alapértelmezéseit és az egyes címkék beállításait.

Ez a példa egy oszlopdiagramot hoz létre egy sorozattal és három adatponttal. A sorozat [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) gyűjteményéhez fér hozzá, és a látható számlálót írja ki a beállítások változása közben: **0, 3, 2, 3**. A teljes szám **3** marad.

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
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Összes: 3; látható: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Látható: 3
```

A sorozat [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) biztosítja az alapértelmezett beállításokat. A [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezése itt megjeleníti az értékeket mindhárom címkéhez. Az egyes címkék [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) `false` értékre állítása felülbírálja ezt a beállítást a kiválasztott címkére. A [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) engedélyezése újra láthatóvá teszi azt a címkét, még akkor is, ha az értéke rejtve marad.

A látható szám a láthatósági beállításokat tükrözi. Nem azt méri, hogy a címkék átfedik-e egymást, levágottak-e, vagy olvashatóak-e a renderelt diagramon.

## **Adatcímkék pontosságának beállítása a diagramon**

A [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) használatával formázhatók a sorozat értékei. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

A diagram beágyazott munkafüzetének numerikus celláinak formázásához lásd a [Egyéni számformátumok beállítása munkafüzetcellákhoz](/slides/hu/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) oldalt. Az a példa azt is bemutatja, hogy az értékcímkék a forrás cella formátumát követik, miközben megőrzik a tárolt numerikus értékeket.

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számítsa ki minden értéket a kategória összes értékének százalékaként, és rendelje a szöveget a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)-hez. Ez a példa az alapértelmezett diagramadatokat használja, és két tizedesjegy pontossággal jeleníti meg a százalékokat 8 pontos betűmérettel. A nulla összegű kategóriákat kihagyja a nullával való osztás elkerülése érdekében. Ha a diagram adatjai megváltoznak, újraszámításra van szükség a saját címke szövegén.

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

Hozzá tartozó értékek törtként tárolva vannak, használja a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) metódust a százalékok megjelenítéséhez. Az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `false` értékre állítása lehetővé teszi a címkeformátum független alkalmazását a forráscelláktól.

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

A [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) használatával lekérhető a adatcímke beállításai által előállított szöveg. Ez hasznos jelentésekhez címkék kinyerésekor, a bemutató tartalmának keresésekor vagy a generált diagramok validálásakor. Az alábbi példában az alapértelmezett [adatcímke formátum](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) minden kategória nevét, sorozat nevét és értékét kombinálja. Egy pont a saját értékét százalékban formázza, egy másik pedig egyedi szöveget használ a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)-ből.

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

A adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ként jelenik meg a kategória és sorozat nevével együtt. Az egyéni szöveg felülírja a generált címke szöveget. A [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) mindkét esetben a kapott címke karakterláncot adja vissza. A [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) külön ellenőrzése, ahogy fent is látható, akkor szükséges, ha csak a látható címkéket szeretnénk kinyerni.

## **Adatcímkék szabályozása a tengely legmagasabb értéke után**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok túlléphetik a maximumot. A [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) használatával szabályozható, hogy ezeknek az adatpontoknak megjelenjenek-e a címkéi. Ez a beállítás a címke láthatóságát változtatja; a tengely tartományt vagy a mögöttes adatértékeket nem módosítja.

A lenti példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. A függőleges tengelyen a [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) `false`, a [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) pedig 100 értékre van állítva. Az első dián a maximumon túli címkék engedélyezve vannak; egy másolatban ez le van tiltva. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

A [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) használatával engedélyezhetőek az értékcímkék. A diagram szintű beállítás önmagában nem engedélyezi az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékkijelzését. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) segítségével a címkéket az egyes oszlopok külső végére helyezi.

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

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint-diagram, amely a 120 értékcímkét mutatja 100-as tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint-diagram, amely elrejti a 120 értékcímkét 100-as tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, mint a kör és a fánk diagramok, nincs tengely maximum, amit ilyen módon korlátozni lehetne.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

A [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) használatával szabályozható a kategóriatengely címkéi és a tengely közötti távolság. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire vonatkozik, nem az egyes adatpontokhoz csatolt címkékre.

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

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülére helyezi, és beállítja a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolásokat. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva relatívak.

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

![Kördiagram módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Ha a kördiagram címkéi a szeletek kívül helyezkednek el, a vezető vonalak segítik az olvasókat, hogy az egyes értékeket a megfelelő szelethez rendeljék. Egy kontrasztos szín és egy kissé vastagabb vonal könnyebbé teheti a kapcsolatok követését, míg az átlátszóság és a szaggatott stílus kevésbé zavaróvá teszi a vonalakat.

A [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) használatával a sorozat adatcímke-gyűjtemény szintjén formázhatók a vezető vonalak. A `series.Labels.LeaderLinesFormat.Line` beállítások a gyűjteményre, nem pedig egyéni címkére vonatkoznak.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, a szeletek kívül jeleníti meg az értékeket, és engedélyezi a [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Két címkét távolabb helyez a szeletektől a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) eltolások segítségével, amelyek a diagram szélességének és magasságának törtjei. Nem szükséges bemeneti bemutató.

A vonal [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) egy szilárd kék színt állít be 191/255 alfa értékkel, ez körülbelül 25% átlátszóságot eredményez. A [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) a vonalvastagságot 2 pontra állítja, a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) pedig szaggatott vonalat hoz létre.

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

// Két címkét távolabb helyez a szeleteiktől.
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

A vezető vonalak engedélyezése nem garantálja, hogy minden címkéhez vonal jelenik meg. A láthatóság a címke elhelyezkedésétől és a diagram elrendezési viselkedésétől függ. Ebben a példában a két elmozdított címke látható vezető vonalakkal rendelkezik; a szeletekhez közel maradt címkéknek nincs szükségük rá.

A következő kép a mentett `FormattedLeaderLines.pptx` Aspose.Slides által renderelt változatát mutatja:
![Kördiagram kék, félig átlátszó szaggatott vezető vonalakkal, amelyek a külső címkéket a szeletekhez kapcsolják](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása oszlopdiagram fölött**

Ez a példa egy oszlopdiagramot hoz létre, amely a rajzterület felett két sor adatcímkét tartalmaz. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Az ő oszlopaikat a kitöltés és a körvonal eltávolításával rejtik el. A [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) tulajdonság az összes három sorozatot azonos kategóriaközéppontokkal igazítja.

A [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) beállítások a címkesorok számára helyet biztosítanak. A [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) alapértelmezett pozíciókat számítja ki, majd a [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) megőrzik a vízszintes igazítást és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok továbbra is adatcímkék maradnak, amelyek a sorozatértékekhez kapcsolódnak; csak a sorfejek külön szöveges alakzatok.

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
        // Rejtse el a B és C oszlopait, de tartsa meg az adatcímkéket.
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

// Igazítsa a három sorozatot ugyanolyan kategória középpontokhoz.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Használjon kevesebb rácsvonalat ebben a kompakt példában.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Tartson helyet a rajzterület felett két sor adatcímke számára.
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
        // Tartsa meg az alapértelmezett vízszintes helyzetet. Az Y egy eltolás a
        // az alapértelmezett címkehelyzettől, a diagram magasságának törtjeként kifejezve.
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

![Oszlopdiagram két sor adatcímkével a rajzterület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan akadályozhatom meg az adatcímkék átfedését sűrű diagramokon?**  
Használjon automatikus címkeelhelyezést, vezető vonalakat és kisebb betűméretet; ha szükséges, rejtsen el néhány mezőt (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok címkéit jelenítse meg.

**Hogyan tilthatom le a címkéket csak a nullás, negatív vagy üres értékek esetén?**  
Szűrje a adatpontokat a címkék engedélyezése előtt, és egy meghatározott szabály alapján kapcsolja ki a megjelenítést 0, negatív vagy hiányzó értékeknél.

**Hogyan biztosíthatom a címkék következetes stílusát PDF/képek exportálásakor?**  
Explicit módon állítsa be a betűtípust és méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje az alternatív betűk használatát.