---
title: Správa popisků dat v grafu v prezentacích v .NET
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
description: "Naučte se přidávat a formátovat popisky dat v grafech v PowerPoint prezentacích pomocí Aspose.Slides pro .NET pro poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o řadách grafu a jednotlivých datových bodech, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, upravit rozestupy popisků os kategorií a umístit popisky výsečového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [NumberFormatOfValues](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/numberformatofvalues/) k formátování hodnot řad. Tento příklad vytváří čárový graf s výchozími daty, zobrazuje jeho datovou tabulku a povoluje popisky hodnot pro první řadu. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

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

Pro sloupcový graf s naskládanými hodnotami vypočítejte každou hodnotu jako procento celkového součtu své kategorie a přiřaďte text pomocí [TextFrameForOverriding](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu o velikosti 8 bodů. Kategorie s nulovým součtem jsou přeskočeny, aby se zabránilo dělení nulou. Pokud se data grafu změní, přepočítejte vlastní text popisku.

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

## **Nastavení procentního symbolu v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [NumberFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabelformat/numberformat/) k zobrazení procent. Nastavte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `false`, aby se formát popisku použil nezávisle na zdrojových buňkách.

Tento příklad vytváří 100 % sloupcový graf s naskládanými řadami v červené a modré barvě napříč čtyřmi kategoriemi. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0.30 jako 30,0 %, zatímco svislá osa používá dvě desetinná místa. Obě řady používají bílý popisek o velikosti 10 bodů.

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

Použijte [GetActualLabelText](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabel/getactuallabeltext/) k získání textu vytvořeného nastavením popisku dat. To se hodí při extrahování popisků do zpráv, vyhledávání v obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [formát popisku dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabelformat/) kombinuje název každé kategorie, název řady a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [TextFrameForOverriding](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Číslo uložené v datovém bodu zůstává `0.75`, i když jeho popisek zobrazuje `75%` spolu s názvem kategorie a řady. Vlastní text nahrazuje vygenerovaný text popisku. [GetActualLabelText](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabel/getactuallabeltext/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [IsVisible](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatalabel/isvisible/) samostatně, jak je uvedeno výše, pokud chcete extrahovat jen viditelné popisky.

## **Nastavení vzdálenosti popisku od osy**

Použijte [LabelOffset](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/iaxis/labeloffset/) k řízení vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je vyjádřena v procentech maximální velikosti písma popisků osy. Tento příklad vytváří seskupený sloupcový graf a nastavuje offset popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

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

## **Úprava umístění popisků**

U výsečového grafu upravte umístění popisků dat, aby se zlepšily mezery a vytvořil se prostor pro vodící čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho offsety [X](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ilayoutable/x/) a [Y](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ilayoutable/y/). Tyto offsety jsou relativní k šířce a výšce grafu, resp.

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

![Výsečový graf s upraveným umístěním popisku dat](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat u hustých grafů?**

Kombinujte automatické umístění popisků, vodící čáry a zmenšení velikosti písma; pokud je potřeba, skryjte některá pole (například kategorii) nebo zobrazte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky jen pro nulové, záporné nebo prázdné hodnoty?**

Před povolením popisků filtrujte datové body a vypněte jejich zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit jednotný styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte rodinu písma a velikost a ověřte, že je písmo k dispozici v prostředí renderování, aby nedošlo k náhradnímu písmu.