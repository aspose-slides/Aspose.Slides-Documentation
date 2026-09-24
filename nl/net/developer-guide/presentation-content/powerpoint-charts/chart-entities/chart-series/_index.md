---
title: Beheer diagramseries in presentaties in .NET
linktitle: Gegevensreeksen
type: docs
url: /nl/net/chart-series/
keywords:
- diagramseries
- overlap van series
- kleur van series
- kleur van categorie
- serienaam
- gegevenspunt
- gap tussen series
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u diagramseries, gegevenspunten, werkbladcellen, opmaak, overlap, breedte van de tussenruimte en negatieve waarden in presentaties beheert met C#."
---
## **Overzicht**

Een diagram slaat zijn geplotte gegevens op in een diagramgegevens‑werkmap. Een [IChartSeries](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [IChartDataPoint](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/) in de serie verwijst naar één of meer werkbladcellen. [IChartCategory](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartcategory/) objecten leveren de labels of groeperingswaarden die door de series worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/) objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categorie‑diagram gebruikt de standaard werkmap rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor series‑waarden. Werkblad‑, rij‑ en kolom‑indexen die aan [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/getcell/) worden doorgegeven zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie inspecteert u de cellen waarnaar de series, categorieën en gegevenspunten verwijzen voordat u werkmapwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/), bepalen de standaardweergave voor alle punten in één serie.
- Instellingen per gegevenspunt, zoals [IChartDataPoint.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/format/), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/) behoren. Toegang tot de groep krijgt u via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/parentseriesgroup/) wanneer u opties zoals overlap of gap width wilt instellen.

Wanneer er geen expliciete punt‑ of series‑vulling is ingesteld, bepalen het diagramstijl en thema de automatische weergave. Wanneer zowel series‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voor dat punt prioriteit.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van diagramseries**

[IChartSeries.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/overlap/) geeft weer hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende series‑groep. Stel [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/overlap/) in om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; ze heeft geen invloed op ongerelateerde series‑groepen in een combinatie‑diagram.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Het nieuwe diagram bevat voorbeeldseries, categorieën en waarden.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The series overlap](series_overlap.png)

## **Wijzig de vulkleur van de serie**

Gebruik [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.Format]-instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

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

Het resultaat:

![The color of the series](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in de diagramgegevens‑werkmap en wordt normaal gesproken weergegeven in de legenda. In de standaard werkmap die wordt aangemaakt voor een gegroepeerde kolomdiagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel die al wordt geraadpleegd door [IChartSeries.Name](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/name/) bijwerken. Deze aanpak voorkomt dat u een bepaalde rij en kolom in een bestaand diagram aanneemt:

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

Het resultaat:

![The series name](series_name.png)

## **Haal de automatische vulkleur van de serie op**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) retourneert de kleur die wordt berekend op basis van de seriële index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld print de automatische kleur van elke standaard serie:

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

Voorbeeldoutput voor de standaard diagramstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel omgekeerde vulkleur in voor een diagramserie**

Voor balk‑, kolom‑ en bubbel‑series kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de reguliere serie‑vulling in op solide, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één serie. Werkblad rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Het resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Wis een specifieke gegevenspuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkmapcel in op `null`. Voor een kolomdiagram is de geplotte waarde beschikbaar via [IChartDataPoint.YValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/yvalue/). Het gegevenspunt blijft op dezelfde categorpositie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

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

Scatter‑diagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de collectie.

## **Regel de weergave van lege cellen**

Een lege werkmapcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Stel [IChartDataCell.Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/) in op `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/displayblanksas/) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Het verandert hoe lege waarden worden geplot, zonder de lege werkmapcel met nul of een geïnterpoleerde waarde te vullen.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één serie, wist de waarde voor Dag 3 en slaat hetzelfde diagram op met elke modus. Er is geen invoer‑bestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is toegewezen: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijst u de gewenste modus toe en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in de werkmap in elk geval leeg:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `Span` kan niet het verbintningssegment tonen dat hierboven is weergegeven; een ontbrekende kolom en een kolom met hoogte nul kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑diagram met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat u gebruikt.

## **Instellen van de breedte van de gap‑breedte van de serie**

De gap‑breedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze tot de bovenliggende series‑groep en niet tot één serie. Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) één keer in voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld verandert de gap‑breedte en slaat alleen de definitieve presentatie op:

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

Het resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die worden weergegeven door de [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/)-enumeratie gebruiken diagramgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, scatter‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het aanmaken van gegevenspunten die overeenkomt met het serietype. Opties zoals overlap en gap‑breedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramseries‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet per se elke serie in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.AddChart](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addchart/) voorbeeldseries, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de series‑ als de categorie‑collecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkmapcellen?**

Serienamen, categorie‑labels en gegevenspuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een geraadpleegde cel werkt het corresponderende diagram‑element bij. Wanneer u aangepaste gegevens opbouwt, houdt u de categorie‑rijen en de serie‑waarde‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de betreffende waardecel in op `null` om de categorpositie van het punt te behouden als een leeg punt. Gebruik [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden aligned blijven met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/displayblanksas/). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Regel de weergave van lege cellen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series schakelt u [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) in en stelt u [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) in. U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken, of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groeps‑eigenschappen zoals overlap en gap‑breedte regelen de lay‑out en zijn geen opmaak‑overschrijvingen op punt‑niveau.

**Is er een limiet voor het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in op de juiste bovenliggende series‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.