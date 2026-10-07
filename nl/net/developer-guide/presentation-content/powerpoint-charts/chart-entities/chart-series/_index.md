---
title: Beheer grafiekgegevensreeksen in presentaties in .NET
linktitle: Gegevensreeksen
type: docs
url: /nl/net/chart-series/
keywords:
- grafiekreeksen
- overlap van reeksen
- kleur van reeks
- kleur van categorie
- reeksnaam
- datapunt
- reeksafstand
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunt­en, werkboekcellen, opmaak, overlap, gapsbreedte en negatieve waarden in presentaties kunt beheren met C#."
---
## **Overzicht**

Een grafiek slaat zijn weergegeven gegevens op in een grafiekdataboek. Een [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) vertegenwoordigt één set verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) in de serie verwijst naar één of meer werkboekcellen. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)‑objecten geven de labels of groeperingswaarden weer die door de series worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor seriewaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet vanuit dat elke bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie inspecteert u de cellen waarnaar de series, categorieën en data‑punten verwijzen voordat u werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende bereiken:

- Instellingen op serieniveau, zoals [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), bieden de standaardweergave voor alle punten in één serie.  
- Instellingen op datapuntniveau, zoals [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), overschrijven de serie‑weergave voor één punt.  
- Groepsinstellingen gelden voor compatibele series die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) behoren. Toegang tot de groep krijg je via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) wanneer je opties zoals overlappen of gapsbreedte moet instellen.

Wanneer er geen expliciete vulling voor een punt of serie is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![grafiek‑reeks‑powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlappende grafiekreeksen**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende serie‑groep. Stel [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) in om elke compatibele serie in die groep bij te werken. Deze optie geldt voor grafiektypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde seriegroepen in een combinatiegrafiek.

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

// De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De reeksoverlap](series_overlap.png)

## **Wijzig de opvulkleur van de reeks**

Gebruik [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) om de standaardvulling voor een gehele serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) instelling de serievulling voor dat punt.

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

![De kleur van de reeks](series_color.png)

## **Wijzig de naam van de reeks**

Een serienaam wordt opgeslagen in het grafiekdataboek en normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Deze aanpak voorkomt aannames over een specifieke rij en kolom in een bestaande grafiek:

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

![De naam van de reeks](series_name.png)

### **Maak een reeks met een naam uit meerdere cellen**

Een samengestelde reeksennaam is nuttig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen zijn opgeslagen. Bijvoorbeeld, u kunt `Product A` in B1 en `2026` in C1 samenvoegen tot één reeksennaam, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) om het naamgebied op te halen, en geef die collectie vervolgens door aan [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naamgebied op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapunt‑waarden. Cellen B1:C1 leveren alleen de reeksennaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

// Deze twee cellen leveren de serienaam.
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

De resulterende reeksennaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één item voor beide kolommen. De onderstaande afbeelding is gerenderd vanuit de opgeslagen presentatie:

![Kolomgrafiek met Noord- en Zuidwaarden en de samengestelde reeksennaam Product A 2026 in de legenda](composite_series_name.png)

## **Verkrijg de automatische opvulkleur van de reeks**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) retourneert de kleur die wordt berekend op basis van de seriëindex en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij kent geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

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

## **Stel Inverteer de opvulkleur in voor een grafiekreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de reguliere serievulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één serie. Werkbladrij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De geïnverteerde solide opvulkleur](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomgrafiek is de weergegeven waarde beschikbaar via [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Het datapunt blijft op dezelfde categorielocatie staan, maar de grafiek behandelt zijn waarde als leeg volgens de instelling voor lege waarden van de grafiek.

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

Spreiding‑grafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelgrafieken gebruiken daarnaast een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Regel de weergave van lege cellen**

Verborgen cellen die waarden bevatten vormen een afzonderlijk geval ten opzichte van lege cellen. Zie voor het opnemen of uitsluiten van gegevens uit verborgen werkbladrijen en -kolommen [Include Data from Hidden Rows and Columns](/slides/nl/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel vertegenwoordigt ontbrekende gegevens; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Stel [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) in op `null` om een cel leeg te maken. Een numeriek nul blijft een nul ongeacht de instelling voor lege cellen.

Gebruik [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Ze verandert hoe lege waarden worden uitgezet, zonder de lege werkboekcel op nul of een geïnterpoleerde waarde te vullen.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, leeg, 30, 40`.

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

Elk uitvoerbestand bevat de modus die vóór het opslaan is toegewezen: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie eenmalig op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in het werkboek in elk geval leeg:

![Lijngrafieken met identieke gegevens: Gap onderbreekt de lijn op Dag 3, Zero brengt de lijn naar nul, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om een ontbrekende categorie te verbinden, zodat `Span` de getoonde verbindingssegment niet kan produceren; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook vergelijkbaar uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de uitvoer voor het type dat u gebruikt.

## **Instellen van de gapsbreedte van de reeks**

Gapsbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de breedte van de balk of kolom. Net als overlap behoort deze instelling tot de bovenliggende serie‑groep en niet tot één serie. Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) één keer in voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gapsbreedte en slaat alleen de uiteindelijke presentatie op:

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

![De gapsbreedte](gap_width.png)

## **Veelgestelde vragen**

**Welke grafiektype ondersteunen gegevensreeksen?**

Alle grafiektype die door de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑enumeratie worden weergegeven, gebruiken grafiekgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het serietype. Opties zoals overlappen en gapsbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één serie wordt bereikt niet per­ se alle series in de grafiek wijzigt.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) voorbeeldseries, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de serie‑ als de categorieverzamelingen wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Serienamen, categorielabels en datapuntwaarden refereren aan cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens bouwt, houdt u de categorie‑rijen en serie‑waarde‑rijen op één lijn zodat elk punt onder de juiste categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de betreffende waarde‑cel in op `null` om de positie van het punt in de categorie behouden als een leeg punt. Gebruik [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) alleen wanneer u alle punten van die serie wilt verwijderen. Als u ook categorieën verwijdert, update dan elke serie zodat hun waarden blijven overeenkomen met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en van [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in uw presentatie. Zie [Regel de weergave van lege cellen](#regel-de-weergave-van-lege-cellen) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen schakelt u [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) in en stelt u [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) in. U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groeps‑eigenschappen zoals overlappen en gapsbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal series dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en de leesbaarheid van de grafiek een praktische limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Stel [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in op de betreffende bovenliggende serie‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag hem om de clusters dichter bij elkaar te brengen.