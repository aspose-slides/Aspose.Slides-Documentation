---
title: Hantera diagramdataserier i presentationer på Android
linktitle: Dataserier
type: docs
url: /sv/androidjava/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier på Android för PowerPoint (PPT/PPTX) med praktiska Java-kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Denna artikel beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartseries/) i Aspose.Slides, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt utgör de grundläggande elementen som definierar enskilda uppsättningar av datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartseries/) kan utvecklare sömlöst integrera underliggande datakällor och behålla full kontroll över hur informationen visas, vilket resulterar i dynamiska, datadrivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med siffror som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ange överlappning för diagramserier**

Med metoden [IChartSeries.getOverlap](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartseries/#getOverlap--) kan du bestämma hur mycket staplar och kolumner ska överlappa i ett 2D‑diagram (intervall: -100 till 100). Denna egenskap gäller för alla serier i den överordnade serieggruppen: den är en projektion av den lämpliga gruppegenskapen. Därför är egenskapen skrivskyddad.

Använd skrivmetoden `getParentSeriesGroup().setOverlap()` för att ange ditt önskade överlappningsvärde.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Lägg till ett grupperat stapeldiagram på en bild.
1. Hämta den första diagramserien.
1. Hämta diagramseriens `ParentSeriesGroup` och ange ditt önskade överlappningsvärde för serien.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Detta Java‑kodexempel visar hur du anger överlappning för en diagramserie:

```java
Presentation pres = new Presentation();
try {
    // Lägger till diagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Ställer in seriers överlappning
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Skriver presentationsfilen till disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra seriefärg**

Aspose.Slides for Android via Java låter dig ändra en seriefärg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den serie vars färg du vill ändra.
1. Ange din föredragna fyllningstyp och fyllningsfärg.
1. Spara den modifierade presentationen.

Detta Java‑kodexempel visar hur du ändrar en seriefärg:

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

## **Ändra färg för seriekategori**

Aspose.Slides for Android via Java låter dig ändra färg för en seriekategori på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den seriekategori vars färg du vill ändra.
1. Ange din föredragna fyllningstyp och fyllningsfärg.
1. Spara den modifierade presentationen.

Detta Java‑kodexempel visar hur du ändrar färg för en seriekategori:

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

## **Ändra serienamn**

Som standard är legendarna i ett diagram innehållet i cellerna ovanför varje kolumn eller rad med data.

I vårt exempel (exempelbild) är

* kolumnerna *Series 1*, *Series 2* och *Series 3*;
* raderna *Category 1*, *Category 2*, *Category 3* och *Category 4*.

Aspose.Slides for Android via Java låter dig uppdatera eller ändra ett serienamn i dess diagramdata och i legend.

Detta Java‑kodexempel visar hur du ändrar ett serienamn i diagramdata `ChartDataWorkbook`:

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

Detta Java‑kodexempel visar hur du ändrar ett serienamn i legend via `Series`:

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

## **Ange fyllningsfärg för diagramserie**

Aspose.Slides for Android via Java låter dig ange automatisk fyllningsfärg för diagramserier inom ett plot‑område på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Hämta en bilds referens genom dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och ange fyllningsfärgen till Automatic.
1. Spara presentationen till en PPTX‑fil.

Detta Java‑kodexempel visar hur du anger automatisk fyllningsfärg för en diagramserie:

```java
Presentation pres = new Presentation();
try {
    // Skapar ett grupperat stapeldiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Ställer in seriernas fyllningsformat till automatiskt
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

## **Ställ in inverterad fyllningsfärg för en diagramserie**

Aspose.Slides låter dig ställa in inverterad fyllningsfärg för diagramserier inom ett plot‑område på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Hämta en bilds referens genom dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och ange fyllningsfärgen till invert.
1. Spara presentationen till en PPTX‑fil.

Detta Java‑kodexempel demonstrerar åtgärden:

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

## **Ställ in att en serie inverteras när värdet är negativt**

Aspose.Slides låter dig ställa in invertering via egenskaperna `IChartDataPoint.InvertIfNegative` och `ChartDataPoint.InvertIfNegative`. När en invertering anges med dessa egenskaper byter datapunkten färg när den får ett negativt värde.

Detta Java‑kodexempel demonstrerar åtgärden:

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

## **Rensa specifik punktdata**

Aspose.Slides for Android via Java låter dig rensa `DataPoints`‑data för en specifik diagramserie på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens genom dess index.
3. Hämta en diagramreferens genom dess index.
4. Iterera igenom alla diagram‑`DataPoints` och sätt `XValue` och `YValue` till null.
5. Rensa alla `DataPoints` för den specifika diagramserien.
6. Skriv den modifierade presentationen till en PPTX‑fil.

Detta Java‑kodexempel demonstrerar åtgärden:

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

## **Ange seriegapbredd**

Aspose.Slides for Android via Java låter dig ange en seriegapbredd via egenskapen **`GapWidth`** på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta vilken diagramserie som helst.
1. Sätt egenskapen `GapWidth`.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Detta Java‑kodexempel visar hur du anger seriegapbredd:

```java
// Skapar tom presentation 
Presentation pres = new Presentation();
try {
    // Hämtar presentationens första bild
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till ett diagram med standarddata
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Ställer in index för diagramdatabladet
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagramdatabladet
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
    
    // Fyller i seriedatan
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ställer in GapWidth‑värdet
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Sparar presentationen till disk
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Finns det någon gräns för hur många serier ett enda diagram kan innehålla?**

Aspose.Slides har ingen fast gräns för antalet serier du kan lägga till. Den praktiska begränsningen bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**Vad händer om staplarna i en grupp är för nära varandra eller för långt ifrån varandra?**

Justera `GapWidth`‑inställningen för den serien (eller dess överordnade serieg grupp). Ett högre värde ökar avståndet mellan staplarna, medan ett lägre värde minskar avståndet.