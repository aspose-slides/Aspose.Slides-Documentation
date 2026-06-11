---
title: Hantera diagramdataserier i presentationer med Java
linktitle: Dataserier
type: docs
url: /sv/java/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriogap
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier i Java för PowerPoint (PPT/PPTX) med praktiska kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Denna artikel beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chartseries/) i Aspose.Slides, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt tillhandahåller de grundläggande elementen som definierar enskilda uppsättningar datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chartseries/), kan utvecklare sömlöst integrera underliggande datakällor och behålla full kontroll över hur information visas, vilket resulterar i dynamiska, data‑drivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med tal som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

Med egenskapen [IChartSeriesOverlap](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/properties/overlap) kan du ange hur mycket staplar och kolumner ska överlappa i ett 2D‑diagram (intervall: -100 till 100). Denna egenskap gäller för alla serier i den överordnade seriegruppen: det är en projektion av den lämpliga gruppegenskapen. Därför är denna egenskap skrivskyddad. 

Använd den läs‑/skrivbara egenskapen `ParentSeriesGroup.Overlap` för att ange ditt önskade värde för `Overlap`. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Lägg till ett klustrat kolumndiagram på en bild.
1. Hämta den första diagramserien.
1. Hämta diagramseriens `ParentSeriesGroup` och ange ditt önskade överlappningsvärde för serien. 
1. Skriv den ändrade presentationen till en PPTX‑fil.

Denna Java‑kod visar hur du anger överlappning för en diagramserie:

```java
Presentation pres = new Presentation();
try {
    // Lägger till diagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Anger serieöverlappning
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Skriver presentationsfilen till disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Color**

Aspose.Slides för Java låter dig ändra en seriefärg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den serie vars färg du vill ändra. 
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den ändrade presentationen.

Denna Java‑kod visar hur du ändrar en seriefärg:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Category Color**

Aspose.Slides för Java låter dig ändra en seriekategoris färg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den seriekategori vars färg du vill ändra.
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den ändrade presentationen.

Denna kod i Java visar hur du ändrar en seriekategoris färg:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Name** 

Som standard är legendnamnen för ett diagram innehållet i cellerna ovanför varje kolumn eller rad med data. 

I vårt exempel (exempelbild), 

* kolumnerna är *Series 1, Series 2* och *Series 3*;
* raderna är *Category 1, Category 2, Category 3* och *Category 4*. 

Aspose.Slides för Java låter dig uppdatera eller ändra ett serienamn i dess diagramdata och legend. 

Denna Java‑kod visar hur du ändrar ett serienamn i dess diagramdata `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Denna Java‑kod visar hur du ändrar ett serienamn i dess legend via `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Chart Series Fill Color**

Aspose.Slides för Java låter dig ange automatisk fyllningsfärg för diagramserier i ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och sätt fyllningsfärgen till Automatic.
1. Spara presentationen till en PPTX‑fil.

Denna Java‑kod visar hur du anger automatisk fyllningsfärg för en diagramserie:

```java
Presentation pres = new Presentation();
try {
    // Skapar ett klustrat kolumndiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Anger seriefyllningsformat till automatiskt
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Skriver presentationsfilen till disk
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Invert Fill Color for a Chart Series**

Aspose.Slides låter dig ange inverterad fyllningsfärg för diagramserier i ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och sätt fyllningsfärgen till invert.
1. Spara presentationen till en PPTX‑fil.

Denna Java‑kod demonstrerar operationen:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Lägger till nya serier och kategorier
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Hämtar den första diagramserien och fyller i dess seriedata.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set a Series to Invert When Value Is Negative**

Aspose.Slides låter dig ange inverteringar via egenskaperna `IChartDataPoint.InvertIfNegative` och `ChartDataPoint.InvertIfNegative`. När en invertering ställs in med hjälp av egenskaperna, inverterar datapunkten sina färger när den får ett negativt värde. 

Denna Java‑kod demonstrerar operationen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clear Specific Point Data**

Aspose.Slides för Java låter dig rensa `DataPoints`‑data för en specifik diagramserie på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta referensen till en bild via dess index.
3. Hämta referensen till ett diagram via dess index.
4. Iterera genom alla diagrammets `DataPoints` och sätt `XValue` och `YValue` till null.
5. Rensa alla `DataPoints` för den specifika diagramserien.
6. Skriv den ändrade presentationen till en PPTX‑fil.

Denna Java‑kod demonstrerar operationen:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Series Gap Width**

Aspose.Slides för Java låter dig ange en seriers glappbredd via egenskapen **`GapWidth`** på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta någon diagramserie.
1. Ange egenskapen `GapWidth`.
1. Skriv den ändrade presentationen till en PPTX‑fil.

Denna kod i Java visar hur du anger en seriers glappbredd:

```java
// Skapar tom presentation 
Presentation pres = new Presentation();
try {
    // Hämtar presentationens första bild
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till ett diagram med standarddata
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Anger index för diagrammets datasheet
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Lägger till serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Lägger till kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Hämtar den andra diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Fyller seriedatan
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Anger GapWidth‑värde
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Sparar presentationen till disk
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is there a limit to how many series a single chart can contain?**

Aspose.Slides har ingen fast gräns för antalet serier du kan lägga till. Den praktiska taket bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**What if the columns within a cluster are too close together or too far apart?**

Justera `GapWidth`‑inställningen för den serien (eller dess överordnade seriegrupp). Att öka värdet breddar avståndet mellan kolumnerna, medan minskning av värdet för minskar avståndet.