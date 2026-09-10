---
title: Skapa eller uppdatera PowerPoint-presentationdiagram i .NET
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
- låddiagram
- trattdiagram
- solstrålediagram
- histogramdiagram
- radardiagram
- flerkategoridiagram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint-presentationer med Aspose.Slides för .NET. Lägg till, formatera och redigera diagram med praktiska kodexempel i C#."
---
## **Översikt**

Den här artikeln ger en omfattande guide om hur man skapar och anpassar diagram med Aspose.Slides för .NET. Du kommer att lära dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och tillämpar olika formateringsalternativ för att matcha dina specifika designkrav. Genom hela artikeln illustrerar detaljerade kodexempel varje steg, från att initiera presentationen och diagramobjektet till att konfigurera serier, axlar och förklaringar. Genom att följa denna guide får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina .NET‑applikationer, vilket effektiviserar processen att skapa datadrivna presentationer.

## **Skapa ett diagram**

Diagram hjälper människor att snabbt visualisera data och få insikter som kanske inte omedelbart framgår av en tabell eller ett kalkylblad.

**Varför skapa diagram?**

* sammanfatta, komprimera eller summera stora mängder data på en enda bild i en presentation;
* visa mönster och trender i data;
* sluta sig på riktning och momentum för data över tid eller i förhållande till en specifik mätenhet;
* upptäcka avvikelser, avvikande värden, fel och meningslös data;
* kommunicera eller presentera komplex data.

I PowerPoint kan du skapa diagram via *Insert*-funktionen, som erbjuder mallar för att designa många diagramtyper. Med Aspose.Slides kan du skapa både vanliga diagram (baserade på populära diagramtyper) och anpassade diagram.

{{% alert color="info" %}} 
Använd uppräkningen [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/) under namnrymden [Aspose.Slides.Charts](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/). Värdena i denna uppräkning motsvarar olika diagramtyper.
{{% /alert %}} 

### **Skapa grupperade kolumndiagram**

Detta avsnitt förklarar hur man skapar grupperade kolumndiagram med Aspose.Slides för .NET. Du lär dig att initiera en presentation, lägga till ett diagram och anpassa dess element såsom titel, data, serier, kategorier och stil. Följ stegen nedan för att se hur ett standardgrupperat kolumndiagram genereras:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med vissa data och specificera typen `ChartType.ClusteredColumn`.
1. Lägg till en titel till diagrammet.
1. Få åtkomst till diagrammets dataarbetsblad.
1. Rensa alla standardserier och -kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Tillämpa en fyllnadsfärg på diagramserierna.
1. Lägg till etiketter på diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod demonstrerar hur man skapar ett grupperat kolumndiagram:

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

    // Lägg till ett grupperat kolumndiagram med dess standarddata.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Ange diagrammets titel.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ange indexet för diagrammets datablad.
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

    // Fyll seriedatan.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ange fyllnadsfärgen för serien.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Hämta den andra diagramserien.
    series = chart.ChartData.Series[1];

    // Fyll seriedatan.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Ange fyllnadsfärgen för serien.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Ange den första etiketten att visa kategorinamnet.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Ange serien att visa värdet för den tredje etiketten.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Spara presentationen till disk som en PPTX-fil.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Grupperat kolumndiagram](clustered_column_chart.png)

### **Skapa spridningsdiagram**

Spridningsdiagram (även kallade scatter plots eller x‑y‑grafer) används ofta för att kontrollera mönster eller demonstrera korrelationer mellan två variabler.

Använd ett spridningsdiagram när:

* Du har parade numeriska data.
* Du har två variabler som passar bra ihop.
* Du vill avgöra om de två variablerna är relaterade.
* Du har en oberoende variabel som har flera värden för en beroende variabel.

Denna C#‑kod visar hur du skapar ett spridningsdiagram med olika markörserier:

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

    // Ange indexet för diagrammets datablad.
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

    // Lägg till en ny punkt (1:3) till serien.
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

    // Lägg till en ny punkt (5:2) till diagramserien.
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

    // Spara presentationen till disk som en PPTX-fil.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Spridningsdiagram](scatter_chart.png)

### **Skapa cirkeldiagram**

Cirkeldiagram används bäst för att visa förhållandet mellan del och helhet i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data däremot innehåller många delar eller etiketter kan ett stapeldiagram vara ett bättre alternativ.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.Pie`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Lägg till nya punkter för diagrammet och tillämpa anpassade färger på cirkeldiagrammets sektorer.
1. Ställ in etiketter för serierna.
1. Aktivera ledarlinjer för serieetiketterna.
1. Ställ in rotationsvinkeln för cirkeldiagrammet.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

    // Ange diagrammets titel.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ange att den första serien ska visa värden.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ange indexet för diagrammets dataark.
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

    // Fyll seriedatan.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ange sektorfärgen.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Ange sektorranden.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Ange sektorranden.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Ange sektorranden.
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

    // Ange att serien ska visa ledarlinjer för diagrammet.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Ange rotationsvinkeln för cirkeldiagrammets sektorer.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Spara presentationen till disk som en PPTX-fil.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Cirkeldiagram](pie_chart.png)

### **Skapa linjediagram**

Linjediagram (även kallade line graphs) används bäst i situationer där du vill demonstrera förändringar i värde över tid. Med ett linjediagram kan du jämföra stora mängder data på en gång, spåra förändringar och trender över tid, markera avvikelser i dataserier och mer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.Line`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

Som standard förenas punkter i ett linjediagram med raka kontinuerliga linjer. Om du vill att punkterna ska förenas med streck kan du ange önskad strecktyp enligt följande:

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

![Linjediagram](line_chart.png)

### **Skapa trädkartsdiagram**

Trädkartsdiagram används bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och snabbt rikta uppmärksamheten mot de poster som är stora bidragsgivare inom varje kategori.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.Treemap`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑file.

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

![Trädkartsdiagram](treemap_chart.png)

### **Skapa aktiediagram**

Aktiediagram används för att visa finansiella data såsom öppnings-, högsta-, lägsta- och stängningspriser, vilket hjälper till att analysera marknadstrender och volatilitet. De ger viktiga insikter i aktieprestanda och stödjer investerare och analytiker i att fatta välgrundade beslut.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.OpenHighLowClose`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Specificera formatet för HiLowLines.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

![Aktiediagram](stock_chart.png)

### **Skapa låddiagram**

Låddiagram används för att visa fördelningen av data genom att sammanfatta viktiga statistiska mått, såsom median, kvartiler och potentiella avvikare. De är särskilt användbara i explorativ dataanalys och statistiska studier för snabbt att förstå datavariabilitet och identifiera eventuella avvikelser.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.BoxAndWhisker`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett låddiagram:

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

### **Skapa trattdiagram**

Trattdiagram används för att visualisera processer som involverar sekventiella steg, där datavolymen minskar när den går från ett steg till nästa. De är särskilt hjälpsamma för att analysera konverteringsgrad, identifiera flaskhalsar och spåra effektiviteten i försäljnings- eller marknadsföringsprocesser.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.Funnel`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett trattdiagram:

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

![Trattdiagram](funnel_chart.png)

### **Skapa solstrålediagram**

Solstrålediagram används för att visualisera hierarkisk data, där nivåerna visas som koncentriska ringar. De hjälper till att illustrera del‑till‑hel‑förhållanden och är idealiska för att representera inbäddade kategorier och underkategorier på ett tydligt, kompakt sätt.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.Sunburst`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett solstrålediagram:

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

![Solstrålediagram](sunburst_chart.png)

### **Skapa histogramdiagram**

Histogramdiagram används för att representera fördelningen av numerisk data genom att gruppera värden i intervall eller "bins". De är särskilt användbara för att identifiera datamönster såsom frekvens, skevhet och spridning samt för att upptäcka avvikelser i en dataset.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med vissa data och ange typen `ChartType.Histogram`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett histogramdiagram:

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

![Histogramdiagram](histogram_chart.png)

### **Skapa radardiagram**

Radardiagram används för att visa multivariata data i ett tvådimensionellt format, vilket möjliggör enkel jämförelse av flera variabler samtidigt. De är särskilt användbara för att identifiera mönster, styrkor och svagheter över flera prestationsmått eller attribut.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med vissa data och ange typen `ChartType.Radar`.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

![Radardiagram](radar_chart.png)

### **Skapa diagram med flera kategorier**

Diagram med flera kategorier används för att visa data som innefattar mer än en kategorisk gruppering, vilket låter dig jämföra värden över flera dimensioner samtidigt. De är särskilt hjälpsamma när du behöver analysera trender och samband i komplexa, flerskiktsdatamängder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till en bild med hjälp av dess index.
1. Lägg till ett diagram med standarddata och ange typen `ChartType.ClusteredColumn`.
1. Få åtkomst till diagrammets dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)).
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till nya diagramdata för diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar ett diagram med flera kategorier:

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

![Flerkategoridiagram](multi_category_chart.png)

### **Skapa kartdiagram**

Kartdiagram används för att visualisera geografisk data genom att mappar information till specifika platser såsom länder, delstater eller städer. De är särskilt användbara för att analysera regionala trender, demografisk data och rumsliga fördelningar på ett tydligt och visuellt engagerande sätt.

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

![Kartdiagram](map_chart.png)

{{% alert color="info" %}} 
Bilden ovan visar den sparade presentationen som öppnas i PowerPoint. Aspose.Slides skriver kartdiagrammet och dess data korrekt, men ritar inte kartdiagrammen själva: när en bild som innehåller ett sådant renderas till en bild eller konverteras till PDF eller SVG blir diagramområdet tomt. Andra former på samma bild påverkas inte.
{{% /alert %}} 

### **Skapa kombinationsdiagram**

Ett kombinationsdiagram (eller kombodiagram) kombinerar två eller fler diagramtyper i ett enda diagram. Detta diagram låter dig lyfta fram, jämföra eller undersöka skillnader mellan två eller fler dataset, vilket hjälper dig att identifiera relationer mellan dem.

![Kombinationsdiagram](combination_chart.png)

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

    // Sätter diagramtitel
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Sätter diagramförklaring
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
    // Sätter den horisontella axeln
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Sätter den vertikala axeln
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Sätter färg för vertikala huvudrutnätlinjer
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Sätter den sekundära horisontella axeln
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Sätter den sekundära vertikala axeln
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

Aspose.Slides för .NET möjliggör att du kan uppdatera PowerPoint‑diagram genom att ändra diagramdata, formatering och stil. Denna funktion förenklar processen att hålla presentationer aktuella med dynamiskt innehåll och säkerställer att diagram exakt speglar aktuella data och visuella standarder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som representerar presentationen som innehåller diagrammet.
1. Hämta en referens till en bild med hjälp av dess index.
1. Gå igenom alla former för att hitta diagrammet.
1. Få åtkomst till diagrammets dataarbetsblad.
1. Ändra diagramserierna genom att byta serievärden.
1. Lägg till en ny serie och fyll i dess data.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du uppdaterar ett diagram:

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
            // Ange indexet för diagrammets datablad.
            int worksheetIndex = 0;

            // Hämta diagrammets dataarbetsbok.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Ändra diagrammets kategorinamn.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Hämta den första diagramserien.
            IChartSeries series = chart.ChartData.Series[0];

            // Uppdatera seriedatan.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Ändrar seriens namn.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Hämta den andra diagramserien.
            series = chart.ChartData.Series[1];

            // Uppdatera seriedatan.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Ändrar seriens namn.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Lägg till en ny serie.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Fyll seriedatan.
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

## **Ange dataområde för ett diagram**

Aspose.Slides för .NET ger flexibiliteten att definiera ett specifikt dataområde från ett arbetsblad som källa för ditt diagram. Detta innebär att du kan mappa en del av ditt arbetsblad direkt till diagrammet, vilket låter dig styra vilka celler som bidrar till diagrammets serier och kategorier. Som resultat kan du enkelt uppdatera och synkronisera dina diagram med de senaste dataändringarna i ditt arbetsblad, så att dina PowerPoint‑presentationer alltid reflekterar aktuell och korrekt information.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som representerar presentationen som innehåller diagrammet.
1. Hämta en referens till en bild med hjälp av dess index.
1. Gå igenom alla former för att hitta diagrammet.
1. Få åtkomst till diagramdata och ange området.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du anger dataområdet för ett diagram:

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

    // Fyll seriedatan.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Vilka diagramtyper stöds av Aspose.Slides för .NET?**

Aspose.Slides för .NET stöder ett brett sortiment av diagramtyper, inklusive stapel, linje, cirkel, yta, spridning, histogram, radar och många fler. Denna flexibilitet låter dig välja den mest lämpliga diagramtypen för dina datavisualiseringsbehov.

**Hur lägger jag till ett nytt diagram på en bild?**

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation), hämtar den önskade bilden med dess index och anropar sedan metoden för att lägga till ett diagram, specificera diagramtypen och initiala data. Detta integrerar diagrammet direkt i din presentation.

**Hur kan jag uppdatera de data som visas i ett diagram?**

Du kan uppdatera ett diagrams data genom att få åtkomst till dess dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/)), rensa eventuella standardserier och -kategorier och sedan lägga till dina egna data. Detta gör att du programatiskt kan uppdatera diagrammet så att det återspeglar de senaste uppgifterna.

**Är det möjligt att anpassa diagrammets utseende?**

Ja, Aspose.Slides för .NET erbjuder omfattande anpassningsalternativ. Du kan modifiera färger, teckensnitt, etiketter, förklaringar och andra formateringselement för att skräddarsy diagrammets utseende efter dina specifika designkrav.