---
title: Spravovat popisky dat grafu v prezentacích v .NET
linktitle: Popisek dat
type: docs
url: /cs/net/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat grafů v prezentacích PowerPoint pomocí Aspose.Slides pro .NET pro poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o sériích grafu a jednotlivých datech, což čtenářům pomáhá identifikovat hodnoty a porozumět grafu. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisky, ovládat popisky mimo maximální hodnotu osy, upravovat rozestupy popisků kategoriální osy a umisťovat popisky koláčových grafů.

## **Nastavit přesnost dat v popiscích grafu**

Použijte [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) k formátování hodnot sérií. Tento příklad vytvoří čárový graf s výchozími daty, zobrazí jeho datovou tabulku a povolí popisky hodnot pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by změnil podkladové hodnoty.

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

Pro formátování číselných buněk v vložené sešitě grafu viz [Set Custom Number Formats for Workbook Cells](/slides/cs/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Tento příklad také ukazuje popisky hodnot, které následují formáty zdrojových buněk a přitom zachovávají uložené číselné hodnoty.

## **Zobrazit procenta jako popisky**

Pro sloupcový graf s naskládanými hodnotami vypočítejte každou hodnotu jako procento celkového součtu v dané kategorii a přiřaďte text do [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu o velikosti 8 bodů. Kategorie s celkovým součtem nula jsou přeskočeny, aby se předešlo dělení nulou. Přepočítejte vlastní text popisky, pokud se data grafu změní.

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

## **Nastavit znak procenta v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) k zobrazení procent. Nastavte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `false`, aby se formát popisky použil nezávisle na zdrojových buňkách.

Tento příklad vytvoří 100 % naskládaný sloupcový graf s červenou a modrou sérií ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisky `0.0%` zobrazí 0,30 jako 30,0 %, zatímco svislá osa používá dvě desetinná místa. Obě série používají bílý popisek o velikosti 10 bodů.

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

## **Přečíst skutečný text popisků dat**

Použijte [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) k získání textu vytvořeného nastavením popisky dat. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [formát popisky dat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) kombinuje název kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a série. Vlastní text nahrazuje vygenerovaný text popisky. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) vrací výsledný řetězec popisky v obou případech. Zkontrolujte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) samostatně, jak je uvedeno výše, pokud chcete extrahovat pouze viditelné popisky.

## **Ovládání popisků mimo maximální hodnotu osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) k nastavení, zda se jejich popisky zobrazí. Toto nastavení mění viditelnost popisky; nemění rozsah osy ani podkladové datové hodnoty.

Níže uvedený příklad vytvoří 2D seskupený sloupcový graf s hodnotami 60 a 120. Nastaví [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) na `false` a [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) na 100 na svislé ose. První snímek umožňuje popisky mimo maximum; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Nastavení na úrovni grafu samo o sobě nezpřístupní zobrazování hodnot ani nepřepíše zakázané zobrazování hodnot u jednotlivých popisků. Tento příklad povoluje hodnoty pro celou sérii a používá [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) k umístění popisků na vnější konec každého sloupce.

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

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPointu. S nastavením `true` je popisek **120** viditelný na horní hranici; s nastavením `false` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Graf PowerPoint zobrazující popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-true.png) | ![Graf PowerPoint skrývající popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximální hodnotu osy, kterou by bylo možné tímto způsobem omezit.
{{% /alert %}}

## **Nastavit vzdálenost popisku od osy**

Použijte [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) k řízení vzdálenosti mezi popisky kategoriální osy a osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví odsazení popisku vodorovné osy na 500. Toto nastavení ovlivňuje popisky kategoriální osy, nikoli popisky připojené k jednotlivým datovým bodům.

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

## **Upravit umístění popisků**

U koláčového grafu upravte umístění popisků dat, abyste zlepšili rozestupy a vytvořili prostor pro čáry ukazatele.

Tento příklad zobrazí hodnotu prvního datového bodu, umístí jeho popisek mimo výseč a upraví jeho odsazení [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Tato odsazení jsou relativní k šířce a výšce grafu.

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

![Koláčový graf s upraveným umístěním popisku dat](pie-chart-adjusted-label.png)

## **Formátovat čáry ukazatele**

Když jsou popisky koláčového grafu umístěny mimo výseče, čáry ukazatele pomáhají čtenářům přiřadit každou hodnotu ke správné výseči. Kontrastní barva a mírně silnější čára mohou usnadnit sledování těchto spojení, zatímco průhlednost a čárkový styl udržují čáry vizuálně nenápadné.

Použijte [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) k formátování čar ukazatele na úrovni kolekce popisků dat série. Nastavení v `series.Labels.LeaderLinesFormat.Line` se vztahují na celou kolekci, nikoli na jednotlivý popisek.

Tento příklad vytvoří koláčový graf s výchozími daty, zobrazí hodnoty mimo výseče a povolí [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Posune dva popisky dále od jejich výsečí pomocí odsazení [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), vyjádřených jako zlomky šířky a výšky grafu. Není vyžadována žádná vstupní prezentace.

Formát [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) čáry nastaví jednobarevnou modrou barvu s alfa hodnotou 191 ze 255, což poskytuje přibližně 25 % průhlednost. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) nastaví tloušťku na 2 body a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) činí čáru čárkovanou.

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

// Posuňte dva popisky dál od jejich výsečí.
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

Povolení čar ukazatele nezaručuje, že se čára objeví u každého popisku. Viditelnost závisí na umístění popisku a chování rozvržení grafu. V tomto příkladu mají dva posunuté popisky viditelné čáry ukazatele; popisky, které zůstávají blízko svých výsečí, je nepotřebují.

Následující obrázek ukazuje uložený `FormattedLeaderLines.pptx` vykreslený pomocí Aspose.Slides:

![Koláčový graf s modrými, poloprůhlednými čárkovanými čárami ukazatele spojujícími dva vnější popisky s jejich výsečemi](formatted-leader-lines.png)

## **Přidat více řádků popisků nad sloupcový graf**

Tento příklad vytvoří sloupcový graf se dvěma řádky popisků nad oblastí vykreslení. Série A zobrazuje viditelné sloupce, zatímco série B a C poskytují další popisky. Jejich sloupce jsou skryty odstraněním výplně a obrysu. Vlastnost [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) zarovnává všechny tři série se stejnými středy kategorií.

Nastavení [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) vyhrazuje prostor pro řádky popisků. Po výpočtu výchozích pozic funkcí [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) zachovávají [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) vodorovné zarovnání a aplikují svislé odsazení pro uspořádání popisků do dvou řádků. Čísla zůstávají datovými popisky propojenými s hodnotami sérií; pouze nadpisy řádků jsou samostatné textové tvary.

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
        // Skryjte sloupce B a C, ale ponechte jejich popisky dat.
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

// Zarovnejte všechny tři řady na stejné středy kategorií.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Použijte méně mřížkových čar pro tento kompaktní příklad.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Rezervujte prostor nad oblastí vykreslení pro dva řádky popisků dat.
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
        // Zachovejte výchozí vodorovnou pozici. Y je posun od
        // výchozí pozice popisku, vyjádřený jako zlomek výšky grafu.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Pouze záhlaví řádku je samostatný textový tvar.
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

![Sloupcový graf se dvěma řádky popisků nad oblastí kreslení](multiple-rows-of-labels.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**  
Kombinujte automatické umístění popisků, čáry ukazatele a zmenšení velikosti písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**  
Před povolením popisků odfiltrujte datové body a vypněte zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**  
Explicitně nastavte rodinu písma a velikost a ověřte, že písmo je dostupné v prostředí renderování, aby nedošlo k nahrazení.