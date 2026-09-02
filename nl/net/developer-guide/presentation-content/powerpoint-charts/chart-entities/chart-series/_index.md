---
title: Beheer diagramgegevensseries in presentaties in .NET
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
- reeks afstand
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunt, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met C#."
---
## **Overzicht**

Een diagram slaat zijn gepresenteerde gegevens op in een chart‑data‑werkboek. Een [IChartSeries](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/) vertegenwoordigt één set verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/) in de serie verwijst naar een of meer werkboek‑cellen. [IChartCategory](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartcategory/)‑objecten bieden de labels of groeperingswaarden die door de series worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categorie‑diagram gebruikt het standaard‑werkboek rij 0 voor serinnamen, kolom 0 voor categorienamen, en de resterende cellen voor serie‑waarden. Werkblad‑, rij‑ en kolomindexen die worden doorgegeven aan [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/getcell/) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram deze indeling hanteert. Voor een geladen presentatie, inspecteer de cellen die worden gerefereerd door de series, categorieën en datapunten voordat u werkboek‑waarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/), bepalen het standaard‑uiterlijk voor alle punten in één serie.
- Instellingen per datapunt, zoals [IChartDataPoint.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/format/), overschrijven het serie‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele series die behoren tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/). Benader de groep via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/parentseriesgroup/) wanneer u opties wilt instellen zoals overlap of tussenruimtepuntbreedte.

Wanneer er geen expliciete punt‑ of series‑vulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Overlap van de diagramserie instellen**

[IChartSeries.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriegroep. Stel [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/overlap/) in om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde seriegroepen in een combinatiediagram.

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

![Overlap van de serie](series_overlap.png)

## **Verander de vulkleur van de serie**

Gebruik [IChartSeries.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/format/) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.Format](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/format/)‑instelling de serievulling voor dat punt.

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

![De kleur van de serie](series_color.png)

## **Verander de serienaam**

Een serienaam wordt opgeslagen in het chart‑data‑werkboek en wordt normaal weergegeven in de legenda. In het standaard‑werkboek dat wordt aangemaakt voor een gegroepeerde kolom‑diagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.Name](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/name/). Deze benadering voorkomt dat u een specifieke rij en kolom in een bestaand diagram aanneemt:

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

![De serienaam](series_name.png)

## **Haal de automatische serievulkleur op**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) retourneert de kleur die wordt berekend op basis van de seriële index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardserie:

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

De exacte kleuren zijn afhankelijk van de diagramstijl en het thema.

## **Stel de omgekeerde vulkleur in voor een diagramserie**

Voor balk‑, kolom‑ en bubbel‑series kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) negatieve waarden weergeven met een andere vulling. Stel de reguliere serievulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één serie. Werkbladrij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt tevens een negatieve waarde zodat het effect zichtbaar is:

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

## **Wis een specifieke datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolom‑diagram is de getoonde waarde beschikbaar via [IChartDataPoint.YValue](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/yvalue/). Het datapunt blijft op dezelfde categoriep
positie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Scatter‑diagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, omdat die methode elk datapunt uit de collectie verwijdert.

## **Stel de gatbreedte van de serie in**

De gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze tot de bovenliggende seriegroep in plaats van tot één serie. Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) één keer in voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter bij elkaar.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de definitieve presentatie op:

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

![De gatbreedte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die worden weergegeven door de enumeratie [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/) gebruiken diagramgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het maken van datapunt die overeenkomt met het serietype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramserie‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet per se alle series in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.AddChart](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addchart/) voorbeeldseries, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de serie‑ als categoricollecties wissen voordat u een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram maken zonder standaardgegevens.

**Hoe zijn diagramobjecten verbonden met werkboekcellen?**

Serienamen, categorielabels en datapunt‑waarden refereren naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens opbouwt, houdt u de categorierijen en seriewaardrijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de betreffende waardecel in op `null` om de categorielocatie van het punt te behouden als een leeg punt. Gebruik [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointcollection/clear/) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/displayblanksas/). Ondersteunde diagrammen kunnen lege punten weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series, schakelt u [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertifnegative/) in en stelt u [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) in. U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groep‑eigenschappen zoals overlap en gatbreedte bepalen de lay‑out en vormen geen overschrijvingen op puntniveau.

**Is er een limiet aan het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een nuttige limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar staan of te ver uit elkaar staan?**

Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.