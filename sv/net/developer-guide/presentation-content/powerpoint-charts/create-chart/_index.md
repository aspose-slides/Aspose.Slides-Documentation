---
title: Skapa eller uppdatera PowerPoint‑presentationens diagram i .NET
linktitle: Skapa eller uppdatera diagram
type: docs
weight: 10
url: /sv/net/create-chart/
keywords:
- lägga till diagram
- skapa diagram
- redigera diagram
- ändra diagram
- uppdatera diagram
- spridningsdiagram
- cirkeldiagram
- linjediagram
- trädkartsdiagram
- aktiediagram
- box‑och‑whisker‑diagram
- trattdiagram
- sol‑diagram
- histogramdiagram
- radardiagram
- multikategoridiagram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint‑presentationer med Aspose.Slides för .NET. Lägg till, formatera och redigera diagram med praktiska kodexempel i C#."
---
## **Översikt**

Den här artikeln ger en omfattande guide om hur man skapar och anpassar diagram med Aspose.Slides för .NET. Du kommer att lära dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och använder olika formateringsalternativ för att matcha dina specifika designkrav. Genom hela artikeln illustreras varje steg med detaljerade kodexempel, från initiering av presentationen och diagramobjektet till konfiguration av serier, axlar och förklaringar. Genom att följa den här guiden får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina .NET‑applikationer, vilket förenklar processen att skapa datadrivna presentationer.

## **Skapa ett diagram**

Diagram hjälper personer att snabbt visualisera data och få insikter som inte omedelbart är uppenbara i en tabell eller ett kalkylblad.

**Varför skapa diagram?**

Med diagram kan du:

* aggregera, komprimera eller sammanfatta stora mängder data på en enda bild i en presentation;
* avslöja mönster och trender i data;
* härleda riktning och momentum för data över tid eller i förhållande till en specifik mätenhet;
* upptäcka avvikelser, avvikelser, fel och meningslösa data;
* kommunicera eller presentera komplexa data.

I PowerPoint kan du skapa diagram via *Insert*-funktionen, som erbjuder mallar för att designa många typer av diagram. Med Aspose.Slides kan du skapa både vanliga diagram (baserade på populära diagramtyper) och anpassade diagram.

{{% alert color="info" %}} 
Använd [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/)‑enumerationen under namespace‑en [Aspose.Slides.Charts](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/). Värdena i denna enumeration motsvarar olika diagramtyper.
{{% /alert %}} 

### **Skapa staplade kolumndiagram (Clustered Column)**

Detta avsnitt förklarar hur du skapar staplade kolumndiagram med Aspose.Slides för .NET. Du lär dig att initiera en presentation, lägga till ett diagram och anpassa dess element såsom titel, data, serier, kategorier och stil. Följ stegen nedan för att se hur ett standardstaplat kolumndiagram genereras:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med någon data och specificera typen `ChartType.ClusteredColumn`.
1. Lägg till en titel på diagrammet.
1. Åtkomst till diagrammets data‑arbetsblad.
1. Rensa alla standardserier och -kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Tillämpa en fyllningsfärg på diagramserierna.
1. Lägg till etiketter på diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod demonstrerar hur du skapar ett staplat kolumndiagram:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    // Åtkomst till den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till ett staplat kolumndiagram med dess standarddata.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Ställ in diagramrubriken.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ställ in indexet för diagramdatabladet.
    int worksheetIndex = 0;

    // Hämta diagrammets dataarbetsbok.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ta bort de standardgenererade serierna och kategorierna.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Lägg till nya serier.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Lägg till nya kategorier.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Hämta den första diagramserien.
    IChartSeries series = chart.ChartData.Series[0];

    // Fyll på seriedata.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ställ in fyllningsfärgen för serien.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Hämta den andra diagramserien.
    series = chart.ChartData.Series[1];

    // Fyll på seriedata.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Ställ in fyllningsfärgen för serien.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Ställ in den första etiketten för att visa kategorinamnet.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Ställ in serien för att visa värdet för den tredje etiketten.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Spara presentationen till disk som en PPTX-fil.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Clustered Column chart](clustered_column_chart.png)

### **Skapa spridningsdiagram (Scatter)**

Spridningsdiagram (även kända som scatter plots eller x‑y‑grafer) används ofta för att kontrollera mönster eller demonstrera korrelationer mellan två variabler.

Använd ett spridningsdiagram när:

* Du har parade numeriska data.
* Du har två variabler som passar bra ihop.
* Du vill avgöra om de två variablerna är relaterade.
* Du har en oberoende variabel som har flera värden för en beroende variabel.

Denna C#‑kod visar hur du skapar ett spridningsdiagram med olika serier av markörer:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    // Åtkomst till den första bilden.
    ISlide slide = presentation.Slides[0];

    // Skapa standard spridningsdiagram.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Ställ in indexet för diagrammets dataark.
    int worksheetIndex = 0;

    // Hämta diagrammets dataarbetsbok.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ta bort standardserien.
    chart.ChartData.Series.Clear();

    // Lägg till nya serier.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Hämta den första diagramserien.
    IChartSeries series = chart.ChartData.Series[0];

    // Lägg till en ny punkt (1:3) i serien.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Lägg till en ny punkt (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Ändra serietypen.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Ändra diagramseriens markör.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Hämta den andra diagramserien.
    series = chart.ChartData.Series[1];

    // Lägg till en ny punkt (5:2) i diagramserien.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Lägg till en ny punkt (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Lägg till en ny punkt (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Lägg till en ny punkt (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Ändra diagramseriens markör.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Spara presentationen på disk som en PPTX-fil.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Scatter chart](scatter_chart.png)

### **Skapa cirkeldiagram (Pie)**

Cirkeldiagram används bäst för att visa del‑till‑helhets‑relationer i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data innehåller många delar eller etiketter kan ett stapeldiagram vara ett bättre alternativ.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.Pie`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Lägg till nya punkter för diagrammet och tillämpa anpassade färger på cirkelns sektorer.
1. Ställ in etiketter för serierna.
1. Aktivera ledarlinjer för serieetiketterna.
1. Ställ in rotationsvinkeln för cirkeldiagrammet.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett cirkeldiagram:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    // Åtkomst till den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till ett diagram med dess standarddata.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Ställ in diagramrubriken.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ställ in den första serien för att visa värden.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ställ in indexet för diagrammets dataark.
    int worksheetIndex = 0;

    // Hämta diagrammets dataarbetsbok.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ta bort de standardgenererade serierna och kategorierna.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Lägg till nya kategorier.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Lägg till nya serier.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Fyll på seriedata.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ställ in sektorfärgen.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Ställ in sektorranden.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Ställ in sektorranden.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Ställ in sektorranden.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Skapa anpassade etiketter för varje kategori i den nya serien.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Ställ in serien för att visa ledarlinjer i diagrammet.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Ställ in rotationsvinkeln för cirkeldiagrammets sektorer.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Spara presentationen på disk som en PPTX-fil.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Pie chart](pie_chart.png)

### **Skapa linjediagram (Line)**

Linjediagram (även kända som linjegrafer) används bäst i situationer där du vill demonstrera förändringar i värde över tid. Med ett linjediagram kan du jämföra stora mängder data på en gång, spåra förändringar och trender över tid, markera avvikelser i dataserier och mer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.Line`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett linjediagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Som standard är punkterna i ett linjediagram förenade med raka kontinuerliga linjer. Om du vill att punkterna ska förenas med streck kan du ange önskad strecktyp enligt följande:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Resultatet:

![The Line chart](line_chart.png)

### **Skapa trädkartsdiagram (Tree Map)**

Trädkartsdiagram används bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och snabbt uppmärksamma objekt som är stora bidragsgivare inom varje kategori.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.Treemap`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett trädkartsdiagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Gren 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Gren 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Treemap chart](treemap_chart.png)

### **Skapa aktiediagram (Stock)**

Aktiediagram används för att visa finansiella data såsom öppnings-, högsta-, lägsta- och stängningspriser, vilket hjälper till att analysera marknadstrender och volatilitet. De ger viktiga insikter om aktiens utveckling och underlättar för investerare och analytiker att fatta informerade beslut.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.OpenHighLowClose`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Specificera HiLowLines‑formatet.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett aktiediagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Stock chart](stock_chart.png)

### **Skapa låd- och whisker‑diagram (Box and Whisker)**

Låda‑och‑whisker‑diagram används för att visa fördelningen av data genom att sammanfatta nyckelstatistik som median, kvartiler och potentiella avvikare. De är särskilt användbara i explorativ dataanalys och statistiska studier för att snabbt förstå datapunktens variabilitet och identifiera avvikelser.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.BoxAndWhisker`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett låda‑och‑whisker‑diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Skapa tratt‑diagram (Funnel)**

Tratt‑diagram används för att visualisera processer som involverar sekventiella steg, där volymen av data minskar när den går från ett steg till nästa. De är särskilt hjälpsamma för att analysera konverteringsgrader, identifiera flaskhalsar och spåra effektiviteten i försäljnings‑ eller marknadsföringsprocesser.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.Funnel`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett tratt‑diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Funnel chart](funnel_chart.png)

### **Skapa sol‑diagram (Sunburst)**

Sol‑diagram används för att visualisera hierarkisk data, där nivåer visas som koncentriska ringar. De hjälper till att illustrera del‑till‑helhets‑relationer och är idealiska för att representera nästlade kategorier och underkategorier på ett tydligt, kompakt sätt.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.Sunburst`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett sol‑diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Gren 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Gren 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Sunburst chart](sunburst_chart.png)

### **Skapa histogram‑diagram (Histogram)**

Histogram‑diagram används för att representera fördelningen av numerisk data genom att gruppera värden i intervall eller hinkar. De är särskilt användbara för att identifiera mönster som frekvens, skevhet och spridning, samt för att upptäcka avvikelser i ett dataset.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med någon data och specificera typen `ChartType.Histogram`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett histogram‑diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Histogram chart](histogram_chart.png)

### **Skapa radardiagram (Radar)**

Radardiagram används för att visa multivariata data i ett tvådimensionellt format, vilket möjliggör enkel jämförelse av flera variabler samtidigt. De är särskilt användbara för att identifiera mönster, styrkor och svagheter över flera prestationsmått eller attribut.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med någon data och specificera typen `ChartType.Radar`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett radardiagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Radar chart](radar_chart.png)

### **Skapa multimultipla kategoridiagram (Multi-Category)**

Multikategoridiagram används för att visa data som involverar mer än en kategorisk gruppering, vilket gör det möjligt att jämföra värden över flera dimensioner samtidigt. De är särskilt hjälpsamma när du behöver analysera trender och relationer i komplexa, flerskikts‑datamängder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och specificera typen `ChartType.ClusteredColumn`.
1. Åtkomst till diagrammets data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett multimultipelt kategoridiagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Lägg till en serie.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Spara presentationen med diagrammet.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The multi category chart](multi_category_chart.png)

### **Skapa kartdiagram (Map)**

Kartdiagram används för att visualisera geografisk data genom att kartlägga information till specifika platser såsom länder, delstater eller städer. De är särskilt användbara för att analysera regionala trender, demografisk data och spatiala fördelningar på ett tydligt, visuellt engagerande sätt.

Denna C#‑kod visar hur du skapar ett kartdiagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
Bilden ovan visar den sparade presentationen öppnad i PowerPoint. Aspose.Slides skriver kartdiagrammet och dess data korrekt, men ritar inte själva kartdiagrammen: när en bild som innehåller ett sådant renderas till en bild eller konverteras till PDF eller SVG blir diagramområdet tomt. Andra former på samma bild påverkas inte.
{{% /alert %}} 

### **Skapa kombinationsdiagram (Combination)**

Ett kombinationsdiagram (eller combo‑diagram) kombinerar två eller flera diagramtyper i ett enda diagram. Detta diagram låter dig framhäva, jämföra eller undersöka skillnader mellan två eller fler dataset, vilket hjälper dig att identifiera relationer mellan dem.

![The combination chart](combination_chart.png)

Följande C#‑kod visar hur du skapar kombinationsdiagrammet som visas ovan i en PowerPoint‑presentation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Ställer in diagramrubriken
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Ställer in diagramförklaringen
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Tar bort de standardgenererade serierna och kategorierna
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Lägger till nya kategorier
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Lägg till den första serien
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Ställer in den horisontella axeln
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Ställer in den vertikala axeln
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Ställer in färgen på de vertikala huvudgridlinjerna
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Ställer in den sekundära horisontella axeln
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Ställer in den sekundära vertikala axeln
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Uppdatera diagram**

Aspose.Slides för .NET möjliggör att du uppdaterar PowerPoint‑diagram genom att modifiera diagramdata, formatering och styling. Denna funktion förenklar processen att hålla presentationer uppdaterade med dynamiskt innehåll och säkerställer att diagram exakt återspeglar aktuella data och visuella standarder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som representerar presentationen med ett diagram.
1. Hämta en referens till en bild med hjälp av dess index.
1. Gå igenom alla former för att hitta diagrammet.
1. Åtkomst till diagrammets data‑arbetsblad.
1. Modifiera diagramdataserierna genom att ändra serievärdena.
1. Lägg till en ny serie och fyll i dess data.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du uppdaterar ett diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Instansiera Presentation-klassen som representerar en PPTX‑fil.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Åtkomst till den första bilden.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Ställ in indexet för diagrammets dataark.
            int worksheetIndex = 0;

            // Hämta diagrammets dataarbetsbok.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Ändra diagrammets kategorinamn.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Hämta den första diagramserien.
            IChartSeries series = chart.ChartData.Series[0];

            // Uppdatera seriedatan.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Ändrar serienamnet.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Hämta den andra diagramserien.
            series = chart.ChartData.Series[1];

            // Uppdatera seriedatan.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Ändrar serienamnet.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Lägg till en ny serie.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Fyll på seriedatan.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Spara presentationen med diagrammet.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Ange dataintervall för ett diagram**

Aspose.Slides för .NET ger flexibiliteten att definiera ett specifikt dataintervall från ett arbetsblad som källa för diagrammets data. Detta innebär att du kan mappa en del av ditt arbetsblad direkt till diagrammet, vilket låter dig kontrollera vilka celler som bidrar till diagrammets serier och kategorier. På så sätt kan du enkelt uppdatera och synkronisera dina diagram med de senaste dataändringarna i ditt arbetsblad, så att dina PowerPoint‑presentationer reflekterar aktuell och korrekt information.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som representerar presentationen med ett diagram.
1. Hämta en referens till en bild med hjälp av dess index.
1. Gå igenom alla former för att hitta diagrammet.
1. Åtkomst till diagramdata och ange intervallet.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du anger dataintervall för ett diagram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Instansiera Presentation-klassen som representerar en PPTX-fil.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Åtkomst till den första bilden.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Använd standardmarkörer i diagram**

När du använder standardmarkörer i diagram får varje diagramserie automatiskt en annan standardmarkörsymbol.

Denna C#‑kod visar hur du automatiskt ställer in en diagramseriemarkör:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Fyll på seriedatan.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Vilka diagramtyper stöds av Aspose.Slides för .NET?

Aspose.Slides för .NET stöder ett brett sortiment av diagramtyper, inklusive stapeldiagram, linjediagram, cirkeldiagram, områdesdiagram, spridningsdiagram, histogram, radar och många fler. Denna flexibilitet gör att du kan välja den mest lämpliga diagramtypen för dina visualiseringsbehov.

### Hur lägger jag till ett nytt diagram på en bild?

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation), hämtar den önskade bilden med hjälp av dess index och anropar sedan metoden för att lägga till ett diagram, där du specificerar diagramtypen och startdata. Detta integrerar diagrammet direkt i din presentation.

### Hur kan jag uppdatera data som visas i ett diagram?

Du kan uppdatera ett diagrams data genom att få åtkomst till dess data‑arbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)), rensa eventuella standardserier och -kategorier och sedan lägga till dina egna data. Detta gör att du programatiskt kan uppdatera diagrammet så att det speglar de senaste data.

### Är det möjligt att anpassa diagrammets utseende?

Ja, Aspose.Slides för .NET erbjuder omfattande anpassningsalternativ. Du kan ändra färger, typsnitt, etiketter, förklaringar och andra formateringselement för att skräddarsy diagrammets utseende efter dina specifika designkrav.