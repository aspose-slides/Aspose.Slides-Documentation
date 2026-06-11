---
title: Anpassa pajdiagram i presentationer med JavaScript
linktitle: Pajdiagram
type: docs
url: /sv/nodejs-java/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plot-alternativ
- segmentfärg
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar pajdiagram i JavaScript med Aspose.Slides för Node.js, exportera till PowerPoint och förbättra din databerättelse på sekunder."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram, och hur man aktiverar automatisk färgning av segment för ett standardpajdiagram. Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, samt spara den uppdaterade presentationen.

## **Andra diagramalternativ för Pie of Pie- och Bar of Pie-diagram**
Aspose.Slides för Node.js via Java stöder nu sekundära diagramalternativ för Pie of Pie- eller Bar of Pie-diagram. I det här avsnittet visar vi hur du anger dessa alternativ med Aspose.Slides. För att ange egenskaperna gör du så här:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klassobjekt.
1. Lägg till diagram på bilden.
1. Ange diagrammets sekundära diagramalternativ.
1. Skriv presentationen till disk.

I exemplet nedan har vi ställt in olika egenskaper för Pie of Pie-diagrammet.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Lägg till diagram på bilden
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Ställ in olika egenskaper
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Skriv presentation till disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange automatisk färgning av segment i pajdiagram**
Aspose.Slides för Node.js via Java tillhandahåller ett enkelt API för att ställa in automatiska färger för segment i pajdiagram. Exempelkoden tillämpar inställningen av de nämnda egenskaperna.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klassen.
1. Åtkomst till första bilden.
1. Lägg till diagram med standarddata.
1. Ange diagramrubrik.
1. Ställ in första serien på Visa värden.
1. Ange indexet för diagrammets datablad.
1. Hämta diagrammets datablad.
1. Ta bort standardgenererade serier och kategorier.
1. Lägg till nya kategorier.
1. Lägg till nya serier.

Skriv den modifierade presentationen till en PPTX‑fil.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Lägg till diagram med standarddata
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ställer in diagramrubrik
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ställ in första serien på Visa värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ställer in indexet för diagrammets datablad
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ta bort standardgenererade serier och kategorier
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Lägger till ny serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Fyller nu i seriedata
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Stöds 'Pie of Pie' och 'Bar of Pie' varianterna?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/) ett sekundärt diagram för pajdiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera bara diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage) (t.ex. PNG) utan hela presentationen.