---
title: Hantera diagramdataserier i presentationer i .NET
linktitle: Dataserier
type: docs
url: /sv/net/chart-series/
keywords:
- diagramserie
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, gapbredd och negativa värden i presentationer med C#."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdataarbetsbok. En [IChartSeries](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/) representerar en uppsättning relaterade värden, och varje [IChartDataPoint](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [IChartCategory](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartcategory/) objekt tillhandahåller etiketter eller gruppvärden som delas av serierna. Serie­namnet, kategorierna och punktvärdena är därför kopplade till [IChartDataCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/) objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för seriernas namn, kolumn 0 för kategorinamnen och de återstående cellerna för serievärdena. Arbetsblad-, rad- och kolumnindex som skickas till [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/getcell/) är nollbaserade. Denna layout är praktisk när du skapar ett diagram med standarddata, men anta inte att alla befintliga diagram använder den. För en inläst presentation bör du inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsbokens värden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [IChartSeries.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/format/), tillhandahåller standardutseendet för alla punkter i en serie.
- Inställningar på datapunktnivå, såsom [IChartDataPoint.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/format/), åsidosätter seriens utseende för en punkt.
- Gruppinställningar gäller för kompatibla serier som tillhör samma [IChartSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/). Få åtkomst till gruppen via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/parentseriesgroup/) när du behöver ställa in alternativ som överlappning eller gapbredd.

När ingen explicit punkt- eller seriefyllning är angiven bestäms det automatiska utseendet av diagramstilen och -temat. När både serie- och punktformatering finns, har punktformateringen företräde för den punkten.

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

![Serieöverlappning](series_overlap.png)

## **Ändra seriefyllningsfärgen**

Använd [IChartSeries.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/format/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [IChartDataPoint.Format](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/format/) inställning seriefyllningen för den punkten.

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

![Seriefärgen](series_color.png)

## **Ändra seriens namn**

Seriens namn lagras i diagramdataarbetsboken och visas normalt i förklaringen. I standardarbetsboken som skapas för ett grupperat kolumndiagram är cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen explicit:

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

Du kan också uppdatera cellen som redan refereras av [IChartSeries.Name](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/name/). Detta tillvägagångssätt undviker att anta en viss rad och kolumn i ett befintligt diagram:

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

## **Hämta den automatiska seriefyllningsfärgen**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) returnerar färgen som beräknas från serieindexet och diagramstilen. Detta är färgen som används när seriefyllning inte har definierats explicit. Att anropa metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

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

Exempeloutput för standarddiagramstilen:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exakta färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel-, kolumn- och bubbelseerier kan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertifnegative/) visa negativa värden med en annan fyllning. Ställ in den normala seriefyllningen till solid, aktivera invertering och tilldela färgen för negativa värden via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladets rad 0 innehåller seriens namn, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Du kan aktivera invertering för en punkt via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). I följande exempel är invertering inaktiverad för serien och endast aktiverad för den valda punkten. Punkten får också ett negativt värde så att effekten blir synlig:

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

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks cell till `null`. För ett kolumndiagram är det plottade värdet tillgängligt via [IChartDataPoint.YValue](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/yvalue/). Datapunkten förblir på samma kategoriposition, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

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

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder även en storlekscell. Rensa endast den cell som representerar det värde du vill ta bort. Anropa inte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom den metoden tar bort varje datapunkt från samlingen.

## **Styr visningen av tomma celler**

Dolda celler som innehåller värden är ett separat fall från tomma celler. För att inkludera eller exkludera data från dolda arbetsbladsrader och -kolumner, se [Include Data from Hidden Rows and Columns](/slides/sv/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

En tom arbetsboks cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Sätt [IChartDataCell.Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/) till `null` för att göra en cell tom. En numerisk nolla förblir en nolla oavsett inställning för tom cell.

Använd [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/displayblanksas/) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram i varje läge. Ingen indatafil krävs. [IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller seriens namn. De slutgiltiga data är `10, 20, empty, 30, 40`.

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

Varje output‑fil sparar läget som tilldelats före sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara endast en version, tilldela önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i varje fall:

![Linjediagram med identiska data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel‑ och kolumndiagram har ingen linje att ansluta över en saknad kategori, så `Span` kan inte skapa den anslutande sektionen som visas ovan; en saknad kolumn och en kolumn med nollhöjd kan också se likadana ut. På liknande sätt har ett spridningsdiagram med endast markörer ingen anslutningslinje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera output för den typ du använder.

## **Ställ in seriegapbredden**

Gapbredd är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som en procentandel av stapel‑ eller kolumnbredden. Liksom överlappning tillhör den den överordnade serieggruppen snarare än en enskild serie. Ställ in [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) en gång för gruppen. Ett större värde skapar mer utrymme mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar gapbredden och sparar endast den slutgiltiga presentationen:

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

![Gapbredden](gap_width.png)

## **FAQ**

**Vilka diagramtyper stödjer dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/)‑enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelt storlekar. Använd den datapunkt‑skapandemetod som matchar serietypen. Alternativ som överlappning och gapbredd gäller endast för kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegrupp?**

Ett [IChartSeriesGroup](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/) innehåller kompatibla serier som delar gruppnivå‑plottinginställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie förändrar inte nödvändigtvis alla serier i diagrammet.

**Innehåller ett ny‑skapat diagram standarddata?**

Ja. Som standard skapar [IShapeCollection.AddChart](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addchart/) provserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till ett helt anpassat datamängd. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboksceller?**

Serienamn, kategorietiketter och datapunktvärden refererar till celler i en [IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagram‑element. När du bygger anpassade data, håll kategorirader och serie‑värderader alignerade så att varje punkt plottas under den avsedda kategorin.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategoriposition som en tom punkt. Använd [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategorisamlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtypen och [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/displayblanksas/). Stödda diagram kan visa tomma värden som gap, som nollvärden eller genom att ansluta närliggande punkter. Välj den inställning som motsvarar betydelsen av saknad data i din presentation. Se [Control the Display of Empty Cells](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbelseerier, aktivera [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertifnegative/) och sätt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Du kan åsidosätta beteendet för en enskild punkt med [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Dessa egenskaper påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering vinner när både en serie och en punkt är formaterade?**

Explicit datapunkt‑formatering har företräde för den punkten. Övriga punkter fortsätter att använda den explicita serieformatet eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Grupp‑egenskaper som överlappning och gapbredd styr layouten och är inte formateringsöverskrivningar på punktnivå.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides har ingen separat fast gräns för antalet serier. I praktiken bestäms en rimlig gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån?**

Ställ in [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) på den lämpliga överordnade serieggruppen. Höj värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.