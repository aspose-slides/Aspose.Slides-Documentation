---
title: Správa popisků dat v grafech v prezentacích v .NET
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
description: "Naučte se přidávat a formátovat popisky dat v grafech v prezentacích PowerPoint pomocí Aspose.Slides pro .NET a vytvořit tak poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o sériích grafu a jednotlivých bodech dat, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazit procenta, číst text popisků, řídit popisky nad maximem osy, upravit rozestupy popisků osy kategorií a umístit popisky koláčového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) k formátování hodnot sérií. Tento příklad vytvoří čárový graf s výchozími daty, zobrazí jeho datovou tabulku a povolí popisky hodnot pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

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

## **Zobrazení procent jako popisků**

Pro sloupcový graf se zásobníkem vypočítejte každou hodnotu jako procento celkového součtu v kategorii a přiřaďte text pomocí [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu 8 bodů. Kategorie s nulovým součtem jsou přeskočeny, aby se předešlo dělení nulou. Při změně dat grafu přepočítejte vlastní text popisku.

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

## **Nastavení procentního znaménka v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) k zobrazení procent. Nastavte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `false`, aby se formát popisku použil nezávisle na buňkách zdroje.

Tento příklad vytvoří sloupcový graf se 100% zásobníkem s červenou a modrou sérií ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0,30 jako 30,0 %, zatímco vertikální osa používá dvě desetinná místa. Obě série používají bílý popisek o velikosti 10 bodů.

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

## **Načtení skutečného textu popisků dat**

Použijte [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) k získání textu vytvořeného nastavením popisku dat. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování generovaných grafů. V níže uvedeném příkladu výchozí [formát popisku dat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) kombinuje název každé kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a jiný používá vlastní text z [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a série. Vlastní text nahrazuje vygenerovaný text popisku. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) samostatně, jak je ukázáno výše, pokud chcete extrahovat pouze viditelné popisky.

## **Řízení popisků dat nad maximem osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) k ovládání, zda jsou jejich popisky dat zobrazeny. Toto nastavení mění viditelnost popisků; nemění rozsah osy ani podkladové hodnoty dat.

Níže uvedený příklad vytvoří 2D seskupený sloupcový graf s hodnotami 60 a 120. Nastaví [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) na `false` a [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) na 100 na svislé ose. první snímek umožňuje popisky přesahující maximum; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v souboru `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Nastavení na úrovni grafu samo o sobě nezpůsobí zobrazení hodnot ani nepřepíše vypnuté zobrazení hodnot u jednotlivých popisků. Tento příklad povoluje hodnoty pro celou sérii a používá [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) k umístění popisků na vnější konec každého sloupce.

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

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPoint. S `true` je popisek **120** viditelný na horní hranici; s `false` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Graf PowerPoint zobrazující popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-true.png) | ![Graf PowerPoint skrývající popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Typ grafu" %}}

Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximální hodnotu osy, kterou by bylo možné tímto způsobem omezovat.

{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) k řízení vzdálenosti mezi popisky osy kategorií a osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví odsazení popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky přiřazené jednotlivým datovým bodům.

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

## **Úprava umístění popisku**

U koláčového grafu upravte pozice datových popisků, aby se zlepšil rozestup a vytvořilo místo pro vodící čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho posuny [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Tyto posuny jsou relativní k šířce a výšce grafu, respektive.

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

![Koláčový graf s upravenou pozicí datového popisku](pie-chart-adjusted-label.png)

## **Formátování vodících čar**

Když jsou popisky koláčového grafu umístěny mimo výseče, vodící čáry pomáhají čtenářům přiřadit každou hodnotu ke správné výseči. Kontrastní barva a mírně silnější čára mohou tyto spojení usnadnit, zatímco průhlednost a čárkový styl udržují čáry vizuálně nenápadné.

Použijte [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) k formátování vodících čar na úrovni kolekce datových popisků série. Nastavení v `series.Labels.LeaderLinesFormat.Line` se vztahují na celou kolekci, nikoli na jednotlivý popisek.

Tento příklad vytvoří koláčový graf s výchozími daty, zobrazí hodnoty mimo výseče a povolí [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Posune dva popisky dále od jejich výsečí pomocí posunů [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), vyjádřených jako podíly šířky a výšky grafu. Vstupní prezentace není vyžadována.

Formát [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) nastavení čáry nastaví plnou modrou barvu s alfa hodnotou 191 z 255, což dává přibližně 25 % průhlednost. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) nastaví tloušťku na 2 body a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) udělá čáru čárkovanou.

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

// Přesunout dva popisky dál od jejich výsečů.
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

Povolení vodících čar nezaručuje, že se čára zobrazí u každého popisku. Viditelnost závisí na umístění popisku a chování rozvržení grafu. V tomto příkladu mají dva posunuté popisky viditelné vodící čáry; popisky, které zůstávají blízko svých výsečí, je nepotřebují.

Následující obrázek ukazuje uložený soubor `FormattedLeaderLines.pptx` vykreslený pomocí Aspose.Slides:

![Koláčový graf s modrými, poloprůhlednými čárkovanými vodícími čárami spojujícími dva vnější popisky s jejich výsečemi](formatted-leader-lines.png)

## **Přidání více řádků popisků dat nad sloupcový graf**

Tento příklad vytvoří sloupcový graf se dvěma řádky popisků dat nad oblastí vykreslování. Série A zobrazuje viditelné sloupce, zatímco Série B a Série C poskytují další popisky. Jejich sloupce jsou skryté odstraněním výplně a obrysu. Vlastnost [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) zarovnává všechny tři série na stejné středy kategorií.

Nastavení [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) rezervuje prostor pro řádky popisků. Po výpočtu výchozích pozic metodou [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) zachovávají vodorovné zarovnání a aplikují svislé posuny k uspořádání popisků do dvou řad. Čísla zůstávají popisky dat propojenými s hodnotami sérií; jen nadpisy řádků jsou samostatné textové tvary.

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
        // Skryjte sloupce B a C, ale zachovejte jejich popisky dat.
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

// Zarovnat všechny tři série na stejné středy kategorií.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Použít méně mřížek pro tento kompaktní příklad.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Vyhradit místo nad oblastí vykreslování pro dva řádky popisků dat.
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
        // Zachovat výchozí vodorovnou pozici. Y je posun od
        // výchozí pozice popisku, vyjádřeno jako zlomková část výšky grafu.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Pouze nadpis řádku je samostatný textový tvar.
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

![Sloupcový graf se dvěma řádky popisků dat nad oblastí vykreslování](multiple-rows-of-labels.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**  
Kombinujte automatické umístění popisků, vodící čáry a zmenšenou velikost písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**  
Filtrovat datové body před povolením popisků a vypnout zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**  
Explicitně nastavte rodinu písma a velikost a ověřte, že je písmo dostupné v prostředí vykreslování, aby se předešlo náhradnímu písmu.