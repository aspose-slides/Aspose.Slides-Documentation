---
title: Anpassa pajdiagram i presentationer med Java
linktitle: Pajdiagram
type: docs
url: /sv/java/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar pajdiagram i Java med Aspose.Slides, exporterat till PowerPoint, och förbättrar din databerättelse på sekunder."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram, och hur man aktiverar automatisk färgläggning av segment för ett standardpajdiagram.

Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serie- och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden samt spara den uppdaterade presentationen.

## **Alternativ för sekundärt diagram för Pie of Pie- och Bar of Pie-diagram**
Aspose.Slides for Java stöder nu alternativ för sekundärt diagram för Pie of Pie- eller Bar of Pie-diagram. I det här avsnittet visar vi hur du anger dessa alternativ med hjälp av Aspose.Slides. För att ange egenskaperna gör du så här:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klassobjektet.
2. Lägg till diagram på bilden.
3. Ange diagrammets alternativ för sekundärt diagram.
4. Skriv presentationen till disk.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Lägg till diagram på bilden
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Ställ in olika egenskaper
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Skriv presentationen till disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in automatiska färger för pajdiagramsegment**
Aspose.Slides for Java tillhandahåller ett enkelt API för att ställa in automatiska färger för pajdiagramsegment. Exempelkoden tillämpar inställningen av de ovan nämnda egenskaperna.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klassen.
2. Hämta den första bilden.
3. Lägg till diagram med standarddata.
4. Ange diagramtitel.
5. Ställ in den första serien på Visa värden.
6. Ange index för diagrammets datasheet.
7. Hämta diagrammets dataarbetsblad.
8. Ta bort standardgenererade serier och kategorier.
9. Lägg till nya kategorier.
10. Lägg till nya serier.

Skriv den modifierade presentationen till en PPTX-fil.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Lägg till diagram med standarddata
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ställer in diagramtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ställ in första serien på Visa värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Ställer in index för diagrammets datasheet
    int defaultWorksheetIndex = 0;

    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Ta bort standardgenererade serier och kategorier
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Lägger till ny serie
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Fyller nu i seriedata
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**
**Stöds varianterna 'Pie of Pie' och 'Bar of Pie'?**

Ja, biblioteket [stödjer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) ett sekundärt diagram för pajdiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera bara diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) (t.ex. PNG) utan hela presentationen.