---
title: Hantera diagramdataserier i presentationer i .NET
linktitle: Dataserier
type: docs
url: /sv/net/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- serieavstånd
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboks-celler, formatering, överlappning, mellanrum och negativa värden i presentationer med C#."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdataarbetsbok. En [IChartSeries](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/) representerar en uppsättning relaterade värden, och varje [IChartDataPoint](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [IChartCategory](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartcategory/)‑objekt tillhandahåller etiketter eller grupperingvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [IChartDataCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/)‑objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de återstående cellerna för serievärden. Arbetsblad, rad‑ och kolumnindex som skickas till [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/getcell/) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsboksvärden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [IChartSeries.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/format/), ger standardutseendet för alla punkter i en serie.
- Inställningar för datapunkter, såsom [IChartDataPoint.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/format/), åsidosätter seriens utseende för en punkt.
- Grupprinställningar gäller för kompatibla serier som tillhör samma [IChartSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/). Åtkomst till gruppen sker via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/parentseriesgroup/) när du behöver ange alternativ som överlappning eller mellanrum.

När ingen explicit punkt‑ eller serie‑fyllning är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie‑ och punktformatering finns, har punktformateringen företräde för den punkten.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ställ in överlappning för diagramserien**

[IChartSeries.Overlap](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/overlap/) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade serieggruppen. Ställ in [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/overlap/) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller för diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade serieggrupper i ett kombinationsdiagram.

Följande exempel sätter överlappningen för gruppen som innehåller den första serien:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Det nya diagrammet innehåller exempelserier, kategorier och värden.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Resultatet:

![Seriens överlappning](series_overlap.png)

## **Ändra fyllningsfärgen för serien**

Använd [IChartSeries.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/format/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [IChartDataPoint.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/format/) inställning serie‑fyllningen för den punkten.

Följande exempel applicerar en solid blå fyllning på den första serien:

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

Resultatet:

![Färgen på serien](series_color.png)

## **Ändra seriens namn**

Ett serienamn lagras i diagramdataarbetsboken och visas normalt i legendet. I standardarbetsboken som skapas för ett grupperat stapeldiagram ligger cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen explicit:

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

Du kan också uppdatera cellen som redan refereras av [IChartSeries.Name](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/name/). Detta tillvägagångssätt undviker att anta en särskild rad och kolumn i ett befintligt diagram:

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

Resultatet:

![Seriens namn](series_name.png)

## **Hämta den automatiska fyllningsfärgen för serien**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) returnerar färgen som beräknas från serieindexet och diagramstilen. Detta är färgen som används när serie‑fyllningen inte har definierats explicit. Anropet läser den beräknade färgen; det tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

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

Exempelutdata för standarddiagramstilen:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exakta färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbelserier kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertifnegative/) visa negativa värden med en annan fyllning. Ställ in den vanliga serie‑fyllningen till solid, aktivera inversion och ange färgen för negativa värden via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladets rad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Resultatet:

![Den inverterade solida fyllningsfärgen](inverted_solid_fill_color.png)

Du kan aktivera inversion för en punkt via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten får även ett negativt värde så att effekten blir synlig:

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

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks‑cell till `null`. För ett stapeldiagram är det plottade värdet tillgängligt via [IChartDataPoint.YValue](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/yvalue/). Datapunkten förblir på samma kategoriposition, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

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

Dispersionsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder även en storlekscell. Rensa endast den cell som representerar det värde du avser att ta bort. Anropa inte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter från samlingen.

## **Kontrollera visning av tomma celler**

En tom arbetsboks‑cell representerar saknade data; en cell som innehåller `0` representerar ett känt numeriskt värde. Sätt [IChartDataCell.Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/) till `null` för att göra en cell tom. En numerisk nolla förblir en nolla oavsett inställning för tomma celler.

Använd [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/displayblanksas/) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks‑cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorimärkningar och kolumn 1 för värden; rad 0 innehåller serienamnet. Slutdata är `10, 20, empty, 30, 40`.

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

Varje utdatafil sparar läget som tilldelats innan sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara endast en version, tilldela önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i alla fall:

![Linjediagram med identiska data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtyp. Ett linjediagram gör alla tre lägen lätta att jämföra. Stapel‑ och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte producera den kopplade segmentet som visas ovan; en saknad kolumn och en kolumn med nollhöjd kan också se likadana ut. På samma sätt har ett dispersionsdiagram med endast markörer ingen kopplingslinje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ställ in avståndet mellan serier**

Mellanrummet är utrymmet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som en procentandel av stapel‑ eller kolumnbredden. Precis som överlappning tillhör det den överordnade serieggruppen snarare än en enskild serie. Ställ in [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) en gång för gruppen. Ett större värde skapar mer utrymme mellan kluster; ett mindre värde gör dem tätare.

Följande exempel ändrar mellanrummet och sparar endast den slutgiltiga presentationen:

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

Resultatet:

![Mellanrummet](gap_width.png)

## **FAQ**

**Vilka diagramtyper stödjer dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/)-enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelformer. Använd den datapunkt‑skapandemetod som matchar serietypen. Alternativ som överlappning och mellanrum gäller endast för kompatibla stapel‑ eller kolumngrupper.

**Vad är en grupp för diagramserier?**

En [IChartSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/) innehåller kompatibla serier som delar gruppnivåens plottningsinställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie ändrar inte nödvändigtvis alla serier i diagrammet.

**Innehåller ett nyskapat diagram standarddata?**

Ja. Som standard skapar [IShapeCollection.AddChart](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addchart/) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategori‑samlingarna innan du lägger till en helt anpassad datamängd. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks‑celler?**

Serienamn, kategorimärkningar och datapunktvärden refererar till celler i en [IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramdel. När du bygger anpassad data, håll kategorirader och serie‑värderader i linje så att varje punkt plottas under avsedd kategori.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategoriposition som en tom punkt. Använd [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera alla serier så att deras värden förblir i linje med kategorisamlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtyp och [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/displayblanksas/). Stödda diagram kan visa tomma värden som gap, som nollvärden eller genom att förena närliggande punkter. Välj den inställning som matchar betydelsen av saknade data i din presentation. Se [Kontrollera visning av tomma celler](#kontrollera-visning-av-tomma-celler) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stapel‑, kolumn‑ och bubbelserier, aktivera [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertifnegative/) och ange [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Du kan åsidosätta beteendet för en enskild punkt med [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Dessa egenskaper påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering har företräde när både en serie och en punkt är formaterade?**

Explicit datapunktformatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita serieformaten eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Grupp‑egenskaper såsom överlappning och mellanrum styr layout och är inte punkt‑nivåformateringsåsidosättningar.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides har ingen separat fast gräns för antal serier. I praktiken bestäms en rimlig gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Ställ in [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) på den respektive överordnade serieggruppen. Öka värdet för att bredda avståndet mellan kluster, eller minska det för att föra klustren närmare varandra.