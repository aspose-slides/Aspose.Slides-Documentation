---
title: Hantera diagramdataserier i presentationer med JavaScript
linktitle: Dataserier
type: docs
url: /sv/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier i JavaScript för PowerPoint (PPT/PPTX) med praktiska kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Den här artikeln beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/) i Aspose.Slides, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt tillhandahåller de grundläggande elementen som definierar enskilda uppsättningar av datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/), kan utvecklare sömlöst integrera underliggande datakällor och behålla full kontroll över hur information visas, vilket resulterar i dynamiska, data‑drivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med siffror som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ställ in överlappning för diagramserie**

Med metoden [ChartSeries.getOverlap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getOverlap) kan du ange hur mycket staplar och kolumner ska överlappa i ett 2D‑diagram (intervall: -100 till 100). Denna egenskap gäller för alla serier i den överordnade serieggruppen: detta är en projektion av den lämpliga gruppegenskapen. Därför är denna egenskap skrivskyddad.

Använd den läs/skriv‑egenskap `ParentSeriesGroup.getOverlap` för att ange ditt önskade värde för `Overlap`.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Lägg till ett grupperat stapeldiagram på en bild.
1. Hämta den första diagramserien.
1. Hämta diagramseriens `ParentSeriesGroup` och ange ditt önskade överlappningsvärde för serien.
1. Skriv den ändrade presentationen till en PPTX‑fil.

Detta JavaScript‑kodexempel visar hur du ställer in överlappning för en diagramserie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till diagram
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Ställer in seriens överlappning
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Skriver presentationsfilen till disk
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra seriefärg**

Aspose.Slides för Node.js via Java låter dig ändra en seriefärg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den serie vars färg du vill ändra.
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den ändrade presentationen.

Detta JavaScript‑kodexempel visar hur du ändrar en seriefärg:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra färg på seriekategori**

Aspose.Slides för Node.js via Java låter dig ändra en seriekategoris färg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den seriekategori vars färg du vill ändra.
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den ändrade presentationen.

Detta JavaScript‑kodexempel visar hur du ändrar en seriekategoris färg:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra seriens namn**

Som standard är legendnamnen för ett diagram innehållet i cellerna ovanför varje kolumn eller rad med data.

I vårt exempel (exempelbild),

* kolumnerna är *Series 1, Series 2,* och *Series 3*;
* raderna är *Category 1, Category 2, Category 3,* och *Category 4.*

Aspose.Slides för Node.js via Java låter dig uppdatera eller ändra ett serienamn i dess diagramdata och i legend.

Detta JavaScript‑kodexempel visar hur du ändrar ett serienamn i dess diagramdata `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Detta JavaScript‑kodexempel visar hur du ändrar ett serienamn i legend via `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange fyllningsfärg för diagramserie**

Aspose.Slides för Node.js via Java låter dig ange den automatiska fyllningsfärgen för diagramserier inom ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och ange fyllningsfärgen till Automatic.
1. Spara presentationen till en PPTX‑fil.

Detta JavaScript‑kodexempel visar hur du anger den automatiska fyllningsfärgen för en diagramserie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Skapar ett grupperat stapeldiagram
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Ställer in seriefyllningsformat till automatiskt
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Skriver presentationsfilen till disk
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in inverterad fyllningsfärg för diagramserie**

Aspose.Slides låter dig ange inverterad fyllningsfärg för diagramserier inom ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType.ClusteredColumn`).
1. Hämta diagramserien och ange fyllningsfärgen till invert.
1. Spara presentationen till en PPTX‑fil.

Detta JavaScript‑kodexempel demonstrerar åtgärden:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Lägger till nya serier och kategorier
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Hämtar den första diagramserien och fyller i dess seriedata.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in inversion när värdet är negativt**

Aspose.Slides låter dig ställa in inverteringar via metoden `ChartDataPoint.setInvertIfNegative`. När en inversion har ställts in med egenskaperna, inverterar datapunkten sina färger när den får ett negativt värde.

Detta JavaScript‑kodexempel demonstrerar åtgärden:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rensa data för specifika datapunkter**

Aspose.Slides för Node.js via Java låter dig rensa `DataPoints`‑data för en specifik diagramserie på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta referensen till en bild via dess index.
3. Hämta referensen till ett diagram via dess index.
4. Iterera genom alla diagram‑`DataPoints` och sätt `XValue` och `YValue` till null.
5. Rensa alla`DataPoints` för en specifik diagramserie.
6. Skriv den ändrade presentationen till en PPTX‑fil.

Detta JavaScript‑kodexempel demonstrerar åtgärden:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in seriens glappbredd**

Aspose.Slides för Node.js via Java låter dig ställa in en seriers glappbredd via egenskapen **`GapWidth`** på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta en vald diagramserie.
1. Ange egenskapen `GapWidth`.
1. Skriv den ändrade presentationen till en PPTX‑fil.

Detta JavaScript‑kodexempel visar hur du ställer in en seriers glappbredd:

```javascript
// Skapar en tom presentation
var pres = new aspose.slides.Presentation();
try {
    // Hämtar presentationens första bild
    var slide = pres.getSlides().get_Item(0);
    // Lägger till ett diagram med standarddata
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Ställer in index för diagrammets datablad
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Lägger till serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Lägger till kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Hämtar den andra diagramserien
    var series = chart.getChartData().getSeries().get_Item(1);
    // Fyller seriedatan
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ställer in GapWidth‑värdet
    series.getParentSeriesGroup().setGapWidth(50);
    // Sparar presentationen till disk
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Finns det någon gräns för hur många serier ett enda diagram kan innehålla?**

Aspose.Slides har ingen fast gräns för hur många serier du lägger till. Det praktiska taket bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**Vad händer om kolumnerna inom en grupp är för nära varandra eller för långt ifrån varandra?**

Justera inställningen Glappbredd för den serien (eller dess överordnade serieggrupp). Ett högre värde ökar avståndet mellan kolumnerna, medan ett lägre värde får dem att stå närmare varandra.