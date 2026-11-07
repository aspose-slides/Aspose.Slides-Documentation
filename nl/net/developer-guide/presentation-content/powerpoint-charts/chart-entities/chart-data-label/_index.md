---
title: Beheer grafiekdatapuntlabels in presentaties in .NET
linktitle: Datapuntlabel
type: docs
url: /nl/net/chart-data-label/
keywords:
- grafiek
- datapuntlabel
- dataprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekdatapuntlabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor .NET voor meer boeiende dia's."
---
## **Inleiding**

Datapuntenlabels geven informatie weer over grafiekseries en individuele datapunten, waardoor lezers waarden kunnen identificeren en de grafiek beter begrijpen. Dit artikel legt uit hoe u waarden opmaakt, percentages weergeeft, labeltekst uitleest, labels buiten de asmaximum regelt, de tussenruimte van assenlabels aanpast en labels van een cirkeldiagram positioneert.

## **Aantal zichtbare datalabels tellen**

Gebruik [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) om te controleren hoeveel datalabels zijn ingeschakeld voor weergave vóór het publiceren van een presentatie. In tegenstelling tot [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/), dat het totale aantal labels in de collectie retourneert, houdt dit rekening met de standaardinstellingen van de serie en individuele labelinstellingen.

Dit voorbeeld maakt een kolomgrafiek met één serie en drie datapunten. Het benadert de [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/)‑collectie van de serie en drukt de zichtbare telling af terwijl de instellingen veranderen: **0, 3, 2, 3**. Het totale aantal blijft **3**.

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
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Totaal: 3; zichtbaar: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Zichtbaar: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Zichtbaar: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Zichtbaar: 3
```

De [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) van de serie levert de standaardinstellingen. Het inschakelen van [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) daar toont waarden voor alle drie de labels. Door het op `false` te zetten via de [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) van één label, wordt die instelling voor het geselecteerde label overschreven. Het inschakelen van [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) zorgt ervoor dat dat label weer als zichtbaar wordt geteld, hoewel de waarde verborgen blijft.

De zichtbare telling weerspiegelt de zichtbaarheidsinstellingen. Het meet niet of labels overlappen, afgesneden zijn of leesbaar in de gerenderde grafiek.

## **Precisie van waarden in grafiekdatapuntlabels instellen**

Gebruik [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) om de waarden van een serie op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de datatabel en schakelt waardelabels in voor de eerste serie. Het formaat `#,##0.00` toont een duizendtallenscheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

Om de numerieke cellen in het ingebedde werkboek van een grafiek op te maken, zie [Set Custom Number Formats for Workbook Cells](/slides/nl/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Dat voorbeeld laat ook zien hoe waardelabels de opmaak van hun broncellen overnemen terwijl de opgeslagen numerieke waarden behouden blijven.

## **Percentage als label weergeven**

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het totaaltal van zijn categorie en kent u de tekst toe aan [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑teken instellen bij grafiekdatapuntlabels**

Wanneer waarden als breuken zijn opgeslagen, gebruikt u [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) om percentages weer te geven. Stel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) in op `false` om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0.30 als 30.0 %, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte, 10‑punt labeltekst.

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

## **De feitelijke tekst van datapuntlabels uitlezen**

Gebruik [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) om de door een labelinstelling gegenereerde tekst op te halen. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert zijn waarde als een percentage, en een ander gebruikt aangepaste tekst uit [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Het getal dat is opgeslagen in een datapunt blijft `0.75`, zelfs wanneer het label `75%` toont naast de categorie‑ en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) retourneert in beide gevallen de resulterende labelreeks. Controleer [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Datapuntlabels buiten de asmaximum regelen**

Wanneer u een asbereik handmatig beperkt, kunnen sommige datapunten de maximumwaarde overschrijden. Gebruik [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) om te bepalen of hun datapuntlabels worden getoond. Deze instelling wijzigt de label‑zichtbaarheid; ze verandert niet het asbereik of de onderliggende gegevenswaarden.

Het voorbeeld hieronder maakt een 2D gegroepeerde kolomgrafiek met waarden 60 en 120. Het stelt [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) in op `false` en [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) op 100 voor de verticale as. De eerste dia staat labels toe voorbij het maximum; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). De instelling op diagramniveau activeert de weergave van waarden niet zelfstandig en overschrijft geen afzonderlijk uitgeschakeld label. Dit voorbeeld schakelt waarden in voor de volledige serie en gebruikt [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) om labels aan het buitenuiteinde van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia’s gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar bij de bovenste grens; met `false` is het verborgen. Het label **60** blijft zichtbaar, het as‑maximum blijft op **100**, en het tweede datapunt blijft **120** in beide gevallen.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Grafiektype" %}}

Dit voorbeeld gebruikt een 2D kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutgrafieken, hebben geen asmaximum dat op deze manier kan worden beperkt.

{{% /alert %}}

## **Labelafstand tot een as instellen**

Gebruik [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) om de afstand tussen categorielabels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de aslabels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de categorielabels en niet de labels die aan individuele datapunten zijn gekoppeld.

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

## **Labellocatie aanpassen**

Op een taartgrafiek kunt u de positie van datapuntlabels aanpassen om de tussenruimte te verbeteren en ruimte te maken voor leidingslijnen.

Dit voorbeeld toont de waarde van het eerste datapunt, plaatst zijn label buiten de sector en past de [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)‑offsets aan. Deze offsets zijn relatief ten opzichte van respectievelijk de breedte en hoogte van de grafiek.

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

## **Leidingslijnen opmaken**

Wanneer taartgrafieklabels buiten hun sectoren staan, helpen leidingslijnen lezers om elke waarde aan de juiste sector te koppelen. Een contrasterende kleur en een iets dikkere lijn maken die verbindingen gemakkelijker te volgen, terwijl transparantie en een gestippelde stijl de lijnen visueel onopvallend houden.

Gebruik [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) om leidingslijnen op serie‑niveau van de datapuntlabel‑collectie op te maken. De instellingen in `series.Labels.LeaderLinesFormat.Line` gelden voor de gehele collectie, niet voor een individueel label.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens, toont waarden buiten de sectoren en schakelt [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) in. Het verplaatst twee labels verder van hun sectoren met behulp van [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)‑offsets, uitgedrukt als breuken van de breedte en hoogte van de grafiek. Er is geen invoerpresentatie vereist.

De [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) van de lijn stelt een solide blauwe kleur in met een alfa‑waarde van 191 van 255, wat ongeveer 25 % transparantie oplevert. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) zet de dikte op 2 punten, en [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) maakt de lijn gestippeld.

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

// Verplaats twee labels verder van hun sectoren.
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

Het inschakelen van leidingslijnen garandeert niet dat er voor elk label een lijn verschijnt. De zichtbaarheid hangt af van de labelplaatsing en het layout‑gedrag van de grafiek. In dit voorbeeld hebben de twee verplaatste labels zichtbare leidingslijnen; de labels die dicht bij hun sectoren blijven, hebben ze niet nodig.

De volgende afbeelding toont het opgeslagen `FormattedLeaderLines.pptx` gerenderd met Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Meerdere rijen datapuntlabels boven een kolomgrafiek toevoegen**

Dit voorbeeld maakt een kolomgrafiek met twee rijen datapuntlabels boven het plot‑gebied. Serie A toont de zichtbare kolommen, terwijl Serie B en Serie C de extra labels leveren. Hun kolommen worden verborgen door de vulling en omtrek te verwijderen. De [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)‑eigenschap brengt alle drie series op dezelfde categoriebenedenlijnen.

De [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/)‑instellingen reserveren ruimte voor de labelrijen. Na het berekenen van de standaardposities met [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) behouden [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)‑offsets de horizontale uitlijning en passen ze verticale offset toe om de labels in twee rijen te rangschikken. De cijfers blijven datapuntlabels gekoppeld aan de seriewaarden; alleen de rij‑koppen zijn aparte tekstvormen.

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
        // Verberg de kolommen van B en C, maar behoud hun datapuntlabels.
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

// Lijn alle drie series uit met dezelfde categoriebenedenlijnen.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Gebruik minder rasterlijnen voor dit compacte voorbeeld.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserveer ruimte boven het plotgebied voor twee rijen datapuntlabels.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Vorm van datapuntlabels wijzigen**

Aspose.Slides for .NET 26.11 voegt [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) toe voor één label en [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) voor alle huidige labels in een serie. Deze wijzigen de vorm van het label, niet de puntmarkering. Voor de afzonderlijke balloon‑instelling, zie [Data Label Callouts](/slides/nl/net/callout/).

De toewijzing op collectieniveau werkt bestaande labels bij, dus pas individuele overschrijvingen **na** de collectietoewijzing toe. Dit volledige voorbeeld vereist [Aspose.Slides for .NET](/slides/nl/net/installation/) 26.11 of later. Het maakt zichtbare waardelabels, selecteert ellipsen voor de eerste serie en maakt vervolgens het eerste label rechthoekig.

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

// Reset de expliciete vormkeuzes op alle huidige labels.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

Het opnieuw toewijzen van de collectievorm vervangt ook eerdere individuele vormkeuzes. [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) wist de expliciete vormselectie; het verbergt de labels niet en wist hun andere opmaak niet. Stel de gewenste vormen in nadat de serie is gepopuleerd in plaats van aan te nemen dat later toegevoegde punten een eerdere toewijzing overerven. Rectangle en Ellipse worden hier gebruikt; inspecteer het gerenderde resultaat bij het kiezen van andere vormtypen.

## **FAQ**

**Hoe kan ik voorkomen dat datapuntlabels overlappen in dichte grafieken?**

Combineer automatische labelplaatsing, leidingslijnen en een kleinere lettergrootte; schakel eventueel sommige velden (bijv. de categorie) uit of toon labels alleen voor extreme of belangrijke waarden.

**Hoe kan ik labels alleen uitschakelen voor nul‑, negatieve of lege waarden?**

Filter datapunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om fallback te voorkomen.