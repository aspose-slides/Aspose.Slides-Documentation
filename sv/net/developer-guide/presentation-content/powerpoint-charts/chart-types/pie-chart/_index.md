---
title: Anpassa cirkeldiagram i presentationer i .NET
linktitle: Cirkeldiagram
type: docs
url: /sv/net/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plot-alternativ
- skivfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa cirkeldiagram i .NET med Aspose.Slides. Konfigurera sekundära plotar, visa dataetiketter och tillämpa automatiska skivfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med cirkeldiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram, samt hur man aktiverar automatisk färgläggning av skivor för ett standardcirkeldiagram.

Exemplen fokuserar på anpassningsuppgifter för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden, samt spara den uppdaterade presentationen.

## **Sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram**

Aspose.Slides för .NET stöder alternativ för sekundär plot för Pie of Pie‑ och Bar of Pie‑diagram. Dessa alternativ styr storleken på den sekundära ploten och hur datapunkter delas mellan de två plotarna.

Följande exempel skapar ett Pie of Pie‑diagram i en ny presentation och visar datapunktvärden som etiketter. Egenskapen [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) ställer in den sekundära plotens storlek till 149 % av huvudploten. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) väljer procentbaserad uppdelning och [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) sätter tröskeln till 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Visa värden och konfigurera den sekundära ploten.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Välj kategorier för den sekundära ploten**

Använd anpassad uppdelning när du vill gruppera specifika kategorier i den sekundära ploten oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35 % respektive 10 % av den totala försäljningen.

Ställ in [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) till [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) och välj punkterna via [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Samlingens [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/)‑metod accepterar antingen ett nollbaserat index i serien eller ett datapunkt‑objekt. I detta exempel väljer index 1 Online och punkten på index 3 väljer Events. Partners läggs också till tillfälligt, och tas sedan bort med [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Ersätt standarddata med försäljning per kanal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Välj Online med dess nollbaserade index och Events med dess datapunkt‑objekt.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Exkludera Partners från urvalet utan att radera dess källdata.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) och Events (10) visas som separata skivor i den sekundära ploten. I huvudploten representeras de av en kombinerad skiva med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från det anpassade urvalet behåller den i huvudploten; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Cirkeldiagram av typen Pie of Pie med Online och Events i den sekundära ploten och deras kombinerade värde 45 i huvudploten](pie_of_pie_custom.png)

## **Ställ in automatisk färgläggning av cirkeldiagram‑skivor**

Aspose.Slides för .NET kan automatiskt tilldela olika färger till cirkeldiagram‑skivor. Följande exempel skapar ett cirkeldiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Egenskapen [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) visar värdena 20, 50 och 30 som etiketter, medan [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) möjliggör en distinkt färg för varje skiva.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Lägg till en centrerad diagramtitel.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Ersätt standarddata med det första kalkylbladet.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Visa värden och tilldela olika färger till skivorna.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Stöds variationerna Pie of Pie och Bar of Pie?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) en sekundär plot för cirkeldiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera endast diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (t.ex. PNG) utan att exportera hela presentationen.