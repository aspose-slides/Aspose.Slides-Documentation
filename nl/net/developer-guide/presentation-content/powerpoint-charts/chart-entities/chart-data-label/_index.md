---
title: Beheer grafiekgegevenslabels in presentaties in .NET
linktitle: Gegevenslabel
type: docs
url: /nl/net/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor .NET voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekreeksen en individuele gegevenspunten, waardoor lezers de waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, labels kunt beheersen buiten de maximale as, de afstand tussen categorie‑as‑labels kunt aanpassen en taartgrafieklabels kunt positioneren.

## **Precisie van gegevens instellen in grafiekgegevenslabels**

Gebruik [NumberFormatOfValues](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/numberformatofvalues/) om reeksenwaarden op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waardenlabels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het totale aantal van de categorie en kent u de tekst toe aan [TextFrameForOverriding](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑teken instellen met grafiekgegevenslabels**

Wanneer waarden als breuken worden opgeslagen, gebruikt u [NumberFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/numberformat/) om percentages weer te geven. Stel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) in op `false` om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100% gestapelde kolomgrafiek met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0%, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

## **De daadwerkelijke tekst van gegevenslabels lezen**

Gebruik [GetActualLabelText](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/getactuallabeltext/) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatietekst of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als een percentage, en een ander gebruikt aangepaste tekst van [TextFrameForOverriding](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` weergeeft samen met de categorie‑ en reeksenamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [GetActualLabelText](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/getactuallabeltext/) retourneert de resulterende labelreeks in beide gevallen. Controleer [IsVisible](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabel/isvisible/) afzonderlijk, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Gegevenslabels buiten de asmaximum beheersen**

Wanneer u een asbereik handmatig beperkt, kunnen sommige gegevenspunten de maximumwaarde overschrijden. Gebruik [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) om te bepalen of hun gegevenslabels worden weergegeven. Deze instelling wijzigt de zichtbaarheid van labels; het verandert niet het asbereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D gegroepeerde kolomgrafiek met waarden van 60 en 120. Het stelt [IsAutomaticMaxValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) in op `false` en [MaxValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/iaxis/maxvalue/) op 100 voor de verticale as. De eerste dia staat labels toe boven het maximum; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waarde‑labels in met [ShowValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/showvalue/). De instelling op grafiekniveau activeert niet automatisch het weergeven van waarden en overschrijft geen individuele labelinstelling die waardebereik uitschakelt. Dit voorbeeld activeert waarden voor de hele reeks en gebruikt [Position](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/position/) om labels aan het buitenste eind van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia's zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar bij de bovenste grens; met `false` is het verborgen. Het label **60** blijft zichtbaar, het asmaximum blijft op **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint‑grafiek die het waardenlabel 120 toont met een asmaximum van 100](data-labels-over-maximum-true.png) | ![PowerPoint‑grafiek die het waardenlabel 120 verbergt met een asmaximum van 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D‑kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutsgrafieken, hebben geen asmaximum dat op deze manier beperkt kan worden.
{{% /alert %}}

## **Afstand van label tot as instellen**

Gebruik [LabelOffset](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/iaxis/labeloffset/) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de categorie‑as‑labels in plaats van de labels die aan individuele gegevenspunten zijn gekoppeld.

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

Pas op een taartgrafiek de posities van gegevenslabels aan om de afstand te verbeteren en ruimte te maken voor verbindingslijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst zijn label buiten de segment en past de [X](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ilayoutable/x/) en [Y](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ilayoutable/y/) offsets aan. Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

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

![Taartgrafiek met een aangepaste labelpositie](pie-chart-adjusted-label.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen op dichtbevolkte grafieken?**

Combineer automatische labelplaatsing, verbindingslijnen en een verkleinde lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme waarden of belangrijke punten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**

Filter gegevenspunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij exporteren naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om terugval te voorkomen.