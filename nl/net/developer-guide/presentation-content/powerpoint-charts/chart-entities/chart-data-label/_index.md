---
title: Beheer grafiekdatapelabels in presentaties in .NET
linktitle: Data-label
type: docs
url: /nl/net/chart-data-label/
keywords:
- grafiek
- data-label
- dataprecisie
- percentage
- labelafstand
- labelpositie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekdatapelabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor .NET voor boeiendere dia's."
---
## **Inleiding**

Data-labels tonen informatie over series en individuele gegevenspunten, zodat lezers waarden kunnen identificeren en de grafiek beter begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, de tussenruimte van de categorie-as-labels kunt aanpassen en labels van een taartdiagram kunt positioneren.

## **Precisie van gegevens instellen in grafiek-data-labels**

Gebruik [NumberFormatOfValues](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/numberformatofvalues/) om seriewaarden op te maken. Deze voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waardelabels in voor de eerste serie. Het format `#,##0.00` geeft een duizendtalseparator en twee decimalen weer zonder de onderliggende waarden te wijzigen.

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

## **Percentage weergeven als labels**

Voor een gestapelde kolomgrafiek berekent u elke waarde als percentage van het totaal van de categorie en kent u de tekst toe aan [TextFrameForOverriding](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en geeft percentages met twee decimalen weer in een lettertype van 8 pt. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst wanneer de grafiekgegevens wijzigen.

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

## **Percentage-teken instellen met grafiek-data-labels**

Wanneer waarden als breuken zijn opgeslagen, gebruikt u [NumberFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/numberformat/) om percentages weer te geven. Stel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) in op `false` om het label-format onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elk paar waarden telt op tot 1. Het label-format `0.0%` toont 0.30 als 30.0% terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst van 10 pt.

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

## **De werkelijke tekst van data-labels lezen**

Gebruik [GetActualLabelText](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/getactuallabeltext/) om de door de instellingen van een data-label geproduceerde tekst op te halen. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie-inhoud of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/) elke categorienaam, serienaam en waarde. Een punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [TextFrameForOverriding](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` weergeeft naast de categorie- en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [GetActualLabelText](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/getactuallabeltext/) retourneert in beide gevallen de resulterende label-string. Controleer [IsVisible](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/isvisible/) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Labelafstand van een as instellen**

Gebruik [LabelOffset](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/iaxis/labeloffset/) om de afstand tussen as-labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as-labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as-labeloffset in op 500. Deze instelling beïnvloedt de as-labels van de categorieën, niet de labels die aan individuele gegevenspunten zijn gekoppeld.

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

## **Labelpositie aanpassen**

Bij een taartgrafiek kunt u de posities van data-labels aanpassen om de tussenruimte te verbeteren en ruimte te maken voor leiderslijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de partitie en past de [X](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ilayoutable/x/) en [Y](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ilayoutable/y/) offsets aan. Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Hoe kan ik voorkomen dat data-labels op elkaar overlappen in drukke grafieken?**

Combineer automatische labelplaatsing, leiderslijnen en een kleinere lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen voor nul, negatieve of lege waarden?**

Filter gegevenspunten vóór het inschakelen van labels en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om fallback te voorkomen.