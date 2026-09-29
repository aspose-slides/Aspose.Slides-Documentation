---
title: Beheer diagramreeksen in presentaties in .NET
linktitle: Gegevensreeks
type: docs
url: /nl/net/chart-series/
keywords:
- diagramreeks
- reeks overlap
- reeks kleur
- categorie kleur
- reeksnaam
- gegevenspunt
- reeks tussenruimte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u diagramreeksen, gegevenspunten, werkboekcellen, opmaak, overlap, breedte van de tussenruimte en negatieve waarden in presentaties beheert met C#."
---
## **Overzicht**

Een diagram slaat zijn geplotte gegevens op in een werkboek voor diagramgegevens. Een [IChartSeries](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/) vertegenwoordigt één reeks gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [IChartCategory](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartcategory/)‑objecten leveren de labels of groepeerwaarden die door de reeksen worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categoriediagram gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen, en de overige cellen voor seriewaarden. Werkblad‑, rij‑ en kolomindexen die aan [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/getcell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram het gebruikt. Voor een geladen presentatie, inspecteer de cellen die door de reeksen, categorieën en gegevenspunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende reikwijdtes:

- Instellingen op serieniveau, zoals [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/), bieden de standaardweergave voor alle punten in één reeks.
- Instellingen voor gegevenspunten, zoals [IChartDataPoint.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/format/), overschrijven de serieweergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/) behoren. Toegang tot de groep via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/parentseriesgroup/) wanneer u opties moet instellen zoals overlap of breedte van de tussenruimte.

Wanneer geen expliciete punt‑ of serievulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel serie‑ als puntformattering aanwezig zijn, heeft de puntformattering voorrang voor dat punt.

![diagramreeks-PowerPoint](chart-series-powerpoint.png)

## **Stel de Overlap van de Diagramreeks in**

[IChartSeries.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/overlap/) geeft aan hoeveel staven of kolommen overlappen in een 2D-diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriegroep. Stel [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/overlap/) in om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde staven of kolommen weergeven; hij beïnvloedt geen niet‑verwante seriegroepen in een combinatiediagram.

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

// Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De reeks overlap](series_overlap.png)

## **Wijzig de Vullingkleur van de Reeks**

Gebruik [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/) om de standaardvulling voor een hele reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/format/)‑instelling de reeksvulling voor dat punt.

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

Het resultaat:

![De kleur van de reeks](series_color.png)

## **Wijzig de Naam van de Reeks**

Een reeksnamen wordt opgeslagen in het werkboek voor diagramgegevens en wordt meestal weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerd kolomdiagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel die al wordt gerefereerd door [IChartSeries.Name](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/name/) bijwerken. Deze benadering voorkomt dat u een specifieke rij en kolom in een bestaand diagram aanneemt:

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

![De reeksnaam](series_name.png)

## **Haal de Automatische Vullingskleur van de Reeks op**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) geeft de kleur terug die berekend is op basis van de seriële index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardreeks:

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

Voorbeelduitvoer voor de standaarddiagramstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel Inversie Vullingskleur in voor een Diagramreeks**

Voor staaf-, kolom- en bubbelreeksen kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op effen, schakel inversie in, en ken de kleur voor negatieve waarden toe via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één reeks. Werkblad rij 0 bevat de reeksnamen, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde effen vullingskleur](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Wis een Specifieke Gegevenspuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de geplotte waarde beschikbaar via [IChartDataPoint.YValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/yvalue/). Het gegevenspunt blijft op dezelfde categorische positie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een groottecel. Wis alleen de cel die de waarde bevat die u wilt verwijderen. Roep [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de verzameling.

## **Beheer de Weergave van Lege Cellen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens van verborgen werkbladrijen en -kolommen op te nemen of uit te sluiten, zie [Include Data from Hidden Rows and Columns](/slides/nl/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel vertegenwoordigt ontbrekende gegevens; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Stel [IChartDataCell.Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/) in op `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/displayblanksas/) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Het verandert hoe lege waarden worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is toegewezen: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De onderstaande vergelijking toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijndiagrammen met identieke gegevens: Gap breekt de lijn bij Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Staaf‑ en kolomdiagrammen hebben geen lijn om te verbinden over een ontbrekende categorie, dus `Span` kan het bovenstaande verbindingssegment niet produceren; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook op lijken. Evenzo heeft een spreidingsdiagram met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat u gebruikt.

## **Stel de Tussenruimte van de Reeks in**

Tussenruimte is de ruimte tussen aangrenzende staaf‑ of kolomclusters, uitgedrukt als een percentage van de breedte van de staaf of kolom. Net als overlap behoort het tot de bovenliggende seriegroep en niet tot één reeks. Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) één keer in voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimte en slaat alleen de uiteindelijke presentatie op:

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

![De tussenruimte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden weergegeven door de [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/)-enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriediagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelaantallen toe. Gebruik de gegevenspunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlap en tussenruimte zijn alleen van toepassing op compatibele staaf‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep via één reeks verandert niet per se elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.AddChart](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addchart/) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als de categorieverzamelingen wissen voordat u een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en waarden van gegevenspunten refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens opbouwt, houdt u categorie‑rijen en reekswerte‑rijen op één lijn zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `null` om de categorische positie van het punt als leeg punt te behouden. Gebruik [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden blijven afgestemd op de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/displayblanksas/). Ondersteunde diagrammen kunnen lege waarden tonen als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde staaf-, kolom‑ en bubbelreeksen schakelt u [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) in en stelt u [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) in. U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepproperties zoals overlap en tussenruimte bepalen de lay‑out en zijn geen overrides op puntniveau.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal reeksen. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een nuttige limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.