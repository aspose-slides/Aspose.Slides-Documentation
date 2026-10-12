---
title: Beheer grafiek-gegevenslabels in presentaties in .NET
linktitle: Gegevenslabel
type: docs
url: /nl/net/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labelpositie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiek-gegevenslabels kunt toevoegen en opmaken in PowerPoint‑presentaties met Aspose.Slides voor .NET voor boeiendere dia's."
---
## **Introductie**

Data‑labels tonen informatie over grafiekseries en individuele datapunten, waardoor lezers waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, labels buiten het asmaximum kunt beheren, de afstand tussen categorie‑as‑labels kunt aanpassen en taartgrafiek‑labels kunt positioneren.

## **Stel de gegevensprecisie in bij grafieklabels**

Gebruik [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) om serieswaarden op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de datatabel en schakelt waardelabels in voor de eerste serie. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het categorie‑totaal en kent u de tekst toe aan [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens veranderen.

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

## **Percentage‑teken instellen met grafieklabels**

Wanneer waarden als breuken worden opgeslagen, gebruik dan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) om percentages weer te geven. Stel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) in op `false` om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elke paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst van 10 punten.

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

## **De feitelijke tekst van datalabels lezen**

Gebruik [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) om de tekst op te halen die door de instellingen van een datalabel wordt gegenereerd. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud, of het valideren van gegenereerde grafieken. In het voorbeeld hieronder combineert het standaard [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Het getal dat in een datapunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75 %` toont samen met de categorie‑ en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) retourneert in beide gevallen de resulterende label‑string. Controleer [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) apart, zoals hierboven weergegeven, wanneer u alleen zichtbare labels wilt extraheren.

## **Data‑labels beheren buiten het asmaximum**

Als u een asbereik handmatig beperkt, kunnen sommige datapunten het maximum overschrijden. Gebruik [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) om te bepalen of hun datalabels worden getoond. Deze instelling wijzigt de zichtbaarheid van labels; ze verandert niet het asbereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D geclusterd kolomdiagram met waarden van 60 en 120. Het stelt [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) in op `false` en [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) op 100 voor de verticale as. De eerste dia staat labels toe die het maximum overschrijden; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). De instelling op diagramniveau schakelt de weergave van waarden niet automatisch in en negeert niet een individuele labelinstelling die waarden heeft uitgeschakeld. Dit voorbeeld schakelt waarden in voor de volledige serie en gebruikt [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) om labels aan het buitenstaande uiteinde van elke kolom te plaatsen.

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

De onderstaande afbeeldingen tonen de opgeslagen dia's zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenkant; met `false` is het verborgen. Het label **60** blijft zichtbaar, het asmaximum blijft op **100**, en het tweede datapunt blijft **120** in beide gevallen.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomgrafiek met een waardeas. Grafieken zonder een waardeas, zoals taart‑ en donutgrafieken, hebben geen asmaximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Afstand van label tot as instellen**

Gebruik [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt categorie‑as‑labels in plaats van labels die aan individuele datapunten zijn gekoppeld.

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

Bij een taartgrafiek pas je de posities van datalabels aan om de spatiëring te verbeteren en ruimte te maken voor lijnen.

Dit voorbeeld toont de waarde van het eerste datapunt, plaatst het label buiten de partitie en past de [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)‑offsets aan. Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van het diagram.

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

![Taartgrafiek met een aangepaste datalabelpositie](pie-chart-adjusted-label.png)

## **Meerdere rijen datalabels boven een kolomgrafiek toevoegen**

Dit voorbeeld maakt een kolomgrafiek met twee rijen datalabels boven het tekengebied. Serie A toont de zichtbare kolommen, terwijl Serie B en Serie C de extra labels leveren. Hun kolommen worden verborgen door vulling en omtrek te verwijderen. De eigenschap [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) zorgt ervoor dat alle drie de series op dezelfde categoriebenen worden uitgelijnd.

De instellingen van [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) reserveren ruimte voor de labelrijen. Nadat [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) de standaardposities heeft berekend, behouden [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) en [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) de horizontale uitlijning en passen verticale offsets toe om de labels in twee rijen te rangschikken. De cijfers blijven datalabels die gekoppeld zijn aan de serie‑waarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

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
        // Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
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

// Lijn alle drie series uit op dezelfde categorie‑centra.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Gebruik minder rasterlijnen voor dit compacte voorbeeld.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserveer ruimte boven de plot voor twee rijen gegevenslabels.
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
        // Houd de standaard horizontale positie. Y is een offset ten opzichte van
        // de standaard labelpositie, uitgedrukt als een fractie van de grafiekhoogte.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Alleen de rij‑kop is een apart tekstobject.
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

![Kolomgrafiek met twee rijen datalabels boven het tekengebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat datalabels overlappen bij dichte grafieken?**  
Combineer automatische labelplaatsing, lijnen en een verkleinde lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of belangrijke punten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**  
Filter datapunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij het exporteren naar PDF/afbeeldingen?**  
Stel expliciet het lettertype en de grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om een fallback te voorkomen.