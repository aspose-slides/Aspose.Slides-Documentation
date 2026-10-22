---
title: Beheer grafiekdatereeksen in presentaties in .NET
linktitle: Gegevensreeksen
type: docs
url: /nl/net/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- categorie kleur
- reeksnaam
- datapunt
- reeks gat
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunt, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met C#."
---
## **Overzicht**

Een grafiek kan zijn geplotte waarden opslaan in werkboekcellen of rechtstreeks als numerieke litteraals. Een [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) vertegenwoordigt een punt in die reeks. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)‑objecten leveren de etiketten of groeperingswaarden die door de reeksen gedeeld worden. In grafieken die met standaarddata zijn gemaakt, gebruiken reeksenamen, categorieën en puntwaarden [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)‑objecten uit het grafiek‑werkboek.

Voor een typische categoriëngrafiek gebruikt het standaardwerkboek rij 0 voor reeksenamen, kolom 0 voor categorienamen en de overige cellen voor reeksenwaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer je een grafiek met standaarddata maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat je werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op reekseniveau, zoals [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), leveren de standaardweergave voor alle punten in één reeks.
- Instellingen per datapunt, zoals [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), overschrijven de reeks‑weergave voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) behoren. Toegang tot de groep verkrijg je via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) wanneer je opties zoals overlap of gatbreedte moet instellen.

Wanneer geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Reekswaarden instellen met numerieke litteraals**

Gebruik numerieke litteraals wanneer reeksenwaarden afkomstig zijn uit toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Stel [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) in op [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) vóór het toewijzen van elke punt‑[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) via [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

De collectiesetting bepaalt het brontype van alle puntwaarden in die reeks. Elke punt‑[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) geeft het geselecteerde type weer; wijzig het via de collectiesetting. Met `Worksheet` gebruik je [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) om de gerefereerde cel te benaderen. Met `DoubleLiterals` gebruik je `AsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomgrafiek met standaardreeksen en -categorieën, en kent vervolgens berekende waarden 10, 20, enz. toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw en print de opgeslagen waarden.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Het brontype van de puntwaarde staat los van [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), dat de interne of externe werkboekconfiguratie van de grafiek identificeert. Het gebruik van numerieke litteraals verwijdert op zichzelf niet het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, reeksenamen en de andere reeksen. Zie [Chart Workbook](/slides/nl/net/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbelgrafieken stel je [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) en [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) in om de bronnen voor [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) en [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) te kiezen. Bubbelgrafieken gebruiken ook [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) voor [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Stel elke toepasselijke bron in op `DoubleLiterals` vóór het toewijzen van getallen via de eigenschap `AsLiteralDouble` van die waarde.

## **De overlap van de grafiekreeks instellen**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Stel [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) in om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiektype­s die gegroepeerde balken of kolommen tonen; hij beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatietype.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Resultaat:

![The series overlap](series_overlap.png)

## **De vullingskleur van de reeks wijzigen**

Gebruik [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Resultaat:

![The color of the series](series_color.png)

## **De reeksnaam wijzigen**

Een reeksennaam wordt opgeslagen in het grafiek‑datwerkboek en normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, staat cel B1 op rij 0, kolom 1 en bevat zij de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Je kunt ook de cel bijwerken waarnaar [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) al verwijst. Deze aanpak vermijdt aannames over een bepaalde rij of kolom in een bestaande grafiek:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Resultaat:

![The series name](series_name.png)

### **Een reeks maken met een naam uit meerdere cellen**

Een samengestelde reeksennaam is nuttig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen staan. Bijvoorbeeld kun je `Product A` in B1 en `2026` in C1 combineren tot één reeksennaam, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) om het naam‑bereik op te halen, en geef die collectie door aan [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen inbegrepen worden: `true` sluit ze uit, `false` neemt ze op. In dit voorbeeld wordt `false` gebruikt om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapunten. Cellen B1:C1 leveren uitsluitend de reeksennaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Deze twee cellen leveren de reeksnaam.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Aparte cellen leveren de categorieën en numerieke datapuntwaarden.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

De resulterende reeksennaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één invoer voor beide kolommen. De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **De automatische vullingskleur van de reeks ophalen**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) retourneert de kleur die is berekend op basis van het reeks‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld print de automatische kleur van elke standaardreeks:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Inverted‑vullingkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) negatieve waarden weergeven met een andere vulling. Stel de gewone reeksvulling in op effen, schakel inversie in en wijs de negatieve‑waardekleur toe via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekdata door één reeks. Werkbladrij 0 bevat de reeksennaam, kolom 0 de categorienamen, en kolom 1 de waarden:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In het volgende voorbeeld wordt inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Een specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `null`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Spreidingsgrafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert alle datapunt‑collecties.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen werkbladrijen en -kolommen wel of niet op te nemen, zie [Include Data from Hidden Rows and Columns](/slides/nl/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel vertegenwoordigt ontbrekende data; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Stel [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) in op `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Hij verandert hoe lege waarden geplot worden, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3 en slaat dezelfde grafiek op met elk van de modi. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksennaam. De uiteindelijke data zijn `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Elk uitvoerbestand bevat de modus die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stel je de gewenste modus in en sla je de presentatie één keer op in plaats van over de modi te itereren.

De onderstaande vergelijking toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, waardoor `Span` niet het verbindingssegment kan produceren dat hierboven te zien is; een missende kolom en een kolom met nul hoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet dat elke grafiek drie duidelijke resultaten oplevert; controleer de output voor het type dat je gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende reeksgroep en niet tot één enkele reeks. Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) eenmalig in voor de groep. Een grotere waarde creëert meer ruimte tussen de clusters; een kleinere waarde maakt ze dichter opeen.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektype­s ondersteunen datreeksen?**

Alle grafiektype­s die door de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken grafiekdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld categoriëngrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datapuntcreatiemethode die past bij het type reeks. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau‑plotinstellingen delen. Een combinatietype kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaarddata?**

Ja. Standaard maakt [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeksen‑ als de categorieverzamelingen wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaarddata maken.

**Hoe zijn grafiekobjecten verbonden met werkboekcellen?**

Reeksenamen, categorielabels en datapuntwaarden refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer je aangepaste data maakt, houd dan de rijen voor categorieën en de rijen voor reeks‑waarden op één lijn zodat elk punt onder de juiste categorie geplot wordt.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `null` om de punt‑categoriepositie te behouden als een leeg punt. Gebruik [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden op één lijn blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nulwaardes, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen kun je [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) inschakelen en [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) instellen. Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Deze eigenschappen beïnvloeden alleen de opmaak, niet de opgeslagen getallen.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en thema. Groepseigenschappen zoals overlap en gatbreedte regelen de lay‑out en zijn geen punt‑niveau‑opmaakoverschrijvingen.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op het aantal reeksen. In de praktijk bepalen bestands‑beperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een nuttige grens.

**Wat moet ik aanpassen wanneer kolommen te dicht of te ver van elkaar staan?**

Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen de clusters te vergroten, of verlaag de waarde om de clusters dichter bij elkaar te brengen.